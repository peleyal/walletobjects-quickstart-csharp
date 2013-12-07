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