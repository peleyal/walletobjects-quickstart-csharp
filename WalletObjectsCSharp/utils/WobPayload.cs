using System;
using System.Collections.Generic;
using Google.Apis;
using Google.Apis.Json;
using Google.Apis.Walletobjects.v1;
using Google.Apis.Walletobjects.v1.Data;

namespace Utils
{
    /*
	using GenericJson = com.google.api.client.json.GenericJson;
	using JsonFactory = com.google.api.client.json.JsonFactory;
	using GsonFactory = com.google.api.client.json.gson.GsonFactory;
	using BoardingPassClass = com.google.api.services.walletobjects.model.BoardingPassClass;
	using BoardingPassObject = com.google.api.services.walletobjects.model.BoardingPassObject;
	using GenericClass = com.google.api.services.walletobjects.model.GenericClass;
	using GenericObject = com.google.api.services.walletobjects.model.GenericObject;
	using LoyaltyClass = com.google.api.services.walletobjects.model.LoyaltyClass;
	using LoyaltyObject = com.google.api.services.walletobjects.model.LoyaltyObject;
	using OfferClass = com.google.api.services.walletobjects.model.OfferClass;
	using OfferObject = com.google.api.services.walletobjects.model.OfferObject;
	using Gson = com.google.gson.Gson;
	using WebserviceResponse = com.google.wallet.objects.webservice.WebserviceResponse;
    */

	public class WobPayload
	{
	  private IList<GenericJson> loyaltyClasses = new List<GenericJson>();
	  private IList<GenericJson> offerClasses = new List<GenericJson>();
	  private IList<GenericJson> genericClasses = new List<GenericJson>();
	  private IList<GenericJson> boardingPassClasses = new List<GenericJson>();

	  private IList<GenericJson> loyaltyObjects = new List<GenericJson>();
	  private IList<GenericJson> offerObjects = new List<GenericJson>();
	  private IList<GenericJson> genericObjects = new List<GenericJson>();
	  private IList<GenericJson> boardingPassObjects = new List<GenericJson>();

	  private WebserviceResponse webserviceResponse;

	  [NonSerialized]
	  private Gson gson = new Gson();
	  [NonSerialized]
	  private JsonFactory jsonFactory = new GsonFactory();

	  public WobPayload()
	  {
	  }

	  public virtual void addObject(GenericJson @object)
	  {
		@object.Factory = jsonFactory;

		if (@object.GetType().IsSubclassOf(typeof(LoyaltyObject)))
		{
		  addLoyaltyObject(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else if (@object.GetType().IsSubclassOf(typeof(OfferObject)))
		{
		  addOfferObject(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else if (@object.GetType().IsSubclassOf(typeof(GenericObject)))
		{
		  addGenericObject(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else if (@object.GetType().IsSubclassOf(typeof(BoardingPassObject)))
		{
		  addBoardingPassObject(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else if (@object.GetType().IsSubclassOf(typeof(BoardingPassClass)))
		{
		  addBoardingPassClass(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else if (@object.GetType().IsSubclassOf(typeof(LoyaltyClass)))
		{
		  addLoyaltyClass(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else if (@object.GetType().IsSubclassOf(typeof(OfferClass)))
		{
		  addOfferClass(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else if (@object.GetType().IsSubclassOf(typeof(GenericClass)))
		{
		  addGenericClass(gson.fromJson(@object.ToString(), typeof(GenericJson)));
		}
		else
		{
		  throw new System.ArgumentException("Invalid Object type: " + @object.GetType());
		}
	  }

	  public virtual void addLoyaltyObject(GenericJson @object)
	  {
		loyaltyObjects.Add(@object);
	  }

	  public virtual IList<GenericJson> LoyaltyObjects
	  {
		  get
		  {
			return loyaltyObjects;
		  }
		  set
		  {
			this.loyaltyObjects = value;
		  }
	  }


	  public virtual void addOfferObject(GenericJson @object)
	  {
		offerObjects.Add(@object);
	  }

	  public virtual IList<GenericJson> OfferObjects
	  {
		  get
		  {
			return offerObjects;
		  }
		  set
		  {
			this.offerObjects = value;
		  }
	  }


	  public virtual void addGenericObject(GenericJson @object)
	  {
		genericObjects.Add(@object);
	  }

	  public virtual IList<GenericJson> GenericObjects
	  {
		  get
		  {
			return genericObjects;
		  }
		  set
		  {
			this.genericObjects = value;
		  }
	  }


	  public virtual WebserviceResponse Response
	  {
		  get
		  {
			return webserviceResponse;
		  }
		  set
		  {
			this.webserviceResponse = value;
		  }
	  }


	  public virtual IList<GenericJson> BoardingPassObjects
	  {
		  get
		  {
			return boardingPassObjects;
		  }
		  set
		  {
			this.boardingPassObjects = value;
		  }
	  }


	  public virtual void addBoardingPassObject(GenericJson @object)
	  {
		boardingPassObjects.Add(@object);
	  }

	  /// <returns> the loyaltyClasses </returns>
	  public virtual IList<GenericJson> LoyaltyClasses
	  {
		  get
		  {
			return loyaltyClasses;
		  }
		  set
		  {
			this.loyaltyClasses = value;
		  }
	  }


	  public virtual void addLoyaltyClass(GenericJson @object)
	  {
		loyaltyClasses.Add(@object);
	  }

	  /// <returns> the offerClasses </returns>
	  public virtual IList<GenericJson> OfferClasses
	  {
		  get
		  {
			return offerClasses;
		  }
		  set
		  {
			this.offerClasses = value;
		  }
	  }


	  public virtual void addOfferClass(GenericJson @object)
	  {
		offerClasses.Add(@object);
	  }
	  /// <returns> the genericClasses </returns>
	  public virtual IList<GenericJson> GenericClasses
	  {
		  get
		  {
			return genericClasses;
		  }
		  set
		  {
			this.genericClasses = value;
		  }
	  }


	  public virtual void addGenericClass(GenericJson @object)
	  {
		genericClasses.Add(@object);
	  }

	  /// <returns> the boardingPassClasses </returns>
	  public virtual IList<GenericJson> BoardingPassClasses
	  {
		  get
		  {
			return boardingPassClasses;
		  }
		  set
		  {
			this.boardingPassClasses = value;
		  }
	  }


	  public virtual void addBoardingPassClass(GenericJson @object)
	  {
		boardingPassClasses.Add(@object);
	  }

	}

}