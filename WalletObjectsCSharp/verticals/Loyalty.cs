using System.Collections.Generic;
using Google.Apis.Walletobjects.v1;
using Google.Apis.Walletobjects.v1.Data;

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
            Barcode barcode = new Barcode();
            barcode.Type = "qrCode";
            barcode.Value = "28343E3";
            barcode.AlternateText = "12345";
            barcode.Label = "User Id";

            // Define Messages:
            IList<WalletObjectMessage> messages = new List<WalletObjectMessage>();
            WalletObjectMessage message = new WalletObjectMessage();
            message.Header = "Hi Joe";
            message.Body = "Click here for a coupon to use at your local Baconrista shop!";

            Uri imageUri = new Uri();
            imageUri.UriValue = "https://ssl.gstatic.com/codesite/ph/images/search-48.gif";
            Image messageImage = new Image();
            messageImage.SourceUri = imageUri;
            message.Image = messageImage;

            Uri actionUri = new Uri();
            actionUri.UriValue = "http://baconrista.com";
            message.ActionUri = actionUri;

            messages.Add(message);

            // Define Points
            LoyaltyPoints points = new LoyaltyPoints();
            points.Label = "Points";

            LoyaltyPointsBalance balance = new LoyaltyPointsBalance();
            balance.Int = 500;
            points.Balance = balance;

            DateTime dateTime = new DateTime();
            dateTime.Date = "2012-06-12T23:20:50.52Z";
            TimeInterval timeInterval = new TimeInterval();
            timeInterval.End = dateTime;
            points.PointsValidInterval = timeInterval;

            points.PointsType = "rewards";

            // Define Wallet Instance
            LoyaltyObject loyaltyObj = new LoyaltyObject();
            loyaltyObj.ClassId = issuerId + "." + classId;
            loyaltyObj.Id = issuerId + "." + objectId;
            loyaltyObj.Version = "1";
            loyaltyObj.State = "active";
            loyaltyObj.Barcode = barcode;
            loyaltyObj.Messages = messages;
            loyaltyObj.AccountName = "Joe Smith";
            loyaltyObj.AccountId = "1234567890";
            loyaltyObj.LoyaltyPoints = points;
            // Skip issuer data
            //loyaltyObj.IssuerData = objectIssuerData; ;

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
            // Skip issuer data for now
            //wobClass.IssuerData = issuerData; 

            return wobClass;
        }
    }

}