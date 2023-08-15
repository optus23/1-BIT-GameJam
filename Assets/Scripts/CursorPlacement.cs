using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPlacement : MonoBehaviour
{
    [SerializeField]
    private Transform m_Cursor;
    public Camera MainCamera;
    public LayerMask IgnoreLayerMask;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ( Physics.Raycast( ray, out hit, Mathf.Infinity, ~IgnoreLayerMask) )
        {
            // Set Cursor Position
            m_Cursor.position = new Vector3( hit.point.x, hit.point.y, hit.point.z);
        }
    }
}
