namespace WalletObjectsSample.Webservice
{

	public class WebserviceParams
	{
	  internal string linkingId;
	  internal WebserviceWalletUser walletUser;
	  internal bool promotionalEmailOptIn;
	  internal bool tosUserAcceptance;

	  public WebserviceParams()
	  {
	  }

	  /// <returns> the linkingId </returns>
	  public virtual string LinkingId
	  {
		  get
		  {
			  return linkingId;
		  }
		  set
		  {
			  this.linkingId = value;
		  }
	  }


	  /// <returns> the walletUser </returns>
	  public virtual WebserviceWalletUser WalletUser
	  {
		  get
		  {
			  return walletUser;
		  }
		  set
		  {
			  this.walletUser = value;
		  }
	  }


	  /// <returns> the promotionalEmailOptIn </returns>
	  public virtual bool PromotionalEmailOptIn
	  {
		  get
		  {
			  return promotionalEmailOptIn;
		  }
		  set
		  {
			  this.promotionalEmailOptIn = value;
		  }
	  }


	  /// <returns> the tosUserAcceptance </returns>
	  public virtual bool TosUserAcceptance
	  {
		  get
		  {
			  return tosUserAcceptance;
		  }
		  set
		  {
			  this.tosUserAcceptance = value;
		  }
	  }
	}
}