using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inair1 : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool inair;

     private void OnCollisionEnter2D(Collision2D other) {
     inair=false;
     
 }
 private void OnCollisionExit2D(Collision2D other) {
     inair=true;
    
 }
}
