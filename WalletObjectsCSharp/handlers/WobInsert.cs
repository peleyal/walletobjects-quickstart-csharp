namespace com.google.wallet.objects.servlets
{



	using GenericJson = com.google.api.client.json.GenericJson;
	using Walletobjects = com.google.api.services.walletobjects.Walletobjects;
	using BoardingPassClass = com.google.api.services.walletobjects.model.BoardingPassClass;
	using GenericClass = com.google.api.services.walletobjects.model.GenericClass;
	using LoyaltyClass = com.google.api.services.walletobjects.model.LoyaltyClass;
	using OfferClass = com.google.api.services.walletobjects.model.OfferClass;
	using WobCredentials = com.google.wallet.objects.utils.WobCredentials;
	using WobUtils = com.google.wallet.objects.utils.WobUtils;
	using BoardingPass = com.google.wallet.objects.verticals.BoardingPass;
	using Generic = com.google.wallet.objects.verticals.Generic;
	using Loyalty = com.google.wallet.objects.verticals.Loyalty;
	using Offer = com.google.wallet.objects.verticals.Offer;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("serial") public class WobInsertServlet extends HttpServlet
	public class WobInsertServlet : HttpServlet
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void doGet(HttpServletRequest req, HttpServletResponse resp) throws java.io.IOException
	  public virtual void doGet(HttpServletRequest req, HttpServletResponse resp)
	  {

		ServletContext context = ServletContext;

		WobCredentials credentials = new WobCredentials(context.getInitParameter("ServiceAccountId"), context.getInitParameter("ServiceAccountPrivateKey"), context.getInitParameter("ApplicationName"), context.getInitParameter("IssuerId"));

		WobUtils utils = null;
		Walletobjects client = null;
		try
		{
		  utils = new WobUtils(credentials);
		  client = utils.Client;
		}
		catch (KeyStoreException e)
		{
		  // TODO Auto-generated catch block
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		}
		catch (IOException e)
		{
		  // TODO Auto-generated catch block
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		}
		catch (GeneralSecurityException e)
		{
		  // TODO Auto-generated catch block
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
		}

		string type = req.getParameter("type");

		GenericJson response = null;

		if (type.Equals("loyalty"))
		{
		  LoyaltyClass loyaltyClass = Loyalty.generateLoyaltyClass(utils.IssuerId, "LoyaltyClass");
		  response = client.loyaltyclass().insert(loyaltyClass).execute();
		}
		else if (type.Equals("offer"))
		{
		  OfferClass offerClass = Offer.generateOfferClass(utils.IssuerId, "OfferClass");
		  response = client.offerclass().insert(offerClass).execute();
		}
		else if (type.Equals("generic"))
		{
		  GenericClass genericClass = Generic.generateGenericClass(utils.IssuerId, "GenericClass");
		  response = client.genericclass().insert(genericClass).execute();
		}
		/*else if (type.equals("boardingpass")) {
		  BoardingPassClass boardingPass = BoardingPass.generateBoardingPassClass(
		      utils.getIssuerId(), "BoardingPassClass");
		  response = client.boardingpassclass().insert(boardingPass).execute();
		}*/

		PrintWriter @out = resp.Writer;
		@out.write(response.ToString());
	  }
	}

}