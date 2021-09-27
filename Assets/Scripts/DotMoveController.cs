using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMoveController : MonoBehaviour
{
    Transform tr;
    //Rigidbody rb;
    GameObject FOE;
    float StartTime;
    int dir;
    public float AngularVelocity;
    //ドットの中心が左側にあるか
    public bool IsLeft;
    //逆回転かどうか
    public bool IsReverse;
    public float r;
    private float AngularSum = 0;

    bool isMove = false;
    bool isStart = false;
    public bool isFirstConditon;
    // Use this for initialization
    void Start()
    {
        FOE = GameObject.Find("FOE");
        StartTime = Time.time;

        tr = gameObject.GetComponent<Transform>();
        if (isFirstConditon)
        {
            startMoveWait();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart && Time.time - StartTime >= StartExperiment.waitTime)
        {
            startMove();
        }
        if (isMove)
        {
            //Debug.Log("move!");
            move();
        }
    }

    public void startMove()
    {
        isMove = true;
        isStart = false;
    }

    public void startMoveWait()
    {   
        StartTime = Time.time;
        isStart = true;
    }

    void move()
    {
        float Angular = AngularVelocity * Time.deltaTime;
        if (IsLeft && IsReverse)
        {
            tr.RotateAround(new Vector3(-r, 0, 0), Vector3.up, -Angular);
        }
        else if (IsLeft && !IsReverse)
        {
            tr.RotateAround(new Vector3(-r, 0, 0), Vector3.up, Angular);
        }
        else if (!IsLeft && IsReverse)
        {
            tr.RotateAround(new Vector3(r, 0, 0), Vector3.up, Angular);
        }
        else
        {
            tr.RotateAround(new Vector3(r, 0, 0), Vector3.up, -Angular);
        }
    }


}
