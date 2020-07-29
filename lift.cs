using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    // Start is called before the first frame update
    private bool moveup;
    private Vector3 targetPosition;
    public GameObject weightpanel;
    public float height;


    public GameObject CarButton;
public GameObject BikeButton;
public GameObject BoatButton;
   // private float smoothFactor=0.5f;
  
    void Start()
    {
    targetPosition=transform.position+height*Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveup){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2f * Time.deltaTime);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {   

        
        if(other.gameObject.name=="boat"){
            moveup=true;
            weightpanel.SetActive(false);
        }

        else{ moveup=false;weightpanel.SetActive(true);}


         if(other.gameObject.name=="Tire"||other.gameObject.name=="Tire (1)"){destroyObject._tag=1;
    CarButton.SetActive(false);
    
    BikeButton.SetActive(true);
    BoatButton.SetActive(true);
    }
    if(other.gameObject.name=="bike_2"||other.gameObject.name=="bike_3"){destroyObject._tag=2; 
    BikeButton.SetActive(false);
    CarButton.SetActive(true);
    
    BoatButton.SetActive(true);}
    planemaptrigger.dropbike=false;

    if(other.gameObject.name=="boat"){destroyObject._tag=3; 
    BoatButton.SetActive(false);
    CarButton.SetActive(true);
    BikeButton.SetActive(true);
    }}
    private void OnCollisionExit2D(Collision2D other) {
        weightpanel.SetActive(false);
    }
}
