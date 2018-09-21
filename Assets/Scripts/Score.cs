﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    //Public variables visible in Unity
    public TextMesh displayText;

    //Private variables can't be touched by other scripts
    private int currentValue = 0;

    //Update both the data value and visual display
    public void ChangeValue(int _toChange)
    {
        currentValue = currentValue + _toChange;
        displayText.text = currentValue.ToString();
    }
	
}
