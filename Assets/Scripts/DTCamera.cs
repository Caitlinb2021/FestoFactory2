using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTCamera : MonoBehaviour
{

    public GameObject ARcamera;
    public GameObject DTCamObj;
    public bool ARCameraMode = true;
    public void SwitchCameras()
    {
        if (ARCameraMode == true)
        { 
         DTCamObj.SetActive(true);
         ARcamera.SetActive(false);
            ARCameraMode = false;

            Debug.Log("The camera is in AR Camera Mode");
        }
        else
        {
         ARcamera.SetActive(true);
        DTCamObj.SetActive(false);
            ARCameraMode = true;

            Debug.Log("The camera has switched to Digital Twin Camera");
        }

       
    }
}

        
