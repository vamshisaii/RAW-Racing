using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//LEVEL UNLOCKER SCRIPT

public class levelController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject level2_lockpanel;
    public GameObject level3_lockpanel;
    public GameObject level4_lockpanel;
    public GameObject purchasepanel;
    
 
    
    void Start()
    {    //level 2
        PlayerPrefs.GetInt("2_unlock",0);
        if(PlayerPrefs.GetInt("2_unlock",0)==0){
                level2_lockpanel.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("2_unlock",0)==1) level2_lockpanel.SetActive(false);

        //level 3
        PlayerPrefs.GetInt("3_unlock",0);
        if(PlayerPrefs.GetInt("3_unlock",0)==0){
                level3_lockpanel.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("3_unlock",0)==1) level3_lockpanel.SetActive(false);

        //level4
        PlayerPrefs.GetInt("4_unlock",0);
        if(PlayerPrefs.GetInt("4_unlock",0)==0){
                level4_lockpanel.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("4_unlock",0)==1) level4_lockpanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
           if(PlayerPrefs.GetInt("2_unlock",0)==0){
                level2_lockpanel.SetActive(true);
        }
        else level2_lockpanel.SetActive(false);


         if(PlayerPrefs.GetInt("3_unlock",0)==0){
                level3_lockpanel.SetActive(true);
        }
        else level3_lockpanel.SetActive(false);

         if(PlayerPrefs.GetInt("4_unlock",0)==0){
                level4_lockpanel.SetActive(true);
        }
        else level4_lockpanel.SetActive(false);





    }

   

   
     public void level2_unlocker(){
        if(PlayerPrefs.GetInt("Totalcoins",0)>=10000){
         //  PlayerPrefs.SetInt("Totalcoins",PlayerPrefs.GetInt("Totalcoins",0)-10000);

            PlayerPrefs.SetInt("2_unlock",1);
           // MainMenu.writeNewUser(MainMenu.user.UserId)
          
         
        }
        else{
                 LeanTween.moveY(purchasepanel,Screen.height/2,0.4f).setEase(LeanTweenType.easeOutBounce);
                
        }
       
    }
     

     public void level3_unlocker(){
        if(PlayerPrefs.GetInt("Totalcoins",0)>=10000){
         //  PlayerPrefs.SetInt("Totalcoins",PlayerPrefs.GetInt("Totalcoins",0)-10000);

            PlayerPrefs.SetInt("3_unlock",1);
           // MainMenu.writeNewUser(MainMenu.user.UserId)
          
         
        }
        else{
                 LeanTween.moveY(purchasepanel,Screen.height/2,0.4f).setEase(LeanTweenType.easeOutBounce);
                
        }
       
    }

    public void level4_unlocker(){
        if(PlayerPrefs.GetInt("Totalcoins",0)>=10000){
         //  PlayerPrefs.SetInt("Totalcoins",PlayerPrefs.GetInt("Totalcoins",0)-10000);

            PlayerPrefs.SetInt("4_unlock",1);
           // MainMenu.writeNewUser(MainMenu.user.UserId)
          
         
        }
        else{
                 LeanTween.moveY(purchasepanel,Screen.height/2,0.4f).setEase(LeanTweenType.easeOutBounce);
                
        }
       
    }
}
