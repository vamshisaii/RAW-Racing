using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameOver : MonoBehaviour
{
  


  

  void Update(){

    if(CrossPlatformInputManager.GetButtonDown("MainMenuButton")) SceneManager.LoadScene("GameMenu"); 

    
  }
}
