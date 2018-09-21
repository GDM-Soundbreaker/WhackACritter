using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    //display visual timer
    public TextMesh displayText;

    //Starting time for the timer
    public float timerDuration;

    //Current seconds remaining on the timer
    private float TimeRemaining = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//only process the timer if it is running
        if (IsTimerRunning())
        {
            //Timer IS running, so process

            //Updated the time remaining this frame
            TimeRemaining = TimeRemaining - Time.deltaTime;

            //Check if we have now run out of time
            if (TimeRemaining <= 0)
            {
                //Set time to exactly 0
                StopTimer();
            }

            //update the visual display
            displayText.text = Mathf.CeilToInt(TimeRemaining).ToString();
        }
	}

    //Starts the timer counting
    public void StartTimer()
    {
        TimeRemaining = timerDuration;
        displayText.text = Mathf.CeilToInt(TimeRemaining).ToString();
    }

    //Stop the timer counting
    public void StopTimer()
    {
        TimeRemaining = 0;
        displayText.text = Mathf.CeilToInt(TimeRemaining).ToString();
    }

    //Is the timer currently running
    public bool IsTimerRunning()
    {
        if (TimeRemaining != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
