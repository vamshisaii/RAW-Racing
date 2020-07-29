using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcefield : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool force;
    void Start()
    {   
        force=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        force=true;
         Handheld.Vibrate();
       
    }
    private void OnTriggerExit2D(Collider2D other){
        force=false;
        
    }
}
