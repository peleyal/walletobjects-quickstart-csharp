namespace WalletObjectsSample.Webservice
{
	public class WebserviceResponse
	{
	  internal string message;
	  internal string result;

	  public WebserviceResponse()
	  {
	  }

	  public WebserviceResponse(string message, string result)
	  {
		  Message = message;
		  Result = result;
	  }

	  public virtual string Message
	  {
		  get
		  {
			return message;
		  }
		  set
		  {
			this.message = value;
		  }
	  }


	  public virtual string Result
	  {
		  get
		  {
			return result;
		  }
		  set
		  {
			this.result = value;
		  }
	  }

	}

}