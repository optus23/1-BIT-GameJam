using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotate : MonoBehaviour
{
    public float rotSpeed = 10f;
    Vector3 rot;

    public GameObject background;
    private List<Renderer> renderers;
    public Renderer backdrawableRenderer;
    Color colour;
    float c = 0f;
    float changePerSecond; // modify the total, every second
    public float timeToChange = 1f; // the total time myValue will take to go from max to min

    // Start is called before the first frame update
    void Start()
    {
        renderers = new List<Renderer>();

        foreach (Renderer child in background.transform.GetComponentsInChildren<Renderer>())
        {
            if (null == child)
                continue;

            renderers.Add(child);
        }
        renderers.Add(backdrawableRenderer);

        changePerSecond = (0.0f - 1.0f) / timeToChange;

        colour = new Color(c, c, c);
    }

    // Update is called once per frame
    void Update()
    {
        rot = new Vector3(-180.1f, rot.y, 0);

        //if(transform.localEulerAngles.y >= 140) { add = false; }
        //else if (transform.localEulerAngles.y <= -140) { add = true; }

        rot.y = Mathf.Clamp(rot.y + rotSpeed * Time.deltaTime, -44, 44);

        if (rot.y >= 44)
        {

            rot.y = -44f;
        }

        transform.eulerAngles= rot;


        if (rot.y >= -33f && rot.y<= 30f)
        {
            c = Mathf.Clamp(c - changePerSecond * Time.deltaTime, 0.0f, 1.0f);
        }
        else
        {
            c = Mathf.Clamp(c + changePerSecond * Time.deltaTime, 0.0f, 1.0f);
        }

        colour.r = c;
        colour.g = c;
        colour.b = c;

        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].material.color = colour;
        }
    }
}
