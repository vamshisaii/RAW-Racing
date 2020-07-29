using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class finalgameoverscore : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI changetext;
    void Start()
    {
        changetext=GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
       changetext.text=points.final_score.ToString();
      

   
    }
}
