using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public Texture2D tex;
    // Use this for initialization
    void Start()
    {
        //tex = new Texture2D(64,64);

        GameObject.Find("PlaneSailorForeArmFull").GetComponent<Renderer>().sharedMaterial.mainTexture = tex;
    }

    void Update()
    {
        if (tex != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetButton("Fire1"))
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    // Find the u,v coordinate of the Texture
                    Vector2 uv;
                    uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                    uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                    // Paint it red
                    tex.SetPixel((int)(-uv.x * tex.width), (int)(uv.y * tex.height), Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width), (int)(uv.y * tex.height) + 1, Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height), Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width), (int)(uv.y * tex.height) - 1, Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height), Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height) + 1, Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height) - 1, Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height) + 1, Color.red);
                    tex.SetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height) - 1, Color.red);
                    tex.Apply();
                }
            }
            //if (Input.GetButton("Fire2"))
            //{
            //    for (int i = 0; i < 128; i++)
            //    {e
            //        for (int j = 0; j < 128; j++)
            //        {
            //            tex.SetPixel(i, j, Color.white);
            //        }
            //    }
            //    tex.Apply();
            //}
        }
    }
}
