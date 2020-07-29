using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu_score : MonoBehaviour
{
    // Start is called before the first frame update private TextMeshProUGUI changetext;
  private TextMeshProUGUI changetext;
  
  private int l2=0,l3=0,l4=0;//,l5=0,l6=0,l7=0,l8=0,l9=0,l10=0;

    void Start(){
         changetext=GetComponent<TextMeshProUGUI>();
         PlayerPrefs.GetInt("Leaderboard",0);
         PlayerPrefs.GetInt("Boughtcoins",0);
         PlayerPrefs.GetInt("Totalcoins",0);

         //mDatabaseRef.Child("users").Child(userId).Child("Purchasedcoins").SetValueAsync(PlayerPrefs.GetInt("Boughtcoins",0));
    }

    void Update(){
        if(PlayerPrefs.GetInt("2_unlock")==1)l2=10000;
         if(PlayerPrefs.GetInt("3_unlock")==1)l3=10000;
         if(PlayerPrefs.GetInt("4_unlock")==1)l4=10000;


        PlayerPrefs.SetInt("Leaderboard",PlayerPrefs.GetInt("level1_score",0)+PlayerPrefs.GetInt("level2_score",0)+PlayerPrefs.GetInt("level3_score",0)+PlayerPrefs.GetInt("level4_score",0));

        PlayerPrefs.SetInt("Totalcoins",PlayerPrefs.GetInt("Boughtcoins",0)+PlayerPrefs.GetInt("Leaderboard",0)-l2-l3-l4);
        changetext.text=PlayerPrefs.GetInt("Totalcoins",0).ToString();
        

        MainMenu.PostToLeaderboard(PlayerPrefs.GetInt("Leaderboard",0));


    }
}
