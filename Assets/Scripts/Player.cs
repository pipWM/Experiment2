using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    GameObject DotObject1, DotObject2, DotCreateObject1, DotCreateObject2;
    Transform tr, rHandTr;
    float StartTime;

    DataSend dataSend;
    float rStick;
    int vecLevel;
    bool isMove = false;
    bool canFinish = false;
    Text vecText;
    Image vecIm;
    public List<Data> dataList = new List<Data>();

    // Use this for initialization
    void Start () {
        getCom();
        ExperimentController exCon = GameObject.Find("ExperimentController").GetComponent<ExperimentController>();
        exCon.startCreate();
        StartTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        getVecLevel();

        if (vecLevel == 0 && !isMove && OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            ExperimentController exCon = GameObject.Find("ExperimentController").GetComponent<ExperimentController>();
            //exCon.startCreate();
            exCon.startMoveWait();
            exCon.startCount();
            changeTextColor();
            isMove = true;
            canFinish = true;
            StartTime = Time.time;
        }
        /*

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Object1Delete();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Object2Delete();
        }*/
        if ((OVRInput.GetDown(OVRInput.RawButton.B) && !canFinish))
        {
            //初期ランダムドットを作り直す
            ExperimentController exCon = GameObject.Find("ExperimentController").GetComponent<ExperimentController>();
            exCon.ResetFirstCreate();

        }

        checkNextScene();
    }

    void getVecLevel()
    {
        float rotZ = rHandTr.eulerAngles.z;
        if (rotZ > 180)
        {
            rotZ -= 360f;
            rotZ = Mathf.Max(-40, rotZ);
        }
        else
        {
            rotZ = Mathf.Min(40, rotZ);
        }

        vecLevel = Mathf.RoundToInt(rotZ) * 5;
        //Debug.Log("z: " + rotZ);
        /*
        rStick = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;
        if (rStick >= 0)
        {
            vecLevel = 10 * Mathf.CeilToInt(rStick * 10f);
        }
        else
        {
            vecLevel = 10 * Mathf.FloorToInt(rStick * 10f);
        }
        vecLevel += 100;*/
        vecText.text = "" + vecLevel;
        vecIm.fillAmount = ((vecLevel + 200) / 400f);
    }

    public void startMove()
    {
        StartTime = Time.time;
        InvokeRepeating("makeData", 0, 0.1f);
    }

    void makeData()
    {
        float time = Time.time - StartTime;
        Data data = new Data(time, vecLevel);
        dataSend.addData(data);
        dataList.Add(data);
    }

    void checkNextScene()
    {
        if ((Time.time - StartTime > 60 + StartExperiment.waitTime && canFinish)|| (OVRInput.GetDown(OVRInput.RawButton.A) && StartExperiment.IsDebug))
        {
            dataSend.startSendData();
            StartExperiment.NowExperiment++;
            if (StartExperiment.NowExperiment >= StartExperiment.ExperimentCount)
            {
                SceneManager.LoadScene("Finish");
            }
            else
            {
                SceneManager.LoadScene("Wait");
            }

        }
    }

    void Object2Delete()
    {
        if (DotObject2.activeSelf)
        {
            DotCreateObject2.GetComponent<CreateRotationDot>().Cancel();
        }
        else
        {
            //DotCreateObject2.GetComponent<CreateRotationDot>().Repeat();
        }
        DotObject2.SetActive(!DotObject2.activeSelf);
    }

    void Object1Delete()
    {
        if (DotObject1.activeSelf)
        {
            DotCreateObject1.GetComponent<CreateRotationDot>().Cancel();
        }
        else
        {
            //DotCreateObject1.GetComponent<CreateRotationDot>().Repeat();
        }
        DotObject1.SetActive(!DotObject1.activeSelf);
    }
    
    private void getCom()
    {
        dataSend = GameObject.Find("ExperimentController").GetComponent<DataSend>();
        tr = this.transform;
        DotObject1 = GameObject.Find("DotObject1");
        DotObject2 = GameObject.Find("DotObject2");
        DotCreateObject1 = GameObject.Find("RotationDotCreateObject1");
        DotCreateObject2 = GameObject.Find("RotationDotCreateObject2");

        vecText = GameObject.Find("vection").GetComponent<Text>();
        
        rHandTr = GameObject.Find("RightHandAnchor").GetComponent<Transform>();
        vecIm = GameObject.Find("vecGraph").GetComponent<Image>();
    }

    private void changeTextColor()
    {
        Color tmpC = vecText.color;
        tmpC.a = 0;
        vecText.color = tmpC;
    }
}

public class Data
{
    public float time;
    public int vection;
    public Data(float time, int vection)
    {
        this.time = time;
        this.vection = vection;
    }
}