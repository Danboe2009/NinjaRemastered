using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System.ComponentModel;
using UnityEngine.UI;
using GameAnalyticsSDK;

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour, IStoreListener
{
	private GameObject[] Boa;

	private static IStoreController m_StoreController;          // The Unity Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
	
	// Product identifiers for all products capable of being purchased: 
	// "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
	// counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
	// also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

	// General product identifiers for the consumable, non-consumable, and subscription products.
	// Use these handles in the code to reference which product to purchase. Also use these values 
	// when defining the Product Identifiers on the store. Except, for illustration purposes, the 
	// kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
	// specific mapping to Unity Purchasing's AddProduct, below.
	public static string kProductIDConsumable =    "consumable";   
	public static string kProductIDNonConsumable = "nonconsumable";
	public static string kProductIDSubscription =  "subscription"; 

	public static string TENDIAMONDS = "com.missingcontroller.ninjawarfare.10diamonds";
	public static string THIRTYDIAMONDS = "com.missingcontroller.ninjawarfare.30diamonds";
	public static string HUNDREDDIAMONDS = "com.missingcontroller.ninjawarfare.125diamonds";
	public static string THREEHUNDREDDIAMONDS = "com.missingcontroller.ninjawarfare.300diamonds";

	bool triggerResultEmail= false;
	bool resultEmailSucess;

	public Text resultText;

	String SMTPClient;
	int SMTPPort;
	String UserName;
	String UserPass;
	String To;
	String Subject;
	String Body;
	
	void Start()
	{
		SMTPClient = "smtp.gmail.com";
		SMTPPort = 587;
		UserName = "NinjaWarfareAlert";
		UserPass = "Danad209";
		To = "Danboe2009@gmail.com";
		Subject = "InApp Purchase";

		// If we haven't set up the Unity Purchasing reference
		if (m_StoreController == null)
		{
			// Begin to configure our connection to Purchasing
			InitializePurchasing();
		}
	}
	
	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}
		
		// Create a builder, first passing in a suite of Unity provided stores.
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
		
		// Add a product to sell / restore by way of its identifier, associating the general identifier
		// with its store-specific identifiers.
		builder.AddProduct (TENDIAMONDS , ProductType.Consumable);
		builder.AddProduct (THIRTYDIAMONDS, ProductType.Consumable);
		builder.AddProduct (HUNDREDDIAMONDS, ProductType.Consumable);
		builder.AddProduct (THREEHUNDREDDIAMONDS, ProductType.Consumable);
	   
		// Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
		// and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
		UnityPurchasing.Initialize(this, builder);
	}
	
	
	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}

