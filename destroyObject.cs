using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class destroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public static int _tag;
    public Rigidbody2D car;
    public Rigidbody2D bike;
    public Rigidbody2D boat;
    
    public Rigidbody2D plane;

    public Transform targetcar;
    public Transform targetbike;
    public Transform targetboat;
    public Transform targetcamera;
    public Transform targetplane;
    

    


    

private bool followcamera1;
private bool followcamera2;
private bool followcamera3;
public static bool followcamera4;
Vector3 cam;


public GameObject CarButton;
public GameObject BikeButton;
public GameObject BoatButton;
public GameObject gameover;

public int level;



//control vehicle lights
    [SerializeField]
   UnityEngine.Experimental.Rendering.Universal.Light2D light1 = null,light2 = null,light3 = null,light4=null;



    void Start()
    {  CarButton.SetActive(false);
    BikeButton.SetActive(true);
    BoatButton.SetActive(true);

    followcamera4=true;

    //carlight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
   
    _tag=1;
    if(level>1){
    light4.enabled=false;
    light2.enabled=false;
    light3.enabled=false;}
        
    }

    // Update is called once per frame
    void Update()

    {   //locking z axis movement due to camera follow position

      
    
        cam=new Vector3(targetcamera.position.x,targetcamera.position.y,0);

         Vector3 pos1 = targetcar.position;
         pos1.z = 0;
         targetcar.position = pos1;

         Vector3 pos2= targetbike.position;
         pos2.z = 0;//-18.94027
         targetbike.position = pos2;

         Vector3 pos3 = targetboat.position;
         pos3.z = 0;
         targetboat.position = pos3;


        if(CrossPlatformInputManager.GetButtonDown("BoatButton")||CrossPlatformInputManager.GetButtonDown("BikeButton")||CrossPlatformInputManager.GetButtonDown("CarButton")){
            switch(_tag){
                case 1:followcamera1=true;
                       
                   
                    
                    
                break;

                case 2:followcamera2=true;
                  
                   // bike.rotation=0;
                    
                    break;

                case 3:followcamera3=true;
                   
                        
                    break;  
            }

        }
        if(Input.GetKeyDown(KeyCode.C)||CrossPlatformInputManager.GetButtonDown("CarButton")){followcamera1=false;_tag=1;followcamera2=true;followcamera3=true; Physics2D.IgnoreLayerCollision(9,12,false);if(level>1)light1.enabled=true;}//add delay to avoid 2 vehicles spawning}
        if(followcamera1){
            targetcar.position=cam+7*Vector3.up-5*Vector3.right;
            car.isKinematic = true;
             car.velocity=Vector3.zero;
                    car.angularVelocity=0;
                    
                    targetcar.rotation=Quaternion.Euler(0,0,0);
                    CarController.move1=false;
                    Physics2D.IgnoreLayerCollision(9,12);
                   if(level>1) light1.enabled=false;

                  
                   
            }

        if(Input.GetKeyDown(KeyCode.V)||CrossPlatformInputManager.GetButtonDown("BikeButton")){followcamera2=false;_tag=2;followcamera1=true;followcamera3=true;Physics2D.IgnoreLayerCollision(8,12,false);if(level>1)light2.enabled=true;}
        if(followcamera2){targetbike.position=cam+7*Vector3.up-5*Vector3.right;bike.isKinematic = true;
          bike.velocity=Vector3.zero;
                    bike.angularVelocity=0;
                    
                    targetbike.rotation=Quaternion.Euler(0,0,0);
                    bikeController.move2=false;
                    Physics2D.IgnoreLayerCollision(8,12);
                   if(level>1) light2.enabled=false;

        }

        if(Input.GetKeyDown(KeyCode.B)||CrossPlatformInputManager.GetButtonDown("BoatButton")){followcamera3=false;_tag=3;followcamera2=true;followcamera1=true;Physics2D.IgnoreLayerCollision(10,12,false);if(level>1)light3.enabled=true;}
        if(followcamera3){targetboat.position=cam+7*Vector3.up-5*Vector3.right;boat.isKinematic = true;
            boat.velocity=Vector3.zero;
                    boat.angularVelocity=0;
                    
                    targetboat.rotation=Quaternion.Euler(0,0,0);
                    BoatController.move3=false;
                    Physics2D.IgnoreLayerCollision(10,12);
                  if(level>1)  light3.enabled=false;
                    
        }


        if(Input.GetKeyDown(KeyCode.A)||CrossPlatformInputManager.GetButtonDown("PlaneButton")){followcamera4=false;
        followcamera3=true;
        followcamera2=true;
        followcamera1=true;
        if(level>1)light4.enabled=true;

                
        
        }
        if(followcamera4){
            targetplane.position=cam-10.33f*Vector3.right+5.57f*Vector3.up;
            plane.isKinematic=true;
           if(level>1) light4.enabled=false;
        }

        if(planemaptrigger.dropbike)followcamera2=false;
    
        if(CrossPlatformInputManager.GetButtonDown("RespawnButton")){

             followcamera3=true;
        followcamera2=true;
        followcamera1=true;
        followcamera4=true;
        }





       
    }
   void OnCollisionEnter2D(Collision2D other) {
        
  
     
    if(other.gameObject.name=="Tire"||other.gameObject.name=="Tire (1)"){_tag=1; 
    CarButton.SetActive(false);
    
    BikeButton.SetActive(true);
    BoatButton.SetActive(true);
    }
    if(other.gameObject.name=="bike_2"||other.gameObject.name=="bike_3"){_tag=2; 
    BikeButton.SetActive(false);
    CarButton.SetActive(true);
    
    BoatButton.SetActive(true);}
    planemaptrigger.dropbike=false;

    if(other.gameObject.name=="boat"){_tag=3; 
    BoatButton.SetActive(false);
    CarButton.SetActive(true);
    BikeButton.SetActive(true);
    
    }

   

  

        
    }
      void OnCollisionExit2D(Collision2D other) {
      
   
    if(other.gameObject.name=="Tire"||other.gameObject.name=="Tire (1)")_tag=1;
    if(other.gameObject.name=="bike_2"||other.gameObject.name=="bike_3")_tag=2;
    if(other.gameObject.name=="boat")_tag=3;
        
    }

   






     void OnTriggerEnter2D(Collider2D other) {
        
    
        if(other.gameObject.name=="Tire"||other.gameObject.name=="Tire (1)"){_tag=1; 
    CarButton.SetActive(false);
    
    BikeButton.SetActive(true);
    BoatButton.SetActive(true);
    }
    if(other.gameObject.name=="bike_2"||other.gameObject.name=="bike_3"){_tag=2; 
    BikeButton.SetActive(false);
    CarButton.SetActive(true);
    
    BoatButton.SetActive(true);}

    if(other.gameObject.name=="boat"){_tag=3; 
    BoatButton.SetActive(false);
    CarButton.SetActive(true);
    BikeButton.SetActive(true);
    }
        
    }
      void OnTriggerExit2D(Collider2D other) {
        
   
   if(other.gameObject.name=="Tire"||other.gameObject.name=="Tire (1)"){_tag=1; 
    CarButton.SetActive(false);
    
    BikeButton.SetActive(true);
    BoatButton.SetActive(true);
    }
    if(other.gameObject.name=="bike_2"||other.gameObject.name=="bike_3"){_tag=2; 
    BikeButton.SetActive(false);
    CarButton.SetActive(true);
    
    BoatButton.SetActive(true);}

    if(other.gameObject.name=="boat"){_tag=3; 
    BoatButton.SetActive(false);
    CarButton.SetActive(true);
    BikeButton.SetActive(true);
    }
        
    }
   void OnTriggerStay2D(Collider2D other)
    {
          if(other.gameObject.name=="Tire"||other.gameObject.name=="Tire (1)"){_tag=1; 
    CarButton.SetActive(false);
    
    BikeButton.SetActive(true);
    BoatButton.SetActive(true);
    }
    if(other.gameObject.name=="bike_2"||other.gameObject.name=="bike_3"){_tag=2; 
    BikeButton.SetActive(false);
    CarButton.SetActive(true);
    
    BoatButton.SetActive(true);}

    if(other.gameObject.name=="boat"){_tag=3; 
    BoatButton.SetActive(false);
    CarButton.SetActive(true);
    BikeButton.SetActive(true);
    }
    }



    



}
