using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class UpdateComPort : MonoBehaviour
{
    SerialController serialController;
    string textFile;
    // Start is called before the first frame update
    void Awake()
    {
        serialController = GetComponent<SerialController>();
        string path = Application.streamingAssetsPath + "/com.txt";
        string[] lines = System.IO.File.ReadAllLines(path);
        serialController.portName = lines[0];

    }
}
