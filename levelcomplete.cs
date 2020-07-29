using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcomplete : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject nextlevel;
    void Start()
    {
        nextlevel.SetActive(false);
        Time.timeScale=1f;
       // Time.fixedDeltaTime=0.002f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        nextlevel.SetActive(true);
        Time.timeScale=0.09f;
        //Time.fixedDeltaTime=0.007f;
    }
}
