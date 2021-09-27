using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentController : MonoBehaviour {
    public GameObject whiteBall;
    public GameObject blackBall;
    public GameObject create2;
    CreateRotationDot DotCreate1;
    CreateRotationDot DotCreate2;
    DotMoveController DotMove1, DotMove2;
    float startTime;
    int ExperimentNumber;
    bool canStart = false;
    bool isCreateDot2 = true;
    // Use this for initialization
    void Start () {

        DotCreate1 = GameObject.Find("DotCreateObject1").GetComponent<CreateRotationDot>();
        DotCreate2 = GameObject.Find("DotCreateObject2").GetComponent<CreateRotationDot>();
        DotMove1 = GameObject.Find("DotObject1").GetComponent<DotMoveController>();
        DotMove2 = GameObject.Find("DotObject2").GetComponent<DotMoveController>();
        bool IsReverse1 = false;
        bool IsReverse2 = true;
        ExperimentNumber = StartExperiment.ExperimentNumber[StartExperiment.NowExperiment];
        switch (ExperimentNumber)
        {
            case 1:
                //白のみ
                create2.SetActive(false);
                isCreateDot2 = false;
                break;
            case 2:
                //白、逆黒
                break;
            case 3:
                //白、黒
                IsReverse2 = false;
                break;
            case 4:
                //白、逆白
                DotCreate2.dot = whiteBall;
                break;
            case 5:
                //白、白
                DotCreate2.dot = whiteBall;
                IsReverse2 = false;
                break;
            case 6:
                //黒
                DotCreate1.dot = blackBall;
                create2.SetActive(false);
                isCreateDot2 = false;
                break;
            case 7:
                //黒、逆白
                DotCreate1.dot = blackBall;
                DotCreate2.dot = whiteBall;
                break;
            case 8:
                //黒、白
                DotCreate1.dot = blackBall;
                DotCreate2.dot = whiteBall;
                IsReverse2 = false;
                break;
        }
        DotCreate1.IsReverse = IsReverse1;
        DotCreate2.IsReverse = IsReverse2;

        DotMove1.IsReverse = IsReverse1;
        DotMove2.IsReverse = IsReverse2;

        startTime = Time.time;
    }

    void Update()
    {
        if (canStart && Time.time - startTime >= 2f)
        {
            Debug.Log("スタートしました");
            startMove();
            canStart = false;
        }
    }

    void NextScene()
    {
        if(StartExperiment.NowExperiment < StartExperiment.ExperimentCount - 1)
        {
            SceneManager.LoadScene("Wait");
        }
        else
        {
            SceneManager.LoadScene("Finish");
        }
           
    }

    public void startCreate()
    {
        DotCreate1.startCreate();
        if (isCreateDot2) DotCreate2.startCreate();
    }

    public void startCount()
    {
        DotCreate1.startCount();
        if (isCreateDot2) DotCreate2.startCount();
    }

    public void startMoveWait()
    {
        canStart = true;
        startTime = Time.time;
        DotMoveController dotMoveCon1 = GameObject.Find("DotObject1").GetComponent<DotMoveController>();
        DotMoveController dotMoveCon2 = GameObject.Find("DotObject2").GetComponent<DotMoveController>();
        dotMoveCon1.startMoveWait();
        dotMoveCon2.startMoveWait();
        MatoScript mato = GameObject.Find("Circle").GetComponent<MatoScript>();
        mato.Destroy();
    }
    public void startMove()
    {
        /*
        DotMoveController dotMoveCon1 = GameObject.Find("DotObject1").GetComponent<DotMoveController>();
        DotMoveController dotMoveCon2 = GameObject.Find("DotObject2").GetComponent<DotMoveController>();

        dotMoveCon1.startMove();
        dotMoveCon2.startMove();*/
        Player player = GameObject.Find("OVRCameraRig").GetComponent<Player>();
        player.startMove();
    }

    public void ResetFirstCreate()
    {
        DeleteChild("DotObject1");
        DeleteChild("DotObject2");
        DotCreate1.ReCreate();
        if (isCreateDot2) DotCreate2.ReCreate();
    }

    private void DeleteChild(string name)
    {
        Transform children = GameObject.Find(name).GetComponentInChildren<Transform>();
        foreach (Transform ob in children)
        {
            Destroy(ob.gameObject);
        }
    }
}
