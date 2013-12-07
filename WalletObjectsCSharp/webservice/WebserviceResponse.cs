/*
Copyright 2013 Google Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

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