public void BuyItem(String item)
{
	BuyProductID (item);
}
	
	void BuyProductID(string productId)
	{
		// If Purchasing has been initialized ...
		if (IsInitialized())
		{
			// ... look up the Product reference with the general product identifier and the Purchasing 
			// system's products collection.
			Product product = m_StoreController.products.WithID(productId);
			
		Debug.Log (product.transactionID + " is avaliable to buy " + product.availableToPurchase);
			
			// If the look up found a product for this device's store and that product is ready to be sold ... 
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
				// asynchronously.
				m_StoreController.InitiatePurchase(product);
			}
			// Otherwise ...
			else
			{
				// ... report the product look-up failure situation  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		// Otherwise ...
		else
		{
			// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
			// retrying initiailization.
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}
	
	
	// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
	// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}
		
		// If we are running on an Apple device ... 
		if (Application.platform == RuntimePlatform.IPhonePlayer || 
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");
			
			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
			// the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then 
				// no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}
	
	
	//  
	// --- IStoreListener
	//
	
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");
		
		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}
	
	
	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}
	
	
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, TENDIAMONDS, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			Debug.Log("10 Diamonds Added.");
			PlayerPrefs.SetInt("Diamonds", (PlayerPrefs.GetInt("Diamonds") + 10));
			PlayerPrefs.SetInt ("NoAds", 1);
			ClearScreen ("10 Diamonds Added.");
			//sendEmail ("1 Dollar Purchased.");
			GameAnalytics.NewBusinessEventGooglePlay("USD",1,args.purchasedProduct.definition.id,"10Diamonds",args.purchasedProduct.definition.id,null,null);
		}
		else if (String.Equals(args.purchasedProduct.definition.id, THIRTYDIAMONDS, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			Debug.Log("30 Diamonds Added.");
			PlayerPrefs.SetInt("Diamonds", (PlayerPrefs.GetInt("Diamonds") + 30));
			PlayerPrefs.SetInt ("NoAds", 1);
			ClearScreen ("30 Diamonds Added.");
			//sendEmail ("2 Dollars Purchased.");
			GameAnalytics.NewBusinessEventGooglePlay("USD",2,args.purchasedProduct.definition.id,"30Diamonds",args.purchasedProduct.definition.id,null,null);
		}
		else if (String.Equals(args.purchasedProduct.definition.id, HUNDREDDIAMONDS, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			Debug.Log("125 Diamonds Added.");
			PlayerPrefs.SetInt("Diamonds", (PlayerPrefs.GetInt("Diamonds") + 125));
			PlayerPrefs.SetInt ("NoAds", 1);
			ClearScreen ("125 Diamonds Added.");
			//sendEmail ("5 Dollars Purchased.");
			GameAnalytics.NewBusinessEventGooglePlay("USD",5,args.purchasedProduct.definition.id,"125Diamonds",args.purchasedProduct.definition.id,null,null);
		}
		else if (String.Equals(args.purchasedProduct.definition.id, THREEHUNDREDDIAMONDS, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			Debug.Log("300 Diamonds Added.");
			PlayerPrefs.SetInt("Diamonds", (PlayerPrefs.GetInt("Diamonds") + 300));
			PlayerPrefs.SetInt ("NoAds", 1);
			ClearScreen ("300 Diamonds Added.");
			//sendEmail ("10 Dollars Purchased.");
			GameAnalytics.NewBusinessEventGooglePlay("USD",10,args.purchasedProduct.definition.id,"300Diamonds",args.purchasedProduct.definition.id,null,null);
		}
		// Or ... an unknown product has been purchased by this user. Fill in additional products here....
		else 
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
		}

		// Return a flag indicating whether this product has completely been received, or if the application needs 
		// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
		// saving purchased products to the cloud, and when that save is delayed. 
		return PurchaseProcessingResult.Complete;
	}
	
	
	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
		// this reason with the user to guide their troubleshooting actions.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
		ClearScreen ("Purchase failed.");
	}

	private void ClearScreen(string MesTex)
	{
		Boa = GameObject.FindGameObjectsWithTag("Board");
		for(int i = 0; i < Boa.Length; i++)
		{
			Destroy(Boa[i]);
		}
		GameObject box = (GameObject)Instantiate(Resources.Load("MessageBox"),new Vector3(0,6,0), Quaternion.Euler(90,0,0));
		GameObject Mess = (GameObject) Instantiate(Resources.Load("Message"), new Vector3(0,6.2f,0), Quaternion.Euler(90,0,0));
		Mess.GetComponent<TextMesh> ().text = MesTex;
	}

	public void sendEmail(string body)
	{
		EmailSenderSender.emailSettings.STMPClient = SMTPClient;
		EmailSenderSender.emailSettings.SMTPPort = SMTPPort;
		EmailSenderSender.emailSettings.UserName = UserName;
		EmailSenderSender.emailSettings.UserPass = UserPass;

		EmailSenderSender.Send(To, Subject, body, "", SendCompletedCallback);
	}

	private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
	{
		if (e.Cancelled || e.Error != null)
		{
			print("Email not sent: " + e.Error.ToString());

			resultEmailSucess = false;
			triggerResultEmail = true;
		}
		else
		{
			print("Email successfully sent.");

			resultEmailSucess = true;
			triggerResultEmail = true;
		}
	}
}