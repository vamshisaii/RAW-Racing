﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint2 : MonoBehaviour
{
    // Start is called before the first frame update

    private bool once=true;

    
    void Start()
    {
        restart_checkpoint.checkpoint=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(once){restart_checkpoint.checkpoint=2;once=false;}
    }
}
