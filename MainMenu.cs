    using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI; 
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using Firebase;
using Firebase.Auth;
using Firebase.Unity.Editor;
using Firebase.Database;

   





public class MainMenu : MonoBehaviour
{  

    private BannerView bannerView;
    private BannerView bannerLoadingScreen;
    public GameObject loadingScreen;
    public Slider slider;
    private RewardBasedVideoAd rewardBasedVideo;
    public GameObject settingspanel;
    public GameObject mainmenu;
    public GameObject level_panel;
    public GameObject purchase_panel;
    private float timer,lerp=3;
    private string authCode;
    //Firebase.FirebaseApp app;
    public static DatabaseReference reference;
  
    public static Firebase.Auth.FirebaseUser user;
    public static int coins;
    private int retreivedCoinsData;

    


    void Awake(){
       AuthenticateUser();
      // firebaseauth();
        // if (!Social.localUser.authenticated){AuthenticateUser(); firebaseauth();}else return;
      
    }
       public void Start()
    {

         FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://raw-racing-11168963.firebaseio.com/");
         reference = FirebaseDatabase.DefaultInstance.RootReference;
       


        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
        this.RequestBannerLoadingScreen();
        bannerLoadingScreen.Hide();
        
        bannerView.Hide();

        //reward video
        this.rewardBasedVideo=RewardBasedVideoAd.Instance;
        this.RequestRewardBasedVideo();

        //playgames services
        //PlayerPrefs.GetInt("PlayGamesServices",0);

       // rewardBasedVideo.OnAdRewarded+=HandleOnAdRewarded;
        timer=0;

        LeanTween.moveX(mainmenu,Screen.width/2,0.4f).setDelay( 0.5f);
       // Firebaseauth();



      

       
       
        


        
        
    }

