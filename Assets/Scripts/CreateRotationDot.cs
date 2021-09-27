 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRotationDot : MonoBehaviour
{

    public GameObject dot;
    public Material material;

    Transform DotObjectTransform;
    public int ObjectNumber;
    public bool IsReverse;
    public bool IsMove;
    public int ballCount;
    private float r;
    private Vector3 playerPos = new Vector3(0, 0, 0);
    private float StartTime;
    public float AngularVelocity;

    public bool isFirstCondition;
    private float xMax = 100f;
    private float height = 40f;
    bool IsStart = false;
    // Use this for initialization
    void Start()
    {
        DotObjectTransform = GameObject.Find("DotObject" + ObjectNumber).GetComponent<Transform>();
        StartTime = Time.time;
        if (isFirstCondition)
        {
            startCreate();
            startCount();
        }
        r = GetComponent<Transform>().position.x;
        Debug.Log("r: " + r);
    }
    void Update()
    {
        if (Time.time - StartTime >= StartExperiment.waitTime && !IsStart)
        {
            //startCreate();
            IsStart = true;
        }
    }
    public void startCreate()
    {
        Debug.Log("firstCreate");
        if (material != null)
        {
            dot.GetComponent<Renderer>().material = material;
        }
        //if (IsMove) InvokeRepeating("Create", 0, 1f / Frequence);
        //InvokeRepeating("Count", 0.1f, 0.1f);
        DotObjectTransform = GameObject.Find("DotObject" + ObjectNumber).GetComponent<Transform>();
        for (int i = 0; i < ballCount; i++)
        {
            CreateFirst();
        }
        StartTime = Time.time;

    }
    public void startCount()
    {
        InvokeRepeating("Count", 1, 0.1f);
    }
    void CreateFirst()
    {
        //初期ドットを作る
        float lenX = Random.Range(2f, xMax);
        while (lenX - r <= 1f && lenX - r >= -1f)
        {
            lenX = Random.Range(2f, xMax);
        }
        float lenY = Random.Range(-height, height);

        Vector3 pos = new Vector3(0, 0, 0);

        GameObject instance = (GameObject)Instantiate(dot, pos, Quaternion.identity);
        float Angular = Random.Range(0f, 180f);
        instance.transform.parent = DotObjectTransform;

        if (!IsReverse)
        {
            instance.GetComponent<Transform>().position = new Vector3(lenX + r + playerPos.x, lenY, 0);
            instance.GetComponent<Transform>().RotateAround(new Vector3(r + playerPos.x, 0, 0), Vector3.up, -Angular);
        }
        else
        {
            instance.GetComponent<Transform>().position = new Vector3(-lenX + r + playerPos.x, lenY, 0);
            instance.GetComponent<Transform>().RotateAround(new Vector3(r + playerPos.x, 0, 0), Vector3.up, Angular);
        }
        
        /*
        if (IsReverse)
        {
            instance.GetComponent<Transform>().RotateAround(new Vector3(r + playerPos.x, 0, 0), Vector3.up, Angular);
        }
        else
        {
            instance.GetComponent<Transform>().RotateAround(new Vector3(r + playerPos.x, 0, 0), Vector3.up, -Angular);
        }*/
    }

    void Create()
    {
        //ドットを作る
        //var EyeRotation = CenterEyeTransform.rotation;
        //int dir = Random.Range(0, 359);
        float lenX = Random.Range(2f, xMax);
        while (lenX >= 9f && lenX <= 11f)
        {
            lenX = Random.Range(2f, xMax);
        }
        if(lenX >= 9f && lenX <= 11f)Debug.Log("lenx: " + lenX);
        float lenY = Random.Range(-height, height);
        //Vector3 pos = DotObjectTransform.position;
        //Vector3 pos = new Vector3(10, 0, 0);
        Vector3 pos = new Vector3(0, 0, 0);
        GameObject instance = (GameObject)Instantiate(dot, pos, Quaternion.identity);
        instance.transform.parent = DotObjectTransform;
        //右側
        if (!IsReverse)
        {
            //instance.GetComponent<Transform>().localPosition += new Vector3(r, lenY, lenZ);
            //instance.GetComponent<Transform>().position += new Vector3(lenX + playerPos.x, lenY, 0);
            instance.GetComponent<Transform>().position = new Vector3(lenX + r + playerPos.x, lenY, 0);
        }
        else
        {
            //instance.GetComponent<Transform>().localPosition += new Vector3( - lenZ , lenY, 0);
            //instance.GetComponent<Transform>().position += new Vector3(-lenX + playerPos.x, lenY, 0);
            instance.GetComponent<Transform>().position = new Vector3(-lenX + r + playerPos.x, lenY, 0);
        }
        
    }

    void Count()
    {
        int count = 0;
        if (GameObject.Find("DotObject" + ObjectNumber) != null)
        {
            count = GameObject.Find("DotObject" + ObjectNumber).GetComponent<Transform>().childCount;
        }
        for (int i = 0; i < ballCount - count; i++)
        {
            Create();
        }
    }

    public void Cancel()
    {
        CancelInvoke();
    }

    public void ReCreate()
    {
        for (int i = 0; i < ballCount; i++)
        {
            CreateFirst();
        }
    }
}
