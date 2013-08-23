using System;
using System.Web;
using System.Web.Configuration;
using System.Security.Cryptography.X509Certificates;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Services;
using Google.Apis.Walletobjects.v1;
using Google.Apis.Walletobjects.v1.Data;
using WalletObjectsSample.Utils;
using WalletObjectsSample.Verticals;

namespace WalletObjectsSample.Handlers
{
	public class WobInsertHandler : System.Web.IHttpHandler
	{
		public bool IsReusable {
			get {
				return true;
			}
		}

		public virtual void ProcessRequest (HttpContext context)
		{
			HttpRequest request = context.Request;
			HttpResponse response = context.Response;

			WobCredentials credentials = new WobCredentials (
				WebConfigurationManager.AppSettings ["ServiceAccountId"],
				WebConfigurationManager.AppSettings ["ServiceAccountPrivateKey"],
				WebConfigurationManager.AppSettings ["ApplicationName"],
				WebConfigurationManager.AppSettings ["IssuerId"]);

			// OAuth
			X509Certificate2 certificate = new X509Certificate2 (
				AppDomain.CurrentDomain.BaseDirectory + credentials.serviceAccountPrivateKey, 
				"notasecret", 
				X509KeyStorageFlags.Exportable);

			var tokenProvider = new AssertionFlowClient (GoogleAuthenticationServer.Description, certificate) {
				ServiceAccountId = credentials.serviceAccountId,
				Scope = "https://www.googleapis.com/auth/wallet_object.issuer"
			};

			var authenticator = new OAuth2Authenticator<AssertionFlowClient> (tokenProvider, AssertionFlowClient.GetState);

			// WalletobjectsService
			WalletobjectsService woService = new WalletobjectsService (
				new BaseClientService.Initializer () {
				Authenticator = authenticator,
				ApplicationName = "Wobs Quickstart"
			});

			// LoyaltyclassResource
			LoyaltyclassResource lcResource = new LoyaltyclassResource (woService, woService.Authenticator);

			// get the class type
			string type = request.Params ["type"];

			if (type.Equals ("loyalty")) {
				LoyaltyClass loyaltyClass = Loyalty.generateLoyaltyClass (credentials.IssuerId, "ExampleLoyaltyClass2");
				LoyaltyClass lcResponse = woService.Loyaltyclass.Insert (loyaltyClass).Execute ();
				response.Write (lcResponse.ToString ());
			} else if (type.Equals ("offer")) {
				OfferClass offerClass = Offer.generateOfferClass (credentials.IssuerId, "OC");
				OfferClass ocResponse = woService.Offerclass.Insert (offerClass).Execute ();
				response.Write (ocResponse.ToString ());
			}
		}
	}
}

