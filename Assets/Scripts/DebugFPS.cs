using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugFPS : MonoBehaviour
{
    public TextMeshProUGUI FPSText;
    private float pollingTime = 1f;
    private float time;
    private int frameCount;
    
    private void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if ( time >= pollingTime )
        {
            int frameRate = Mathf.RoundToInt( frameCount / time );
            FPSText.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
