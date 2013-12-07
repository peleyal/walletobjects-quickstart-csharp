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