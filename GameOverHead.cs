using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHead : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOver;
 
    
    void Start(){
        GameOver.SetActive(false);
        Time.timeScale=1f;
        Time.fixedDeltaTime=0.02f;
    }
       void OnCollisionEnter2D(Collision2D other) {
       if(other.collider.tag=="missiles"){
        }
        else{
            GameOver.SetActive(true);
        Time.timeScale=0.1f;
        Time.fixedDeltaTime=0.007f;
        }}
}
