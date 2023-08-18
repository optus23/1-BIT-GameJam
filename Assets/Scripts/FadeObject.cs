using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    public bool fadeOut = false, fadeIn = false;
    public float fadeSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A)) { FadeOutObject(); }

        if(fadeOut)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmout = objectColor.a - (fadeSpeed*Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmout);
            this.GetComponent<Renderer>().material.color = objectColor;

            if(objectColor.a <= 0f)
            {
                this.fadeOut = false;
            }
        }

        if(fadeIn)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmout = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmout);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a >= 1f)
            {
                this.fadeIn = false;
            }
        }
    }

    public void FadeOutObject()
    {
        fadeOut = true;
    }

    public void FadeInObject() 
    { 
        fadeIn = true; 
    }
}
