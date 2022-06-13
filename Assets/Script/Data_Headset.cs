using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

public class Data_Headset : MonoBehaviour
{
    string Filename = "";
    int i = 0;
    float TimeCD = 1;
    float RunTime = 0;


    void Start()
    {
        InvokeRepeating("OutputTime", 0.04f, 0.04f);  //0.04s delay, repeat every 0.04s
        Filename = Application.dataPath + "/test.csv";

    }

    private void OutputTime()
    {
        Debug.Log(TimeCD);

        Debug.Log("Position X = " + transform.localPosition.x);
        Debug.Log("possition X no local = " + transform.position.x);
        Debug.Log("Position Y = " + transform.localPosition.y);
        Debug.Log("possition Y no local = " + transform.position.y);
        Debug.Log("Position Z = " + transform.localPosition.z);
        Debug.Log("possition Z no local = " + transform.position.z);
        Debug.Log("Inverse coordinate : " + transform.InverseTransformPoint(transform.position));
        Debug.Log("Rotation X = " + transform.localRotation.x);
        Debug.Log("Rotation NO LOCAL X = " + transform.rotation.x);
        Debug.Log("Rotation Y = " + transform.localRotation.y);
        Debug.Log("Rotation NO LOCAL Y = " + transform.rotation.y);
        Debug.Log("Rotation Z = " + transform.localRotation.z);
        Debug.Log("Rotation NO LOCAL Z = " + transform.rotation.z);
        Debug.Log("Inverse quaternion Rotation : " + Quaternion.Inverse(transform.rotation));
        //WriteCSV();
        RunTime = Time.time;
        if (RunTime > 10)
        {
            EditorApplication.ExecuteMenuItem("Edit/Play");
        }
    }


    public void WriteCSV()
    {
        TimeCD = RunTime;
        TextWriter tw = new StreamWriter(Filename, true);
        if (i == 0)
        {
            tw.WriteLine("Time(s);Position_X;Position_Y;Position_Z;Rotation_X;Rotation_Y;Rotation_Z");
            tw.Close();
            tw = new StreamWriter(Filename, true);
        }
        var line = string.Format("{0};{1};{2};{3};{4};{5};{6}", TimeCD, transform.position.x, transform.position.y, transform.position.z, transform.localRotation.x, transform.localRotation.y, transform.localRotation.z) ;
        tw.WriteLine(line);
        tw.Close();
        i = 1;

    }
}