using UnityEngine;
using game4automation;
using System.Net.Sockets;
using System.Threading;
using TMPro;
using UnityEngine.UI;

public class ExampleFunctionsFurther : MonoBehaviour
{
    public string nodeID;

    [Header("Factory Machine")]
    public string factoryMachineNumber;
    public OPCUA_Interface Interface;


    [Header("RFID Reader")]
    public TMP_Text digitalTwinRFIDFeedbackTMP;
    public TMP_Text uiRFIDFeedbackTMP;
    public string RFIDInfo;


    void Start()
    {
        Interface.EventOnConnected.AddListener(OnInterfaceConnected);
        Interface.EventOnConnected.AddListener(OnInterfaceDisconnected);
        Interface.EventOnConnected.AddListener(OnInterfaceReconnect);
    }


    private void OnInterfaceConnected()
    {
        Debug.LogWarning("Connected to Factory Machine " + factoryMachineNumber);
        var RFIDsubscription = Interface.Subscribe(nodeID, RFIDNodeChanged);
        RFIDInfo = RFIDsubscription.ToString();
        Debug.LogError(RFIDInfo);
        //digitalTwinRFIDFeedbackTMP.text = RFIDInfo;
        //uiRFIDFeedbackTMP.text = RFIDInfo;        
    }

    private void OnInterfaceDisconnected()
    {
        Debug.LogWarning("Factory Machine " + factoryMachineNumber + " has disconnected");
    }

    private void OnInterfaceReconnect()
    {
        Debug.LogWarning("Factory Machine " + factoryMachineNumber + " has reconnected");
    }

    public void RFIDNodeChanged(OPCUANodeSubscription sub, object value)
    {
        RFIDInfo = value.ToString();
        Debug.LogError(RFIDInfo);
        //digitalTwinRFIDFeedbackTMP.text = RFIDInfo;
        //uiRFIDFeedbackTMP.text = RFIDInfo;
    }
}
