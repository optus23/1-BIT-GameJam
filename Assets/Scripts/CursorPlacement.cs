using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPlacement : MonoBehaviour
{

    public Camera MainCamera;
    public Transform m_Cursor;
    public LayerMask IgnoreLayerMask;

    void Start()
    {
        IgnoreLayerMask.value = LayerMask.GetMask("IgnoreZoomEffect", "IgnorePaint");
    }

    void Update()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) )
        {
            // Set Cursor Position
            m_Cursor.position = new Vector3( hit.point.x, hit.point.y, hit.point.z);

        }
    }
}
