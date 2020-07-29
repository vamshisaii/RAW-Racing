using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foreground_parallax : MonoBehaviour
{
    // Start is called before the first frame updatepublic Transform[] backgrounds;
 
 private float lengthx, startposx,lengthy,startposy;
 public GameObject cam;
 public float parallaxEffect;

 private float parallaxEffecty=1.2f;

 void Start () {
startposx=transform.position.x;
lengthx=GetComponent<SpriteRenderer>().bounds.size.x;


startposy=transform.position.y;
lengthy=GetComponent<SpriteRenderer>().bounds.size.y;

     
     
     
 }
 
 // Update is called once per frame
 void Update () {
    
     Time.fixedDeltaTime=0.017f;
     float temp=(cam.transform.position.x*(1-parallaxEffect));
     float dist= (cam.transform.position.x*parallaxEffect);
    

     transform.position=new Vector3(startposx + dist, transform.position.y,transform.position.z);

     if(temp>startposx+lengthx)startposx+=lengthx;
     else if(temp<startposx-lengthx)startposx-=lengthx;





      float temp1=(cam.transform.position.y*(1-parallaxEffecty));
     float dist1= (cam.transform.position.y*parallaxEffecty);
    

     transform.position=new Vector3(transform.position.x,startposy + dist1,transform.position.z);

     if(temp1>startposy+lengthy)startposy+=lengthy;
     else if(temp1<startposy-lengthy)startposy-=lengthy;
 
 }
}
