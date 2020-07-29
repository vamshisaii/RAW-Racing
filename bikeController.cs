using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class bikeController : MonoBehaviour
{   public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public Rigidbody2D bikeRigidbody;
       public Transform targetcamera;
   private Vector3 offset;
   private bool followcamera;
    public float speed =20;
    private float movement;
    public float bikeTorque = 10;
    public static bool move2;
    public float force_field;
    //[SerializeField]
    //UnityEngine.Experimental.Rendering.Universal.Light2D m_Light2D = null;
    
    private PhysicsJobOptions2D physicsJob;
    // Start is called before the first frame update
    void Start()
    {      // Physics2D.IgnoreLayerCollision(8,12);
            Physics2D.IgnoreLayerCollision(8,14);
             Physics2D.IgnoreLayerCollision(8,12);
            bikeRigidbody.isKinematic = true;
        followcamera=true;
       // GetComponent<Collider>().isTrigger = false;
        offset = transform.position- targetcamera.position;
        move2=false;
       
       
    }

    // Update is called once per frame
    void Update()
    {       
        
        
        if(move2)movement = CrossPlatformInputManager.GetAxis("Horizontal");
    
         
         
         if(followcamera)
        {transform.position = targetcamera.position +offset;}
         if(Input.GetKeyDown(KeyCode.V)||CrossPlatformInputManager.GetButtonDown("BikeButton")||planemaptrigger.dropbike==true){
            bikeRigidbody.isKinematic=false;
            followcamera=false;
            move2=true;
            Physics2D.IgnoreLayerCollision(8,12,false);
            
        }
          

    }
  private void FixedUpdate()
 {      Time.fixedDeltaTime=0.017f;
      if(inair1.inair==false){backTire.AddTorque(-movement*speed*Time.fixedDeltaTime);
        frontTire.AddTorque(-movement*speed*Time.fixedDeltaTime*0.5f);
        if(forcefield.force)bikeRigidbody.AddForce(transform.right*force_field);
        
        }
       else bikeRigidbody.AddTorque(movement*bikeTorque*Time.fixedDeltaTime);

         
 }


}
