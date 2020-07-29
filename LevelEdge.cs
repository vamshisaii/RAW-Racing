using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEdge : MonoBehaviour
{
    // Start is called before the first frame update

   public GameObject GameOver;
   void Start(){
        GameOver.SetActive(false);
        Time.timeScale=1f;
    }

    // Update is called once per frame
   

  private void OnTriggerEnter2D(Collider2D other) {
   
       GameOver.SetActive(true);
        Time.timeScale=0.10f;
      
  }
}
