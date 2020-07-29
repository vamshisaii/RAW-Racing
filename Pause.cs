using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Pause : MonoBehaviour
{ 
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    public void PauseButton(){
      
         PauseMenu.SetActive(true);
         Time.timeScale=0f;
    }

 


    void Update(){

        
          if(CrossPlatformInputManager.GetButtonDown("ResumeButton")){  PauseMenu.SetActive(false);
         Time.timeScale=1f;}

         if(CrossPlatformInputManager.GetButtonDown("MainMenuButton")){ SceneManager.LoadScene("GameMenu"); 
         Time.timeScale=1f;}

    }
    
}
