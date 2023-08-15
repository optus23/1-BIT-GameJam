using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public LayerMask IgnoreLayerMask;
    public Camera MainCamera;

    
    void Start()
    {
        IgnoreLayerMask.value = LayerMask.GetMask("IgnoreZoomEffect", "IgnorePaint", "Cursor");
    }

    void Update()
    {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~IgnoreLayerMask))
            {
                if (Input.GetButton("Fire1"))
                {
                    Debug.Log( "Name: " + hit.transform.gameObject.name );
                    Texture2D tex = hit.transform.gameObject.GetComponent < Renderer >().sharedMaterial.mainTexture as Texture2D;

                    // Find the u,v coordinate of the Texture
                    Vector2 uv;
                    uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                    uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                    
                    // Paint it red

                    if ( tex.GetPixel((int)(-uv.x * tex.width), (int)(uv.y * tex.height)).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width), (int)(uv.y * tex.height), Color.red);
                    }
                    
                    if ( tex.GetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height)).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height), Color.red);
                    }

                    
                    if ( tex.GetPixel((int)(-uv.x * tex.width), (int)(uv.y * tex.height) - 1).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width), (int)(uv.y * tex.height) - 1, Color.red);
                    }
                    
                    if ( tex.GetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height)).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height), Color.red);
                    }
                    
                    if ( tex.GetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height) + 1).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height) + 1, Color.red);
                    }
                    
                    if ( tex.GetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height) - 1).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height) - 1, Color.red);
                    }
                    
                    if ( tex.GetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height) + 1).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width) - 1, (int)(uv.y * tex.height) + 1, Color.red);
                    }
                    
                    if ( tex.GetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height) - 1).a != 0 )
                    {
                        tex.SetPixel((int)(-uv.x * tex.width) + 1, (int)(uv.y * tex.height) - 1, Color.red);
                    }
                    
                    
                    tex.Apply();
                }
            }
    }
    
}
