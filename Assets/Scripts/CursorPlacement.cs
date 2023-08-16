using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPlacement : MouseController
{
    public LayerMask IgnoreLayerMask;
    [SerializeField]
    protected Transform m_Cursor;

    public override void Update()
    {
        base.Update();

        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ( Physics.Raycast( ray, out hit, Mathf.Infinity, ~IgnoreLayerMask ) )
        {
            // Set Cursor Position
            m_Cursor.position = new Vector3( hit.point.x, hit.point.y, hit.point.z + 0.2f);
        }
    }
}
