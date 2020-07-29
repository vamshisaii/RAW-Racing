using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Follow : MonoBehaviour
{   public Transform targetcar;
public Transform targetbike;
public Transform targetboat;
public Transform targetplane;

private int switchcamera;
private float movement;


private Vector3 offsetcar;
private Vector3 offsetbike;
private Vector3 offsetboat;
private Vector3 offsetplane;
public Vector3 velocity=Vector3.one;

private Vector3 planecam_zaxisoffset;
private float planefollowcamspeed;
private bool planelerp=false;

  float lerp = 0f, duration =1f;
    // Start is called before the first frame update
    void Start()
    {   switchcamera=1;
        offsetcar = transform.position- targetcar.position;
        offsetbike = transform.position- targetbike.position;
        offsetboat= transform.position- targetboat.position;
        offsetplane=transform.position-targetplane.position;
        planecam_zaxisoffset=new Vector3(0,0,9f);
        

        GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;


        //enable google ads
       
    }

    // Update is called once per frame


    void Update(){
      if(planelerp){  lerp+=Time.deltaTime/duration;
        planefollowcamspeed=Mathf.Lerp(2f,0.0003f,lerp);
        }
    }
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.B)||CrossPlatformInputManager.GetButtonDown("BoatButton")){switchcamera=3;}
        if(Input.GetKeyDown(KeyCode.V)||CrossPlatformInputManager.GetButtonDown("BikeButton")){switchcamera=2;}
        if(Input.GetKeyDown(KeyCode.C)||CrossPlatformInputManager.GetButtonDown("CarButton")){switchcamera=1;}

        if(Input.GetKeyDown(KeyCode.A)||CrossPlatformInputManager.GetButtonDown("PlaneButton"))switchcamera=4;
        if(planemaptrigger.dropbike)switchcamera=2;

        switch(switchcamera){

            case 1://StartCoroutine("CarPos");
                smoothFollow1();
                break;
            
            case 2:
            //Invoke("bike", 0.5f);
            smoothFollow2();

                
                break;

             
            case 3:smoothFollow3();
                break;

            case 4:if(planeController.followcam)smoothFollow4();
            break;    
        }

    }
        
               void smoothFollow2(){
                   Vector3 toPos=targetbike.position+offsetbike+7*Vector3.up;
                   Vector3 curPos=Vector3.SmoothDamp(transform.position,toPos,ref velocity, 0.13f);
                   transform.position=curPos;
                   //print("followingbike");
               }
                 void smoothFollow1(){
                   Vector3 toPos=targetcar.position+offsetcar;
                   Vector3 curPos=Vector3.SmoothDamp(transform.position,toPos,ref velocity, 0.13f);
                   transform.position=curPos;
                  // print("followingcar");
               }
                 void smoothFollow3(){
                   Vector3 toPos=targetboat.position+offsetboat+7*Vector3.up;
                   Vector3 curPos=Vector3.SmoothDamp(transform.position,toPos,ref velocity, 0.13f);
                   transform.position=curPos;
                  // print("followingboat");
               }

                  void smoothFollow4(){
                      Vector3 toPos=targetplane.position+offsetplane-6.5f*Vector3.right+6f*Vector3.up-planecam_zaxisoffset;
                      planelerp=true;
                      Vector3 curPos=Vector3.SmoothDamp(transform.position,toPos,ref velocity, planefollowcamspeed);//0.0003f
                      transform.position=curPos;
                  }


               
               /*public IEnumerator CarPos(){yield return new WaitForSeconds(2);
                transform.position = targetcar.position +offsetcar;
              
               }*/

}
