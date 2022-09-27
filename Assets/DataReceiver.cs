using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReceiver : MonoBehaviour
{
    string dataReceived;
    public ConditionController conditionController;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void OnMessageArrived(string message)
    {
        if (message.Contains("Food"))
        {
            conditionController.AddHunger();
        }
        if (message.Contains("Water"))
        {
            conditionController.AddThirst();
        }
        if (message.Contains("Play"))
        {
            conditionController.AddHappyness();
        }
    }

    public void OnConnectionEvent(bool isConnect)
    {

    }
}
