using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class CarController : MonoBehaviour
{   public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public Rigidbody2D carRigidbody;
    public float speed =20;
    private float movement;
    public float carTorque = 10;
    public static bool move1;
    public float force_field;

    private PhysicsJobOptions2D physicsJob;

    
    // Start is called before the first frame update
    void Start()
    {   carRigidbody.isKinematic = false;
        Physics2D.IgnoreLayerCollision(9,14);
        move1=true;

        //to avoid map collisions
        Physics2D.IgnoreLayerCollision(9,12,false);
       

       
    }

    // Update is called once per frame
    void Update()
    {
        if(move1)movement = CrossPlatformInputManager.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.C)||CrossPlatformInputManager.GetButtonDown("CarButton")){
            carRigidbody.isKinematic=false;
            move1=true;
            Physics2D.IgnoreLayerCollision(9,12,false);
            
        }

         
 
        // Catch up with the game time.
        // Advance the physics simulation in portions of Time.fixedDeltaTime
        // Note that generally, we don't want to pass variable delta to Simulate as that leads to unstable results.
      
    }

 private void FixedUpdate()
 {  Time.fixedDeltaTime=0.02f;
     backTire.AddTorque(-movement*speed*Time.fixedDeltaTime);
        frontTire.AddTorque(-movement*speed*Time.fixedDeltaTime);
        carRigidbody.AddTorque(movement*carTorque*Time.fixedDeltaTime);
        if(forcefield.force)carRigidbody.AddForce(transform.right*force_field);


   
         
       
 }

 
}

