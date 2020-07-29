using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BoatController : MonoBehaviour
{
   public Rigidbody2D rb2D;
   public Transform targetcamera;
   private Vector3 offset;
   
    private float thrust = 10.0f;
    private float movement;
    private bool force;
    private bool followcamera;
    public static bool move3;
    private bool isSubmarine;
    public int level;

    public float sub_horspeed;
    public float sub_verspeed;
    private float movement_horizontal;
    private float movement_vertical;

    

    void Start()
    {
        move3=false;
        Physics2D.IgnoreLayerCollision(10,14);
        Physics2D.IgnoreLayerCollision(10,12);
     
        rb2D.isKinematic = true;
        followcamera=true;
        offset = transform.position- targetcamera.position;
        if(level>2)isSubmarine=true;
         
     
       
    }

     void Update()
    {
        if(move3&&isSubmarine==false)movement = CrossPlatformInputManager.GetAxis("Horizontal");
        if(move3&&isSubmarine){

              movement_horizontal=CrossPlatformInputManager.GetAxis("Horizontal")*sub_horspeed;
       movement_vertical=CrossPlatformInputManager.GetAxis("Vertical")*sub_verspeed; 
        }
        if(followcamera)
        {transform.position = targetcamera.position +offset;}

       if(Input.GetKeyDown(KeyCode.B)||CrossPlatformInputManager.GetButtonDown("BoatButton")){
            rb2D.isKinematic=false;
            followcamera=false;
            move3=true;
            Physics2D.IgnoreLayerCollision(10,12,false);
        }
       
     
      
    }
    private void FixedUpdate()
    {   Time.fixedDeltaTime=0.017f;
         if(force&&isSubmarine==false){
        rb2D.AddForce(movement*transform.right*thrust);
        
        
        
        }

        else if(force&&isSubmarine){

            rb2D.AddForce(movement_horizontal*transform.right);
            rb2D.AddForce(movement_vertical*transform.up);


        }
        
    }

   

   
     void OnCollisionEnter2D(Collision2D other) {
        
     
     if(other.gameObject.name=="ground")force=false;
    
    
        
    }

   
        private void OnTriggerStay2D(Collider2D other)
    {
     
        if(other.tag=="water")force=true;
    }

     void OnTriggerExit2D(Collider2D other) {
         if(other.tag=="water")force=false; 
    }
  

  
 

    
}