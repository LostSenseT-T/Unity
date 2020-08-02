using System;
using UnityEngine;
using UnityEngine.Purchasing;
public class PurshaseManager : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;
    public AudioSource donateaudio;
    public const string pMoney100 = "money_100";
    public const string pMoney400 = "money_400";
    public const string pMoney1500 = "money_1500";
    public const string pMoney4000 = "money_4000";
    public const string pNoAds = "no_ads";

    public const string pMoney100AppStore = "app_money_100";
    public const string pMoney400AppStore = "app_money_400";
    public const string pMoney1500AppStore = "app_money_1500";
    public const string pMoney4000AppStore = "app_money_4000";
    public const string pNoAdsAppStore = "app_no_ads";

    public const string pMoney100GooglePlay = "gp_money_100";
    public const string pMoney400GooglePlay = "gp_money_400";
    public const string pMoney1500GooglePlay = "gp_money_1500";
    public const string pMoney4000GooglePlay = "gp_money_4000";
    public const string pNoAdsGooglePlay = "gp_no_ads";

    void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(pMoney100, ProductType.Consumable, new IDs() { { pMoney100AppStore, AppleAppStore.Name }, { pMoney100GooglePlay, GooglePlay.Name } });
        builder.AddProduct(pMoney400, ProductType.Consumable, new IDs() { { pMoney400AppStore, AppleAppStore.Name }, { pMoney400GooglePlay, GooglePlay.Name } });
        builder.AddProduct(pMoney1500, ProductType.Consumable, new IDs() { { pMoney1500AppStore, AppleAppStore.Name }, { pMoney1500GooglePlay, GooglePlay.Name } });
        builder.AddProduct(pMoney4000, ProductType.Consumable, new IDs() { { pMoney4000AppStore, AppleAppStore.Name }, { pMoney4000GooglePlay, GooglePlay.Name } });
        builder.AddProduct(pNoAds, ProductType.NonConsumable, new IDs() { { pNoAdsAppStore, AppleAppStore.Name }, { pNoAdsGooglePlay, GooglePlay.Name } });

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void BuyProductID(string productId)
    {
        try
        {
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productId);

                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
                    m_StoreController.InitiatePurchase(product);
                }
                else
                {
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }
        catch (Exception e)
        {
            Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) =>
            {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: Completed!");

        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        if (String.Equals(args.purchasedProduct.definition.id, pMoney100, StringComparison.Ordinal))
        {
            Save.emeralds += 100;
            Save.donat += 1;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, pNoAds, StringComparison.Ordinal))
        {
            //Action for no ads
        }
        else if (String.Equals(args.purchasedProduct.definition.id, pMoney400, StringComparison.Ordinal))
        {
            Save.emeralds += 400;
            Save.donat += 3;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, pMoney1500, StringComparison.Ordinal))
        {
            Save.emeralds += 1500;
            Save.donat += 10;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, pMoney4000, StringComparison.Ordinal))
        {
            Save.emeralds += 4000;
            Save.donat += 20;
        }
        donateaudio.Play();
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}