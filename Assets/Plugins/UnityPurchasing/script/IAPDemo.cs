#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// You must obfuscate your secrets using Window > Unity IAP > Receipt Validation Obfuscator
// before receipt validation will compile in this sample.
// #define RECEIPT_VALIDATION
#endif

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using UnityEngine.UI;
#if RECEIPT_VALIDATION
using UnityEngine.Purchasing.Security;
#endif

/// <summary>
/// An example of basic Unity IAP functionality.
/// To use with your account, configure the product ids (AddProduct)
/// and Google Play key (SetPublicKey).
/// </summary>
[AddComponentMenu("Unity IAP/Demo")]
public class IAPDemo : MonoBehaviour, IStoreListener
{
	// Unity IAP objects 
	private IStoreController m_Controller;
	private IAppleExtensions m_AppleExtensions;
	private ISamsungAppsExtensions m_SamsungExtensions;

	private int m_SelectedItemIndex = -1; // -1 == no product
	private bool m_PurchaseInProgress;

	private Selectable m_InteractableSelectable; // Optimization used for UI state management
	private bool m_IsSamsungAppsStoreSelected;

	#if RECEIPT_VALIDATION
	private CrossPlatformValidator validator;
	#endif

	/// <summary>
	/// This will be called when Unity IAP has finished initialising.
	/// </summary>
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		m_Controller = controller;

		Debug.Log("Available items:");
		foreach (var item in controller.products.all)
		{
			if (item.availableToPurchase)
			{
				Debug.Log(string.Join(" - ",
					new[]
					{
						item.metadata.localizedTitle,
						item.metadata.localizedDescription,
						item.metadata.isoCurrencyCode,
						item.metadata.localizedPrice.ToString(),
						item.metadata.localizedPriceString,
						item.transactionID,
						item.receipt
					}));
			}
		}

		// Prepare model for purchasing
		if (m_Controller.products.all.Length > 0) 
		{
			m_SelectedItemIndex = 0;
		}


	}

	/// <summary>
	/// This will be called when a purchase completes.
	/// </summary>
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
	{
		Debug.Log("Purchase OK: " + e.purchasedProduct.definition.id);
		Debug.Log("Receipt: " + e.purchasedProduct.receipt);

		m_PurchaseInProgress = false;
		return PurchaseProcessingResult.Complete;
	}

	/// <summary>
	/// This will be called is an attempted purchase fails.
	/// </summary>
	public void OnPurchaseFailed(Product item, PurchaseFailureReason r)
	{
		Debug.Log("Purchase failed: " + item.definition.id);
		Debug.Log(r);

		m_PurchaseInProgress = false;
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("Billing failed to initialize!");
		switch (error)
		{
			case InitializationFailureReason.AppNotKnown:
				Debug.LogError("Is your App correctly uploaded on the relevant publisher console?");
				break;
			case InitializationFailureReason.PurchasingUnavailable:
				// Ask the user if billing is disabled in device settings.
				Debug.Log("Billing disabled!");
				break;
			case InitializationFailureReason.NoProductsAvailable:
				// Developer configuration error; check product metadata.
				Debug.Log("No products available for purchase!");
				break;
		}
	}

	public void Awake()
	{
		var module = StandardPurchasingModule.Instance();

		// The FakeStore supports: no-ui (always succeeding), basic ui (purchase pass/fail), and 
		// developer ui (initialization, purchase, failure code setting). These correspond to 
		// the FakeStoreUIMode Enum values passed into StandardPurchasingModule.useFakeStoreUIMode.
		module.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;

		var builder = ConfigurationBuilder.Instance(module);

		// Define our products.
		// In this case our products have the same identifier across all the App stores,
		// except on the Mac App store where product IDs cannot be reused across both Mac and
		// iOS stores.
		// So on the Mac App store our products have different identifiers,
		// and we tell Unity IAP this by using the IDs class.
		builder.AddProduct ("com.missingcontroller.ninjawarfare.10diamonds", ProductType.Consumable);
		builder.AddProduct ("com.missingcontroller.ninjawarfare.30diamonds", ProductType.Consumable);
		builder.AddProduct ("com.missingcontroller.ninjawarfare.125diamonds", ProductType.Consumable);
		builder.AddProduct ("com.missingcontroller.ninjawarfare.300diamonds", ProductType.Consumable);

		// Now we're ready to initialize Unity IAP.
		UnityPurchasing.Initialize(this, builder);
	}
		
	private void OnDeferred(Product item)
	{
		Debug.Log("Purchase deferred: " + item.definition.id);
	}
		
}