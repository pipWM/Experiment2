using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    float StartTime;
    public GameObject Button;
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - StartTime >= 5f || StartExperiment.IsDebug)
        {
            Button.SetActive(true);
        }
    }

    public void nextFirstCondition()
    {
        SceneManager.LoadScene("FirstCondition");
    }
}
