using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMove : MonoBehaviour {
    Transform t;
    Rigidbody rb;
    //Color color;
    GameObject FOE;
    int dir;
    float StartPos;
    public float speed;
    public bool IsReverse;
    public bool IsRotate;
	// Use this for initialization
	void Start () {
        //speed = 0.01f;
        dir = Random.Range(0, 359);
        //color = gameObject.GetComponent<SpriteRenderer>().color;
        //color.a = 0.0f;
        //gameObject.GetComponent<SpriteRenderer>().color = color;
        FOE = GameObject.Find("FOE");
        StartPos = transform.position.z;
        t = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        Vector3 v;
        if (!IsReverse)
        {
            //ドットが前から飛んでくる
            v = new Vector3(0, 0, -speed);
        }
        else
        {
            //ドットが後ろから飛んでくる
            v = new Vector3(0, 0, speed);
        }

        rb.velocity = v;
    }
	
	// Update is called once per frame
	void Update () {
        //CheckAlpha();
        CheckDestroy();
	}

    void CheckDestroy()
    {

        //遠くまで行ったらドットを消す
        if(Mathf.Abs(transform.position.z - StartPos) > 40)
        {
            Destroy(this.gameObject);
        }

    }

    /*
    void CheckAlpha()
    {
        
        Vector3 position = t.position;
        float x = position.x;
        float y = position.y;
        float z = position.z;

       
        Vector3 position = t.localPosition;
        float x = position.x;
        float y = position.y;
        float z = position.z;

    
        if (x * x + y * y > 4)
        {
            color.a = 1.0f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        
        if (Time.time - StartTime > 1.0f)
        {
            color.a = 1.0f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }*/
}
