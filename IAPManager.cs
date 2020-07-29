using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI; 
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //Step 1 create your products

    private string coin50="coin_50";
    private string coin100="coin_100";
    private string coin200="coin_200";
    private string coin500="coin_500";

    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(coin50,ProductType.Consumable);
        builder.AddProduct(coin100,ProductType.Consumable);
        builder.AddProduct(coin200,ProductType.Consumable);
        builder.AddProduct(coin500,ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods
    public void Buycoin50(){
        BuyProductID(coin50);
    }
     public void Buycoin100(){
        BuyProductID(coin100);
    }

 public void Buycoin200(){
        BuyProductID(coin200);
    }

 public void Buycoin500(){
        BuyProductID(coin500);
    }




    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, coin50, StringComparison.Ordinal))
        {
            Debug.Log("reward 5000 coins");
            PlayerPrefs.SetInt("Boughtcoins",PlayerPrefs.GetInt("Boughtcoins",0)+5000);
            MainMenu.writeNewUser(MainMenu.user.UserId,MainMenu.user.DisplayName,PlayerPrefs.GetInt("Boughtcoins",0));
        }
        else  if (String.Equals(args.purchasedProduct.definition.id,coin100, StringComparison.Ordinal))
        {
            Debug.Log("reward 12000 coins");
            PlayerPrefs.SetInt("Boughtcoins",PlayerPrefs.GetInt("Boughtcoins",0)+12000);
          MainMenu.writeNewUser(MainMenu.user.UserId,MainMenu.user.DisplayName,PlayerPrefs.GetInt("Boughtcoins",0));
        }
         else  if (String.Equals(args.purchasedProduct.definition.id,coin200, StringComparison.Ordinal))
        {
            Debug.Log("reward 25000 coins");
            PlayerPrefs.SetInt("Boughtcoins",PlayerPrefs.GetInt("Boughtcoins",0)+25000);
            MainMenu.writeNewUser(MainMenu.user.UserId,MainMenu.user.DisplayName,PlayerPrefs.GetInt("Boughtcoins",0));
        }
         else  if (String.Equals(args.purchasedProduct.definition.id,coin500, StringComparison.Ordinal))
        {
            Debug.Log("reward 60000 coins");
            PlayerPrefs.SetInt("Boughtcoins",PlayerPrefs.GetInt("Boughtcoins",0)+60000);
            MainMenu.writeNewUser(MainMenu.user.UserId,MainMenu.user.DisplayName,PlayerPrefs.GetInt("Boughtcoins",0));
        }
        else
        {
            Debug.Log("Purchase Failed");
            
        }
        return PurchaseProcessingResult.Complete;
    }










    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
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

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
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
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}