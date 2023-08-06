using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FPSShow : MonoBehaviour
{
    public TextMeshProUGUI fpsDebug;
    private float pollingTime = 0.5f;
    private float time;
    private int frameCount;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        frameCount++;
        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsDebug.text = frameRate.ToString() + " FPS";
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
