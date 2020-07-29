using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grey_coin : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Animator animator;
    private bool destroy;
    private float time1;
    public GameObject coin;
    //public GameObject gameOver;

    private bool onlyonce;

    
     void Start()
    {   time1=0f;
        onlyonce=true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(destroy){
                time1+=Time.deltaTime;
                if(time1>0.3f){Destroy(coin);time1=0;}
                
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        animator.SetBool("greycoin",true);
       
        destroy=true;
        if(onlyonce&&Time.timeScale==1f){points.point_score+=100;onlyonce=false;}
    }
}
