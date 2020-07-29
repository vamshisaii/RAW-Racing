using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Completed_time : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI changetext;
     float lerp = 0f, duration =0.09f;
     private int time;
    void Start()
    {
        changetext=GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {               lerp+=Time.deltaTime/duration;  

            time=(int)Mathf.Lerp(0,points.t,lerp);
        changetext.text=time.ToString()+" s";
    }
}
