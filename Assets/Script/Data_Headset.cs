using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

public class Data_Headset : MonoBehaviour
{
    string Filename = "";
    int i = 0;
    int TimeCD = 1;
    int RunTime = 0;


    void Start()
    {
        InvokeRepeating("OutputTime", 1f, 1f);  //1s delay, repeat every 1s
        Filename = Application.dataPath + "/test.csv";

    }

    private void OutputTime()
    {
        Debug.Log(TimeCD);
        Debug.Log("Position X = " + transform.position.x);
        Debug.Log("Position Y = " + transform.position.y);
        Debug.Log("Position Z = " + transform.position.z);
        Debug.Log("Rotation X = " + transform.rotation.x);
        Debug.Log("Rotation Y = " + transform.rotation.y);
        Debug.Log("Rotation Z = " + transform.rotation.z);
        WriteCSV();
        RunTime++;
        if (RunTime == 10)
        {
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
    }


    public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(Filename, true);
        if (i == 0)
        {
            tw.WriteLine("Time(s);Position_X;Position_Y;Position_Z;Rotation_X;Rotation_Y;Rotation_Z");
            tw.Close();
            tw = new StreamWriter(Filename, true);
        }
        var line = string.Format("{0};{1};{2};{3};{4};{5};{6}", TimeCD, transform.position.x, transform.position.y, transform.position.z, transform.rotation.x, transform.rotation.y, transform.rotation.z) ;
        tw.WriteLine(line);
        tw.Close();
        i = 1;
        TimeCD++;
    }
}