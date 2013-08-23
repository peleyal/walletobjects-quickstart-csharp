namespace WalletObjectsSample.Webservice
{

	public class WebserviceRequest
	{
	  internal string apiVersion;
	  internal string method; //link, signup
	  internal WebserviceParams prms;

	  public WebserviceRequest()
	  {
	  }

	  /// <returns> the apiVersion </returns>
	  public virtual string ApiVersion
	  {
		  get
		  {
			  return apiVersion;
		  }
		  set
		  {
			  this.apiVersion = value;
		  }
	  }


	  /// <returns> the method </returns>
	  public virtual string Method
	  {
		  get
		  {
			  return method;
		  }
		  set
		  {
			  this.method = value;
		  }
	  }


	  /// <returns> the params </returns>
	  public virtual WebserviceParams Params
	  {
		  get
		  {
			  return prms;
		  }
		  set
		  {
			  this.prms = value;
		  }
	  }
	}
}