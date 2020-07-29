using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class percentage_completed_text : MonoBehaviour
{
    // Start is called before the first frame update
     private TextMeshProUGUI changetext;
    void Start()
    {changetext=GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        changetext.text=percentage_completed.percentage.ToString()+" %";
    }
}
