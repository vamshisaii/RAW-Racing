using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displaytime : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    private TextMeshProUGUI changetext;
    void Start()
    {
        time=0;
        changetext=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        time+=Time.deltaTime;
        int sec=Mathf.FloorToInt(time);
        int min=(sec/60)%60;
        changetext.text=min.ToString()+":"+(sec%60).ToString();
        
    }

    
}
