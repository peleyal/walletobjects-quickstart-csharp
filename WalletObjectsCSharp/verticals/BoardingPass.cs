using System.Collections.Generic;
using Google.Apis.Walletobjects.v1;
using Google.Apis.Walletobjects.v1.Data;

namespace WalletObjectsSample.Verticals
{
	public class BoardingPass
	{
	  public static BoardingPassObject generateBoardingPassObject(string issuerId, string classId, string objectId)
	  {
		  //Define Barcode
		  Barcode barcode = new Barcode();
      barcode.Type = "qrCode";
      barcode.Value = "28343E3";
      barcode.AlternateText = "12345";
      barcode.Label = "User Id";

		  //Define Messages:
		  IList<WalletObjectMessage> messages = new List<WalletObjectMessage>();
		  WalletObjectMessage message = new WalletObjectMessage();
      message.Header = "Hi Joe";
      message.Body = "Have a safe trip!";

      Uri imageUri = new Uri();
      imageUri.UriValue = "https://ssl.gstatic.com/codesite/ph/images/search-48.gif";
      Image messageImage = new Image();
      messageImage.SourceUri = imageUri;
      message.Image = messageImage;

      Uri actionUri = new Uri();
      actionUri.UriValue = "http://www.google.com";
      message.ActionUri = actionUri;

		  messages.Add(message);

		  //Define PassengerName:
		  PassengerName passengerName = new PassengerName();
      passengerName.Prefix = "Mr.";
      passengerName.First = "Joseph";
      passengerName.Middle = "Robert";
      passengerName.Last = "Passenger";
      passengerName.Suffix = "Jr.";

		  //Define Wallet instance
		  BoardingPassObject boardingPass = new BoardingPassObject();
      boardingPass.ClassId = issuerId + "." + classId;
      boardingPass.Id = issuerId + "." + objectId;
      boardingPass.Version = "1";
      boardingPass.State = "active";
      boardingPass.Barcode = barcode;
      boardingPass.Messages = messages;
      boardingPass.BoardingZone = "2";
      boardingPass.ElectronicTicket = true;
      boardingPass.FreqFlierAccountId = "31415927";
      boardingPass.FreqFlierTierLevel = "Gold";
      boardingPass.PassengerName = passengerName;
      boardingPass.PassengerStatus = new string[] {"STBY"};
      boardingPass.RecordLocator = "XYZZY1";
      boardingPass.Seat = "14F";
      boardingPass.SeatClass = "Economy";
      boardingPass.SeatDescriptions = new string[] {"Window"};
      boardingPass.SecuritySelecteeStatus = "SSSS";
      boardingPass.SequenceNumber = "17";
      boardingPass.SpecialServiceCodes = new string[] {"UMNR"};
      boardingPass.TicketNumber = "0112358132134";

		  return boardingPass;
	  }

	  public static BoardingPassClass generateBoardingPassClass(string issuerId, string classId)
	  {
		  //Define general messages
		  IList<WalletObjectMessage> messages = new List<WalletObjectMessage>();
		  WalletObjectMessage message = new WalletObjectMessage();
      message.Header = "Free Wifi";
      message.Body = "Free Wifi on Flight 123, compliments of Google";

      Uri imageUri = new Uri();
      imageUri.UriValue = "https://ssl.gstatic.com/codesite/ph/images/search-48.gif";
      Image messageImage = new Image();
      messageImage.SourceUri = imageUri;
      message.Image = messageImage;

      Uri actionUri = new Uri();
      actionUri.UriValue = "http://www.google.com";
      message.ActionUri = actionUri;

		  messages.Add(message);

		  //Define rendering templates per view
		  IList<RenderSpec> renderSpec = new List<RenderSpec>();

		  RenderSpec listRenderSpec = new RenderSpec();
      listRenderSpec.ViewName = "g_list";
      listRenderSpec.TemplateFamily = "1.boardingPass1_list";

      RenderSpec expandedRenderSpec = new RenderSpec();
      expandedRenderSpec.ViewName = "g_expanded";
      expandedRenderSpec.TemplateFamily = "1.boardingPass1_expanded";

		  renderSpec.Add(listRenderSpec);
		  renderSpec.Add(expandedRenderSpec);

		  BoardingPassClass flight = new BoardingPassClass();
      flight.Id = issuerId + "." + classId;
      flight.Version = "1";
      flight.IssuerName = "Imagine Airlines";

      Uri homepageUri = new Uri();
      homepageUri.UriValue = "http://www.example.com/";
      homepageUri.Description = "Website";
      flight.HomepageUri = homepageUri;

      flight.RenderSpecs = renderSpec;
      flight.Messages = messages;
      flight.AllowMultipleUsersPerObject = true;
      flight.AircraftType = "737";
      flight.ArrivalAirportCode = "SFO";
      flight.ArrivalCityName = "San Francisco";
      //flight.ArrivalDateTimeActual = WobUtils.toDateTime("2013-07-29T18:00:00Z");
      //flight.ArrivalDateTimeScheduled = WobUtils.toDateTime("2013-07-29T17:30:00Z");
      flight.ArrivalGate = "C12";
      flight.ArrivalTerminal = "C";
      flight.ArrivalTimeZone = "America/Los_Angeles";
      //flight.BoardingDateTime = WobUtils.toDateTime("2013-07-29T11:30:00Z");
      flight.CarrierCode = "IA";

      Uri logoimageUri = new Uri();
      logoimageUri.UriValue = "https://ssl.gstatic.com/codesite/ph/images/search-48.gif";
      Image logoImage = new Image();
      logoImage.SourceUri = logoimageUri;
      flight.CarrierLogoImage = logoImage;

      flight.CarrierName = "Imagine Airlines";
      flight.DepartureAirportCode = "BOS";
      flight.DepartureCityName = "Boston";
      //flight.DepartureDateTimeActual = WobUtils.toDateTime("2013-07-29T12:30:00Z");
      //flight.DepartureDateTimeScheduled = WobUtils.toDateTime("2013-07-29T12:00:00Z");
      flight.DepartureGate = "B11";
      flight.DepartureTerminal = "B";
      flight.DepartureTimeZone = "America/New_York";
      flight.FlightNumber = "123";       
      flight.OnboardServices = new string[] {"Wifi"}; 
      flight.OperatingCarrierCode = "SO";
      flight.OperatingCarrierName = "SomeOther Airline";
      flight.OperatingFlightNumber = "456";
      flight.StatusCode = "delayed";

		  return flight;
	  }
	}
}