using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour
{
    public float maxPValue = 3f;
    public float minPValue = 0f;
    public float maxDValue = 1f;
    public float minDValue = 0f;
    float intenP = 0f; // the total
    float intenD = 0.0f;
    float changePerSecond; // modify the total, every second
    public float timeToChange = 8f; // the total time myValue will take to go from max to min
    bool add = true;

    Light pointLight;
    Light directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        pointLight = GameObject.Find("Spot Light LightHouse").GetComponent<Light>();
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
        pointLight.intensity = intenP;
        directionalLight.intensity = intenD;

        changePerSecond = (minPValue - maxPValue) / timeToChange;
    }

    // Update is called once per frame
    void Update()
    {
        if (intenP <= 0f) { add = true; }
        else if (intenP >= 3f) { add = false; }

        if (add)
        {
            intenP = Mathf.Clamp(intenP - changePerSecond * Time.deltaTime, minPValue, maxPValue);
            intenD = Mathf.Clamp(intenD - changePerSecond * Time.deltaTime, minDValue, maxDValue);
        }
        else
        {
            intenP = Mathf.Clamp(intenP + changePerSecond * Time.deltaTime, minPValue, maxPValue);
            intenD = Mathf.Clamp(intenD + changePerSecond * Time.deltaTime, minDValue, maxDValue);
        }

        pointLight.intensity = intenP;
        directionalLight.intensity = intenD;     
    }
}
