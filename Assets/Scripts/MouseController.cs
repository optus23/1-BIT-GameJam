using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class MouseController : MonoBehaviour
{

    [SerializeField]
    private RawImage m_RawImage;
    [SerializeField]
    private Camera m_Camera;
    private bool m_enableZoomEffect;
    private Vector3 m_MousePosition;
    private Vector3 m_WorldPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            m_enableZoomEffect = !m_enableZoomEffect;
            m_RawImage.enabled = m_enableZoomEffect;
        }

        if ( m_enableZoomEffect )
        {
            m_MousePosition = Input.mousePosition;
            m_WorldPosition = m_Camera.ScreenToWorldPoint( m_MousePosition );

            m_WorldPosition = new Vector3( m_WorldPosition.x, m_WorldPosition.y, m_RawImage.transform.position.z );
            m_RawImage.transform.position = m_WorldPosition;
        }
        
    }
}
