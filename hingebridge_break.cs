using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hingebridge_break : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bridge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {   print("collided");
        if(other.collider.tag=="car"){
            Destroy(bridge);
            print("collided with car");
        }
    }
}
