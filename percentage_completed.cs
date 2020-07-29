using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class percentage_completed : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform bike;
    private float distance;
    

    public static int percentage;
    private int x;
    
    
    void Start()
    { 
      distance=transform.position.x-bike.position.x;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
            x=100+Mathf.FloorToInt(((bike.position.x-transform.position.x)/distance)*100);

            percentage=Mathf.Clamp(x,0,100);



    


        
    }



}
