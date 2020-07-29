using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingMissiles : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    
    private Rigidbody2D rb;
    public float speed=5f; 
    public float rotateSpeed=200f;
    public int delay;
    public GameObject missile;
    

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(planemaptrigger.missiles){
            StartCoroutine(Delay());
        }
        
        if(planemapexittrigger.destroymissiles)Destroy(missile);
       
      

        if(planeController.explosion)Destroy(missile);

    }

    IEnumerator Delay(){
        yield return new WaitForSeconds(delay);
        Vector2 direction =(Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount=Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity=-rotateAmount*rotateSpeed;
        rb.velocity=transform.up *speed;
    }


   private void OnCollisionEnter2D(Collision2D other)
   {    
       Destroy(missile);
     
   }
      


    
}
