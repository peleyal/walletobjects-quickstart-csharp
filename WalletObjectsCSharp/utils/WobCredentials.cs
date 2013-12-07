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