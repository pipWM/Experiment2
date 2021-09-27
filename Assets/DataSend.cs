using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;

public class DataSend : MonoBehaviour
{
    List<Data> dataList;
    WWWForm form;
    string dataSt = "";
    // Start is called before the first frame update
    void Start()
    {
        dataList = GameObject.Find("OVRCameraRig").GetComponent<Player>().dataList;
        
        form = new WWWForm();
        
    }

    public void startSendData()
    {
        StartCoroutine(Method());
    }

    public void addData(Data data)
    {
        //form.AddField("time[]", "" + data.time);
        //form.AddField("vection[]", data.vection);
        dataSt += data.time + "," + data.vection + "\n";
        Debug.Log("data add: " + data.time + ", " + data.vection);
    }

    private IEnumerator Method()
    {
        int ConditionNumber = StartExperiment.ExperimentNumber[StartExperiment.NowExperiment];
        string fileName = "[2-" + ConditionNumber + "]";
        form.AddField("fileName", fileName);
        form.AddField("dataNum", dataList.Count);
        form.AddField("dataSt", dataSt);

        using (UnityWebRequest www = UnityWebRequest.Post("https://ex.haselab.net/wakayama/getData.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log("���M���s");
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("���M����");
            }
        }
    }
}
