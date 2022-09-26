using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lose;
    private float startTime;
    private bool isFinished = false; 

    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinished)
        {
            lose.text = "Your Time is" + timerText.text; 

            return;
        }
        
        
        float t = Time.time - startTime;

        string minute = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        timerText.text = minute + ":" + seconds;


    }

    public void Finish()
    {
        isFinished = true;
    }
}
