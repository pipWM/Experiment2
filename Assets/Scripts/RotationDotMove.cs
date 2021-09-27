using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDotMove: MonoBehaviour
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
    // Use this for initialization
    void Start()
    {
        FOE = GameObject.Find("FOE");
        StartTime = Time.time;

        tr = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float Angular =  AngularVelocity * Time.deltaTime;
        AngularSum += Angular;
        if (IsLeft && IsReverse)
        {
            tr.RotateAround(new Vector3(-r, 0, 0), Vector3.up, -Angular);
        }
        else if(IsLeft && !IsReverse)
        {
            tr.RotateAround(new Vector3(-r, 0, 0), Vector3.up, Angular);
        }else if(!IsLeft && IsReverse)
        {
            tr.RotateAround(new Vector3(r, 0, 0), Vector3.up, Angular);
        }
        else
        {
            tr.RotateAround(new Vector3(r, 0, 0), Vector3.up, -Angular);
        }*/
        
        
        if(AngularSum >= 190)
        {
            Destroy(this.gameObject);
        }
        if (tr.position.z <= -1f) Destroy(this.gameObject);
    }


}
