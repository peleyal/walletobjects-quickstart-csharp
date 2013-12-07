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

using System.Collections.Generic;

namespace WalletObjectsSample.Webservice
{
	public class WebserviceWalletUser
	{
	   internal string firstName;
	   internal string middleName;
	   internal string lastName;
	   internal string streetAddress;
	   internal string city;
	   internal string state;
	   internal string zipcode;
	   internal string country;
	   internal string email;
	   internal string phone;
	   internal string gender;
	   internal string birthday;
	   internal IList<string> userModifiedFields;

	   public WebserviceWalletUser()
	   {
	   }

	   /// <returns> the firstName </returns>
	  public virtual string FirstName
	  {
		  get
		  {
			return firstName;
		  }
		  set
		  {
			this.firstName = value;
		  }
	  }

	  /// <returns> the middleName </returns>
	  public virtual string MiddleName
	  {
		  get
		  {
			return middleName;
		  }
		  set
		  {
			this.middleName = value;
		  }
	  }

	  /// <returns> the lastName </returns>
	  public virtual string LastName
	  {
		  get
		  {
			return lastName;
		  }
		  set
		  {
			this.lastName = value;
		  }
	  }

	  /// <returns> the streetAddress </returns>
	  public virtual string StreetAddress
	  {
		  get
		  {
			return streetAddress;
		  }
		  set
		  {
			this.streetAddress = value;
		  }
	  }

	  /// <returns> the city </returns>
	  public virtual string City
	  {
		  get
		  {
			return city;
		  }
		  set
		  {
			this.city = value;
		  }
	  }

	  /// <returns> the state </returns>
	  public virtual string State
	  {
		  get
		  {
			return state;
		  }
		  set
		  {
			this.state = value;
		  }
	  }

	  /// <returns> the zipcode </returns>
	  public virtual string Zipcode
	  {
		  get
		  {
			return zipcode;
		  }
		  set
		  {
			this.zipcode = value;
		  }
	  }

	  /// <returns> the country </returns>
	  public virtual string Country
	  {
		  get
		  {
			return country;
		  }
		  set
		  {
			this.country = value;
		  }
	  }

	  /// <returns> the email </returns>
	  public virtual string Email
	  {
		  get
		  {
			return email;
		  }
		  set
		  {
			this.email = value;
		  }
	  }

	  /// <returns> the phone </returns>
	  public virtual string Phone
	  {
		  get
		  {
			return phone;
		  }
		  set
		  {
			this.phone = value;
		  }
	  }

	  /// <returns> the gender </returns>
	  public virtual string Gender
	  {
		  get
		  {
			return gender;
		  }
		  set
		  {
			this.gender = value;
		  }
	  }


	  /// <returns> the birthday </returns>
	  public virtual string Birthday
	  {
		  get
		  {
			return birthday;
		  }
		  set
		  {
			this.birthday = value;
		  }
	  }

	  /// <returns> the userModifiedFields </returns>
	  public virtual IList<string> UserModifiedFields
	  {
		  get
		  {
			return userModifiedFields;
		  }
		  set
		  {
			this.userModifiedFields = value;
		  }
	  }
	}
}