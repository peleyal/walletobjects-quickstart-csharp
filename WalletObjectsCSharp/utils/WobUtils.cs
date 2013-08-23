using System;
using System.Collections.Generic;
using Google.Apis;
using Google.Apis.Json;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Utils
{
    /*
	using JsonToken = net.oauth.jsontoken.JsonToken;
	using RsaSHA256Signer = net.oauth.jsontoken.crypto.RsaSHA256Signer;

	using Instant = org.joda.time.Instant;

	using GoogleCredential = com.google.api.client.googleapis.auth.oauth2.GoogleCredential;
	using HttpTransport = com.google.api.client.http.HttpTransport;
	using NetHttpTransport = com.google.api.client.http.javanet.NetHttpTransport;
	using GenericJson = com.google.api.client.json.GenericJson;
	using JsonFactory = com.google.api.client.json.JsonFactory;
	using GsonFactory = com.google.api.client.json.gson.GsonFactory;
	using SecurityUtils = com.google.api.client.util.SecurityUtils;
	using Walletobjects = com.google.api.services.walletobjects.Walletobjects;
	using DateTime = com.google.api.services.walletobjects.model.DateTime;
	using ByteStreams = com.google.common.io.ByteStreams;
	using Gson = com.google.gson.Gson;
	using JsonObject = com.google.gson.JsonObject;
	using WebserviceResponse = com.google.wallet.objects.webservice.WebserviceResponse;
    */

	public class WobUtils
	{

	  private readonly string SAVE_TO_WALLET = "savetowallet";
	  private readonly string LOYALTY_WEB = "loyaltywebservice";
	  private readonly string WOB_PROD = "https://www.googleapis.com/auth/wallet_object.issuer";
	  private readonly string GOOGLE = "google";

	  private readonly string serviceAccountId;
	  private readonly string rsaKeyPath;
	  private readonly string applicationName;
	  private readonly string issuerId;
	  private GoogleCredential credential = null;

	  private HttpTransport httpTransport;
	  private JsonFactory jsonFactory;

	  internal RsaSHA256Signer signer = null;
	  internal Gson gson = new Gson();

	  public WobUtils(WobCredentials credentials)
	  {
		serviceAccountId = credentials.ServiceAccountId;
		rsaKeyPath = credentials.ServiceAccountPrivateKey;
		applicationName = credentials.ApplicationName;
		issuerId = credentials.IssuerId;
		httpTransport = new NetHttpTransport();
		jsonFactory = new GsonFactory();
		File file = new File(rsaKeyPath);
		sbyte[] bytes = ByteStreams.toByteArray(new FileInputStream(file));
		InputStream inputStream = new ByteArrayInputStream(bytes);
		RSAPrivateKey rsaKey = (RSAPrivateKey) SecurityUtils.loadPrivateKeyFromKeyStore(SecurityUtils.Pkcs12KeyStore, inputStream, "notasecret", "privatekey", "notasecret");
		signer = new RsaSHA256Signer(serviceAccountId, null, rsaKey);
	  }

	  /// <summary>
	  /// Creates a Walletobjects client with sandbox and production scopes
	  /// </summary>
	  /// <returns> Walletobjects client </returns>
	  /// <exception cref="GeneralSecurityException"> </exception>
	  /// <exception cref="IOException"> </exception>
	  public virtual Walletobjects Client
	  {
		  get
		  {
			credential = Credential;
    
			return (new Walletobjects.Builder(httpTransport, jsonFactory, credential)).setApplicationName(applicationName).build();
		  }
	  }

	  /// <summary>
	  /// Helper function to generate the Google Credential
	  /// 
	  /// @return </summary>
	  public virtual GoogleCredential Credential
	  {
		  get
		  {
			IList<string> scopes = new List<string>();
			scopes.Add(WOB_PROD);
    
			return credential = (new GoogleCredential.Builder()).setTransport(httpTransport).setJsonFactory(jsonFactory).setServiceAccountId(serviceAccountId).setServiceAccountScopes(scopes).setServiceAccountPrivateKeyFromP12File(new File(rsaKeyPath)).build();
		  }
	  }

	  /// <summary>
	  /// Refreshes the access token and returns it
	  /// </summary>
	  /// <returns> OAuth access token </returns>
	  public virtual string accessToken()
	  {
		if (credential == null)
		{
		  credential = Credential;
		}
		credential.refreshToken();
		return credential.AccessToken;
	  }

	  public virtual string generateWebserviceFailureResponseJwt(WebserviceResponse resp)
	  {
		return generateWebserviceResponseJwt(null, resp);
	  }

	  /// <summary>
	  /// Generates the linking/signup JWT from a Wallet Object
	  /// </summary>
	  /// <param name="object"> </param>
	  /// <param name="resp">
	  /// @return </param>
	  public virtual string generateWebserviceResponseJwt(GenericJson @object, WebserviceResponse resp)
	  {
		JsonToken token = new JsonToken(signer);
		token.Audience = GOOGLE;
		token.setParam("typ", LOYALTY_WEB);
		token.IssuedAt = new Instant(new DateTime().TimeInMillis - 5000L);
		WobPayload payload = new WobPayload();

		if (@object != null)
		{
		  @object.Factory = new GsonFactory();
		  payload.addObject(@object);
		}

		payload.Response = resp;
		JsonObject obj = gson.toJsonTree(payload).AsJsonObject;
		token.PayloadAsJsonObject.add("payload", obj);
		return token.serializeAndSign();
	  }

	  /// <summary>
	  /// Generates the Save to Wallet JWT from a Wallet Object
	  /// </summary>
	  /// <param name="object"> </param>
	  /// <param name="origins">
	  /// @return </param>
	  /// <exception cref="SignatureException"> </exception>
	  public virtual string generateSaveJwt(GenericJson @object, IList<string> origins)
	  {
		WobPayload payload = new WobPayload();
		payload.addObject(@object);
		return generateSaveJwt(payload, origins);
	  }

	  public virtual string generateSaveJwt(WobPayload payload, IList<string> origins)
	  {
		JsonToken token = new JsonToken(signer);
		token.Audience = GOOGLE;
		token.setParam("typ", SAVE_TO_WALLET);
		token.IssuedAt = new Instant(new DateTime().TimeInMillis - 5000L);
		JsonObject obj = gson.toJsonTree(payload).AsJsonObject;
		token.PayloadAsJsonObject.add("payload", obj);
		token.PayloadAsJsonObject.add("origins", gson.toJsonTree(origins));
		return token.serializeAndSign();
	  }

	  /// 
	  /// <param name="rfc3339">
	  /// @return </param>
	  public static DateTime toDateTime(string rfc3339)
	  {
		return (new DateTime()).setDate(com.google.api.client.util.DateTime.parseRfc3339(rfc3339));
	  }

	  public virtual string ServiceAccountId
	  {
		  get
		  {
			return serviceAccountId;
		  }
	  }

	  public virtual string IssuerId
	  {
		  get
		  {
			return issuerId;
		  }
	  }
	}

}