    void Update(){
        
        //messy button management;
            if(CrossPlatformInputManager.GetButtonDown("StartButton")){
                //LoadLevel(1);
                LeanTween.moveY(level_panel,Screen.height/2,0.4f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveY(mainmenu,2*Screen.height,0.4f); 
                

            }//SceneManager.LoadScene("Level-0"); 
            /*if(CrossPlatformInputManager.GetButtonDown("LeaderBoard")){
                ShowLeaderboardUI();
                print("leaderboard");
               
            }*/
          

            if(CrossPlatformInputManager.GetButtonDown("Settings")){settingspanel.SetActive(true);

            
           
            }
           
            if(CrossPlatformInputManager.GetButtonDown("BackButton")){
                LeanTween.moveY(level_panel,-Screen.height,0.4f);
                LeanTween.moveY(mainmenu,Screen.height/2,0.4f);
                }
           
        
            /*if (Input.GetKey(KeyCode.Escape)||CrossPlatformInputManager.GetButtonDown("GoBack"))
            {
               settingspanel.SetActive(false);
               LeanTween.scale(settingspanel,new Vector3(0,0,0),0.25f);
 
                return;
            }*/

            if(CrossPlatformInputManager.GetButtonDown("Purchase")){
                LeanTween.moveY(purchase_panel,Screen.height/2,0.4f).setEase(LeanTweenType.easeOutBounce);
                LeanTween.moveX(mainmenu,2*Screen.width,0.4f);
               
                
            }

            if(CrossPlatformInputManager.GetButtonDown("Back")){
                LeanTween.moveY(purchase_panel,2*Screen.height,0.4f).setEase(LeanTweenType.easeOutBounce);
                LeanTween.moveX(mainmenu,Screen.width/2,0.4f);
                LeanTween.moveY(mainmenu,Screen.height/2,0.4f);
                LeanTween.moveY(level_panel,-Screen.height,0.4f);


                
               
            }

        


           
    }

      private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-6305741283302796/4182668578";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
          
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    private void RequestBannerLoadingScreen(){
          #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-6305741283302796/2691215828";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.bannerLoadingScreen=new BannerView(adUnitId, AdSize.MediumRectangle, AdPosition.Center);
        AdRequest request= new AdRequest.Builder().Build();

        this.bannerLoadingScreen.LoadAd(request);
    }

        private void RequestRewardBasedVideo(){
            #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-6305741283302796/1273643632";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
        }


    public void AuthenticateUser(){
        
        PlayGamesClientConfiguration config=new PlayGamesClientConfiguration.Builder().RequestServerAuthCode(false /* Don't force refresh */).Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        UnityEngine.Social.localUser.Authenticate((bool success)=>{
        if(success==true){
            //firebase login
            authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
            if(string.IsNullOrEmpty(authCode)){Debug.LogError("signed into playgames services but failed to get auth code");}
           // Debug.LogFormat("auth code is {0}",authCode);
            Debug.Log("Logged in to Google Play Games Services");

            Firebase.Auth.Credential credential =
            Firebase.Auth.PlayGamesAuthProvider.GetCredential(authCode);
   
    
            auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled) {
            Debug.LogError("SignInWithCredentialAsync was canceled.");

            return;
            }
            if (task.IsFaulted) {
            Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
            return;
             }
    
            Firebase.Auth.FirebaseUser newUser = task.Result;

             user = auth.CurrentUser;
            
            if (user != null) {
            string playerName = user.DisplayName;

  // The user's Id, unique to the Firebase project.
  // Do NOT use this value to authenticate with your backend server, if you
  // have one; use User.TokenAsync() instead.
            string uid = user.UserId;
}   
Debug.Log("trying to retreive data from firebase");
        FirebaseDatabase.DefaultInstance
      .GetReference("users")
      .GetValueAsync().ContinueWith(task2 => {
        if (task2.IsFaulted) {
          // Handle the error...
          Debug.Log("cant get reference to server");
        }
        else if (task2.IsCompleted) {
          DataSnapshot snapshot = task2.Result;

          
          // Do something with snapshot...
          if(snapshot.Child(user.UserId).Value==null){writeNewUser(user.UserId,user.DisplayName,0);Debug.Log("snapshot is null,adding new user to database");}
          FirebaseDatabase.DefaultInstance
         .GetReference("users")
          .GetValueAsync().ContinueWith(task1 => {
          if (task1.IsFaulted) {
          // Handle the error...
        }
           else if (task1.IsCompleted) {

              
          DataSnapshot snapshot1 = task1.Result;
          // Do something with snapshot...
          
          Debug.Log("user authenticated");
          
         // string json = JsonUtility.FromJson(snapshot);
        
        string data=snapshot1.Child(user.UserId).Child("purchasedcoins").Value.ToString();

        Debug.Log("snapshot recovered");
        
        Debug.Log(data);
        retreivedCoinsData=int.Parse(data);
        Debug.LogFormat("snapshot is:{0}",retreivedCoinsData);

        PlayerPrefs.SetInt("Boughtcoins",retreivedCoinsData);
          Debug.LogFormat("setting playerprefs: {0}",PlayerPrefs.GetInt("Boughtcoins",0));

      
    writeNewUser(user.UserId,user.DisplayName,PlayerPrefs.GetInt("Boughtcoins",0));
        


        
        }
      });
        }
      });




        
        

      
          
           // Debug.LogFormat("User signed in successfully: {0} ({1})",
          //  newUser.DisplayName, newUser.UserId);
});
            
            
        }
        else{

            Debug.LogError("Unable to sign in to Google Play Games Srvices");
             
        }}
        );

          

    }

    public class User {
    public string username;
    public int purchasedcoins;
   

    public User() {
    }

    public User(string username,int purchasedcoins) {
        this.username = username;
        this.purchasedcoins=purchasedcoins;
      
    }
}


    public static void writeNewUser(string userId, string name,int coins) {
    User user = new User(name,coins);
    string json = JsonUtility.ToJson(user);

    reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
}

  



    public static void PostToLeaderboard(int newScore){//long

        Social.ReportScore(newScore,GPGSIds.leaderboard_high_score,(bool success)=>{

          //  if(success)Debug.Log("posted new score to leaderboard");
           // else Debug.LogError("Unable to post new score to leaderboard"); 
        });
    }

    public static void ShowLeaderboardUI(){
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }

    public  void LoadLevel(int SceneIndex){
        StartCoroutine(LoadAsynchronously(SceneIndex));

    }

    IEnumerator LoadAsynchronously(int SceneIndex){
        loadingScreen.SetActive(true);
        bannerLoadingScreen.Show();
        bannerView.Show();
        while(timer<3)
        {timer+=Time.deltaTime;
        
         slider.value=Mathf.Lerp(0,0.96f,timer/lerp);
         yield return null;
        }
        bannerLoadingScreen.Destroy();
       
        
        AsyncOperation operation =SceneManager.LoadSceneAsync(SceneIndex);
        
       
        
       
    }
  

   

        public void HandleOnAdRewarded(object sender, Reward args){
            //double amount=args.Amount;
         //  int coin=PlayerPrefs.GetInt("Boughtcoins",0)+1000;//(int)amount
             PlayerPrefs.SetInt("Boughtcoins",  PlayerPrefs.GetInt("Boughtcoins",0)+2000);
            // writeNewUser(user.UserId,user.DisplayName,PlayerPrefs.GetInt("Boughtcoins",0));
             rewardBasedVideo.OnAdRewarded-=HandleOnAdRewarded;
             
        }



        // load levels

         public void level1(){
        LoadLevel(1);
        
        LeanTween.moveY(level_panel,-Screen.height,0.1f);
    }

         public void level2(){
             if(PlayerPrefs.GetInt("2_unlock",0)==1){
                 //loadlevel2
                 LoadLevel(2);
                 LeanTween.moveY(level_panel,-Screen.height,0.1f);
             }
         }

         public void level3(){
              if(PlayerPrefs.GetInt("3_unlock",0)==1){
                 //loadlevel2
                 LoadLevel(3);
                 LeanTween.moveY(level_panel,-Screen.height,0.1f);
             }
         }

         public void level4(){
             if(PlayerPrefs.GetInt("4_unlock",0)==1){
                 LoadLevel(4);
                 LeanTween.moveY(level_panel,-Screen.height,0.1f);
             }
         }

        //purchase buttons

        public void reward_purchase(){
            if(rewardBasedVideo.IsLoaded()){
                     rewardBasedVideo.OnAdRewarded+=HandleOnAdRewarded;
                    rewardBasedVideo.Show();
                }
                else{
                    this.RequestRewardBasedVideo();
                   
                    SSTools.ShowMessage("ad not loaded,try again",SSTools.Position.bottom,SSTools.Time.twoSecond);
                }

        }

        public void Leaderboardbutton(){
            ShowLeaderboardUI();
            print("leaderboard");
        }

       public  void SettingsBack(){
            settingspanel.SetActive(false);
        }
}
