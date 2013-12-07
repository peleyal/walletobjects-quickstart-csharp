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

using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters;

namespace WalletObjectsSample.Verticals
{
    public class Loyalty
    {
        /// <summary>
        /// Generates a Loyalty Object
        /// </summary>
        /// <param name="issuerId"> </param>
        /// <param name="classId"> </param>
        /// <param name="objectId"> </param>
        /// <returns> loyaltyObject </returns>
        public static LoyaltyObject generateLoyaltyObject(string issuerId, string classId, string objectId)
        {
          // Define Barcode
          Barcode barcode = new Barcode() { 
            Type = "qrCode",
            Value = "28343E3" 
          };

          // Define Points
          LoyaltyPoints points = new LoyaltyPoints() {
            Label = "Balance",
            Balance = new LoyaltyPointsBalance() { String = "25.00" }
          };

          // Define Text Module Data
          IList<TextModuleData> textModulesData = new List<TextModuleData>();

          TextModuleData textModuleData = new TextModuleData() {
            Header = "Text Header",
            Body = "Text Body"
          };

          textModulesData.Add(textModuleData);          
          
          // Define Uris
          IList<Uri> uris = new List<Uri>();
          Uri uri1 = new Uri() {
            Description = "uri 1 description",
            UriValue = "http://www.google.com"
          };
          Uri uri2 = new Uri() {
            Description = "uri 2 description",
            UriValue = "http://www.google.com"
          };

          uris.Add(uri1);
          uris.Add(uri2);

          LinksModuleData linksModuleData = new LinksModuleData() {
            Uris = uris
          };
          
          // Define Info Module
          IList<LabelValue> row0cols = new List<LabelValue>();
          LabelValue row0col0 = new LabelValue() { Label = "Label0-0", Value = "value0-0" };
          LabelValue row0col1 = new LabelValue() { Label = "Label0-1", Value = "value0-1" };          
          row0cols.Add(row0col0);
          row0cols.Add(row0col1);

          IList<LabelValue> row1cols = new List<LabelValue>();
          LabelValue row1col0 = new LabelValue() { Label = "Label1-0", Value = "value1-0" };
          LabelValue row1col1 = new LabelValue() { Label = "Label1-1", Value = "value1-1" };          
          row1cols.Add(row1col0);
          row1cols.Add(row1col1);

          IList<LabelValueRow> rows = new List<LabelValueRow>();
          LabelValueRow row0 = new LabelValueRow() { HexBackgroundColor = "#AEAEAE", Columns = row0cols };
          LabelValueRow row1 = new LabelValueRow() { HexBackgroundColor = "#AEAEAE", Columns = row1cols };

          rows.Add(row0);
          rows.Add(row1);

          InfoModuleData infoModuleData = new InfoModuleData() {
            HexFontColor = "#FF3300",
            HexBackgroundColor = "#ABABAB",
            ShowLastUpdateTime = true,
            LabelValueRows = rows 
          };

          // Define Wallet Instance
          LoyaltyObject loyaltyObj = new LoyaltyObject()
          {
            ClassId = issuerId + "." + classId,
            Id = issuerId + "." + objectId,
            Version = "1",
            State = "active",
            Barcode = barcode,
            AccountName = "Joe Smith",
            AccountId = "1234567890",
            LoyaltyPoints = points,
            InfoModuleData = infoModuleData,
            TextModulesData = textModulesData,
            LinksModuleData = linksModuleData,
            //IssuerData = objectIssuerData
          };
          
/*
          // Define Wallet Instance
          LoyaltyObject loyaltyObj = new LoyaltyObject()
          {
            ClassId = issuerId + "." + classId,
            Id = issuerId + "." + objectId,
            Version = "1",
            State = "active",
            Barcode = barcode,
            AccountName = "Joe Smith",
            AccountId = "1234567890",
            LoyaltyPoints = points,
            //IssuerData = objectIssuerData
          };
*/
          return loyaltyObj;
        }

        /// <summary>
        /// Generates a Loyalty Class
        /// </summary>
        /// <param name="issuerId"> </param>
        /// <param name="classId"> </param>
        /// <returns> loyaltyClass </returns>
        public static LoyaltyClass generateLoyaltyClass(string issuerId, string classId)
        {
            // Define general messages
            IList<WalletObjectMessage> messages = new List<WalletObjectMessage>();
            WalletObjectMessage message = new WalletObjectMessage();
            message.Header = "Welcome";
            message.Body = "Welcome to Banconrista Rewards!";

            Uri imageUri = new Uri();
            imageUri.UriValue = "https://ssl.gstatic.com/codesite/ph/images/search-48.gif";
            Image messageImage = new Image();
            messageImage.SourceUri = imageUri;
            message.Image = messageImage;

            Uri actionUri = new Uri();
            actionUri.UriValue = "http://baconrista.com";
            message.ActionUri = actionUri;

            messages.Add(message);

            // Define rendering templates per view
            IList<RenderSpec> renderSpec = new List<RenderSpec>();

            RenderSpec listRenderSpec = new RenderSpec();
            listRenderSpec.ViewName = "g_list";
            listRenderSpec.TemplateFamily = "1.loyaltyCard1_list";

            RenderSpec expandedRenderSpec = new RenderSpec();
            expandedRenderSpec.ViewName = "g_expanded";
            expandedRenderSpec.TemplateFamily = "1.loyaltyCard1_expanded";

            renderSpec.Add(listRenderSpec);
            renderSpec.Add(expandedRenderSpec);

            // Define Geofence locations
            IList<LatLongPoint> locations = new List<LatLongPoint>();

            LatLongPoint llp1 = new LatLongPoint();
            llp1.Latitude = 37.422601;
            llp1.Longitude = -122.085286;

            LatLongPoint llp2 = new LatLongPoint();
            llp2.Latitude = 37.429379;
            llp2.Longitude = -122.122730;

            locations.Add(llp1);
            locations.Add(llp2);

            // Create class
            LoyaltyClass wobClass = new LoyaltyClass();
            wobClass.Id = issuerId + "." + classId;
            wobClass.Version = "1";
            wobClass.IssuerName = "Baconrista";
            wobClass.ProgramName = "Baconrista Rewards";

            Uri homepageUri = new Uri();
            homepageUri.UriValue = "https://www.example.com"; 
            homepageUri.Description = "Website";
            wobClass.HomepageUri = homepageUri;

            Uri logoImageUri = new Uri();
            logoImageUri.UriValue = "http://www.google.com/landing/chrome/ugc/chrome-icon.jpg"; 
            Image logoImage = new Image();
            logoImage.SourceUri = logoImageUri;
            wobClass.ProgramLogo = logoImage;
                
            wobClass.RewardsTierLabel= "Tier";
            wobClass.RewardsTier = "Gold";
            wobClass.AccountNameLabel = "Member Name";
            wobClass.AccountIdLabel = "Member Id";
            wobClass.RenderSpecs = renderSpec;
            wobClass.Messages = messages;
            wobClass.ReviewStatus = "draft";
            wobClass.AllowMultipleUsersPerObject = true;
            wobClass.Locations = locations;

            return wobClass;
        }
    }

}