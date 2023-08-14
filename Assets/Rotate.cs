using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotate : MonoBehaviour
{
    public float rotSpeed = 10f;
    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {

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
    }
}
