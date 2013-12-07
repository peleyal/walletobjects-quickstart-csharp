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
using Google.Apis.Walletobjects.v1;
using Google.Apis.Walletobjects.v1.Data;

namespace WalletObjectsSample.Verticals
{
	public class Offer
	{
	  public static OfferObject generateOfferObject(string issuerId, string classId, string objectId)
	  {
		  Barcode barcode = new Barcode();
      barcode.Type = "upcA";
      barcode.Value ="123456789012";
      barcode.AlternateText = "12345";
      barcode.Label = "User Id";

		  // Define Wallet Object
		  OfferObject offobj = new OfferObject();
      offobj.ClassId = issuerId + "." + classId;
      offobj.Id = issuerId + "." + objectId;
      offobj.Version = "1";
      offobj.Barcode = barcode;
      offobj.State = "active";

		  return offobj;
	  }

	  public static OfferClass generateOfferClass(string issuerId, string classId)
	  {
		  IList<RenderSpec> renderSpec = new List<RenderSpec>();

		  RenderSpec listRenderSpec = new RenderSpec();
      listRenderSpec.ViewName = "g_list";
      listRenderSpec.TemplateFamily = "1.offer1_list";

		  RenderSpec expandedRenderSpec = new RenderSpec();
      expandedRenderSpec.ViewName = "g_expanded";
      expandedRenderSpec.TemplateFamily = "1.offer1_expanded";

		  renderSpec.Add(listRenderSpec);
		  renderSpec.Add(expandedRenderSpec);

		  IList<LatLongPoint> locations = new List<LatLongPoint>();

      LatLongPoint llp1 = new LatLongPoint();
      llp1.Latitude = 37.442087;
      llp1.Longitude = -122.161446;

      LatLongPoint llp2 = new LatLongPoint();
      llp2.Latitude = 37.429379;
      llp2.Longitude = -122.122730;

      LatLongPoint llp3 = new LatLongPoint();
      llp3.Latitude = 37.333646;
      llp3.Longitude = -121.884853;

		  locations.Add(llp1);
      locations.Add(llp2); 
      locations.Add(llp3);

		  OfferClass wobClass = new OfferClass();
      wobClass.Id = issuerId + "." + classId;
      wobClass.Version = "1";
      wobClass.IssuerName = "Baconrista Coffee";
      wobClass.Title = "20% off one cup of coffee";
      wobClass.Provider = "Baconrista Deals";
      wobClass.Details = "20% off one cup of coffee at all Baconristas";

      Uri homepageUri = new Uri();
      homepageUri.UriValue = "http://baconrista.com/"; 
      homepageUri.Description = "Website";
      wobClass.HomepageUri = homepageUri;

      Uri imageUri = new Uri();
      imageUri.UriValue = "http://3.bp.blogspot.com/-AvC1agljv9Y/TirbDXOBIPI/AAAAAAAACK0/hR2gs5h2H6A/s1600/Bacon%2BWallpaper.png"; 
      Image titleImage = new Image();
      titleImage.SourceUri = imageUri;
      wobClass.TitleImage = titleImage;

      wobClass.RenderSpecs = renderSpec;
      wobClass.RedemptionChannel = "both";
      wobClass.ReviewStatus = "underReview";
      wobClass.Locations = locations;
      wobClass.AllowMultipleUsersPerObject = true;
		
      return wobClass;
	  }
	}
}