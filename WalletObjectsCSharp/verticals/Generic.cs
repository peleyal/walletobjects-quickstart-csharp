using System.Collections.Generic;
using Google.Apis;
using Google.Apis.Walletobjects.v1;
using Google.Apis.Walletobjects.v1.Data;

namespace Verticals
{

    /*
	using Barcode = com.google.api.services.walletobjects.model.Barcode;
	using GenericClass = com.google.api.services.walletobjects.model.GenericClass;
	using GenericObject = com.google.api.services.walletobjects.model.GenericObject;
	using Image = com.google.api.services.walletobjects.model.Image;
	using LatLongPoint = com.google.api.services.walletobjects.model.LatLongPoint;
	using RenderSpec = com.google.api.services.walletobjects.model.RenderSpec;
	using TypedValue = com.google.api.services.walletobjects.model.TypedValue;
	using Uri = com.google.api.services.walletobjects.model.Uri;
	using WalletObjectMessage = com.google.api.services.walletobjects.model.WalletObjectMessage;
    */
   
	public class Generic
	{

	  public static GenericClass generateGenericClass(string issuerId, string classId)
	  {
		// Define general messages
		IList<WalletObjectMessage> messages = new List<WalletObjectMessage>();
		WalletObjectMessage message = new WalletObjectMessage();
        message.Header = "Welcome";
        message.Body = "Welcome to Banconrista Library!";

        Uri imageUri = new Uri();
        imageUri.UriValue = "https://ssl.gstatic.com/codesite/ph/images/search-48.gif"; 
        Image messageImage = new Image();
        messageImage.SourceUri = imageUri;
        message.Image = messageImage;

        Uri actionUri = new Uri();
        actionUri.UriValue = "http://baconrista.com"; 
        message.ActionUri = actionUri;

		messages.Add(message);

		// Define Class IssuerData
		TypedValue issuerData = new TypedValue();
		TypedValue gExpanded = new TypedValue();

		TypedValue textModule = new TypedValue();
		textModule.put("header", (new TypedValue()).setString("Library Benefits"));
		textModule.put("body", new TypedValue()
		  .setString("For every 3 books you read you get a free latte as part" + " of our reading program."));

		TypedValue linksModule = new TypedValue();

		linksModule.put("uri0", (new TypedValue()).setUri((new Uri()).setUri("http://www.example.com").setDescription("Example")));
		linksModule.put("uri1", (new TypedValue()).setUri((new Uri()).setUri("http://www.baconrista.com").setDescription("Library Details")));

		TypedValue infoModule = new TypedValue();

		infoModule.put("fontColor", (new TypedValue()).setString("#FF3300"));
		infoModule.put("backgroundColor", (new TypedValue()).setString("#ABABAB"));
		infoModule.put("row0", (new TypedValue()).set("col0", new TypedValue()
				.set("label", (new TypedValue()).setString("Label 0")).set("value", (new TypedValue()).setString("Value 0"))).set("col1", new TypedValue()
				  .set("label", (new TypedValue()).setString("Label 1")).set("value", (new TypedValue()).setString("Value1"))));
		infoModule.put("row1", (new TypedValue()).set("col0", new TypedValue()
				.set("label", (new TypedValue()).setString("Label 0")).set("value", (new TypedValue()).setString("Value 0"))).set("col1", new TypedValue()
				  .set("label", (new TypedValue()).setString("Label 1")).set("value", (new TypedValue()).setString("Value1"))));

		gExpanded.put("textModule", textModule);
		gExpanded.put("linksModule", linksModule);
		gExpanded.put("infoModule", infoModule);

		issuerData.put("g_expanded", gExpanded);
		IList<RenderSpec> renderSpec = new List<RenderSpec>();

		RenderSpec listRenderSpec = (new RenderSpec()).setViewName("g_list").setTemplateFamily("1.generic1_list");
		RenderSpec expandedRenderSpec = (new RenderSpec()).setViewName("g_expanded").setTemplateFamily("1.generic1_expanded");
		renderSpec.Add(listRenderSpec);
		renderSpec.Add(expandedRenderSpec);

		// Define Geofence locations
		IList<LatLongPoint> locations = new List<LatLongPoint>();
		locations.Add((new LatLongPoint()).setLatitude(37.422601).setLongitude(-122.085286));

		GenericClass wobClass = (new GenericClass()).setId(issuerId + "." + classId).setVersion(1L).setIssuerName("Baconrista Library").setTitle("Baconrista Library").setDescription("Baconrista Library Card").setHomepageUri((new Uri()).setUri("https://www.example.com")).setTitleImage((new Image()).setSourceUri(new Uri()
				.setUri("http://www.google.com/landing/chrome/ugc/chrome-icon.jpg"))).setRenderSpecs(renderSpec).setMessages(messages).setReviewStatus("draft").setAllowMultipleUsersPerObject(true).setLocations(locations).setIssuerData(issuerData);

		return wobClass;
	  }

	  public static GenericObject generateGenericObject(string issuerId, string classId, string objectId)
	  {

		Barcode barcode = (new Barcode()).setType("qrCode").setValue("28343E3").setAlternateText("12345").setLabel("Member Id");

		TypedValue objectIssuerData = new TypedValue();
		TypedValue objectGExpanded = new TypedValue();

		TypedValue titleModule = new TypedValue();
		titleModule.put("row0", (new TypedValue()).set("col0", (new TypedValue()).set("label", (new TypedValue()).setString("Library Member")).set("value", (new TypedValue()).setString("Joe Smith"))));

		TypedValue objectInfoModule = new TypedValue();

		TypedValue rowZero = new TypedValue();

		TypedValue colZero = new TypedValue();
		colZero.put("label", (new TypedValue()).setString("Local Store"));
		colZero.put("value", (new TypedValue()).setString("Mountain View"));

		TypedValue colOne = new TypedValue();
		colOne.put("label", (new TypedValue()).setString("Books Borrowed"));
		colOne.put("value", (new TypedValue()).setInt(2));

		rowZero.put("col0", colZero);
		rowZero.put("col1", colOne);

		objectInfoModule.put("row0", rowZero);
		objectGExpanded.put("infoModule", objectInfoModule);
		objectGExpanded.put("titleModule", titleModule);

		objectIssuerData.put("g_expanded", objectGExpanded);

		IList<WalletObjectMessage> messages = new List<WalletObjectMessage>();
		WalletObjectMessage message = (new WalletObjectMessage()).setHeader("Hi Joe").setBody("Your book is due back in 2 days!").setImage((new Image()).setSourceUri(new Uri()
				  .setUri("https://ssl.gstatic.com/codesite/ph/images/search-48.gif"))).setActionUri((new Uri()).setUri("http://baconrista.com"));
		messages.Add(message);

		GenericObject @object = (new GenericObject()).setClassId(issuerId + "." + classId).setId(issuerId + "." + objectId).setVersion(1L).setState("active").setBarcode(barcode).setMessages(messages).setIssuerData(objectIssuerData);

		return @object;
	  }
	}

}