using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartExperiment : MonoBehaviour {
   
    //条件の数
    public static int ExperimentCount = 8;
    public static int[] ExperimentNumber = new int[ExperimentCount];
    //public static int[] ExperimentNumber;
    public static int NowExperiment = 0;
    public static float waitTime = 3f;

    public static bool IsDebug = true;
    
    void Start () {
        List<int> tmp = new List<int>();
        for(int i = 0;i < ExperimentCount; i++)
        {
            tmp.Add(i + 1);
        }
        
        for(int i = 0;i < ExperimentCount; i++)
        {

            int r = Random.Range(0,tmp.Count);
            ExperimentNumber[i] = tmp[r];
            tmp.RemoveAt(r);
        }
        /*
        int r = Random.Range(0, 2);
        if(r == 0)
        {
            ExperimentNumber = new int[]{ 2,1,3};
        }
        else
        {
            ExperimentNumber = new int[]{ 3, 1, 2};
        }*/
        string s = "";
        for (int i = 0; i < ExperimentCount; i++)
        {
            s += ExperimentNumber[i];
        }

        Debug.Log(s);
	}

    public void NextCondition()
    {
        Debug.Log("clicked!");
        SceneManager.LoadScene("PreFirstCondition");
    }

}
