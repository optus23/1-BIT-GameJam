using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPlacement : MonoBehaviour
{

    public Camera MainCamera;
    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) )
        {
            
        }
    }
}
