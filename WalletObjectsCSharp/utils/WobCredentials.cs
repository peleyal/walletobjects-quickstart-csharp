namespace WalletObjectsSample.Utils
{
	public class WobCredentials
	{
	  internal string serviceAccountId;
	  internal string serviceAccountPrivateKey;
	  internal string applicationName;
	  internal string issuerId;

	  public WobCredentials(string serviceAccountId, string privateKey, string applicationName, string issuerId)
	  {
		  ServiceAccountId = serviceAccountId;
		  ServiceAccountPrivateKey = privateKey;
		  ApplicationName = applicationName;
		  IssuerId = issuerId;
	  }

	  /// <returns> the serviceAccountId </returns>
	  public virtual string ServiceAccountId
	  {
		  get
		  {
			  return serviceAccountId;
		  }
		  set
		  {
			  this.serviceAccountId = value;
		  }
	  }
	  /// <returns> the serviceAccountPrivateKey </returns>
	  public virtual string ServiceAccountPrivateKey
	  {
		  get
		  {
			  return serviceAccountPrivateKey;
		  }
		  set
		  {
			  this.serviceAccountPrivateKey = value;
		  }
	  }
	  /// <returns> the applicationName </returns>
	  public virtual string ApplicationName
	  {
		  get
		  {
			  return applicationName;
		  }
		  set
		  {
			  this.applicationName = value;
		  }
	  }
	  /// <returns> the issuerId </returns>
	  public virtual string IssuerId
	  {
		  get
		  {
			  return issuerId;
		  }
		  set
		  {
			  this.issuerId = value;
		  }
	  }
	}
}