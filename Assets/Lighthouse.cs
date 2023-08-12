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

    public Renderer[] renderer_assets;
    Color colour;
    float c = 0f;

    // Start is called before the first frame update
    void Start()
    {
        pointLight = GameObject.Find("LuzFaro").GetComponent<Light>();
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
        pointLight.intensity = intenP;
        directionalLight.intensity = intenD;

        changePerSecond = (minPValue - maxPValue) / timeToChange;

        colour = new Color(c, c, c);
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
            c = Mathf.Clamp(c - changePerSecond * Time.deltaTime, 0.0f, 1.0f);
        }
        else
        {
            intenP = Mathf.Clamp(intenP + changePerSecond * Time.deltaTime, minPValue, maxPValue);
            intenD = Mathf.Clamp(intenD + changePerSecond * Time.deltaTime, minDValue, maxDValue);
            c = Mathf.Clamp(c + changePerSecond * Time.deltaTime, 0.0f, 1.0f);
        }

        pointLight.intensity = intenP;
        directionalLight.intensity = intenD;
        colour.r = c;
        colour.g = c;
        colour.b = c;

        for (int i = 0; i < renderer_assets.Length; i++)
        {
            renderer_assets[i].material.color = colour;
        }
    }
}
