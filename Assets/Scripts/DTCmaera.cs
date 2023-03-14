using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTCmaera : MonoBehaviour
{

    public Camera ARcamera;
    public Camera DTCamera;
    public Button SwitchToDigitalTwin;
    void start()
    {
        ARcamera.enabled = true;
        DTCamera.enabled = false;

        SwitchToDigitalTwin.onClick.AddListener(SwitchCameras);
    }

    void SwitchCameras()
    {
        ARcamera.enabled = !ARcamera.enabled;
        DTCamera.enabled = !DTCamera.enabled;
    }
}

        
