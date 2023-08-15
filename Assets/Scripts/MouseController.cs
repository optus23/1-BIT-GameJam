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
    private Transform m_ZoomCamera;
    
    [SerializeField]
    private Transform m_QuadRenderTexture;
    
    [SerializeField]
    private Camera m_Camera;
  
    [SerializeField]
    private Vector3 m_CameraOffset;

    [SerializeField]
    private Transform m_Cursor;
    
    private Vector3 m_MousePosition;
    private Vector3 m_WorldPosition;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        m_MousePosition = Input.mousePosition;
        m_MousePosition.z = m_Camera.nearClipPlane + 1;
        //m_Cursor.position = m_Camera.ScreenToWorldPoint( m_MousePosition );

        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_QuadRenderTexture.gameObject.SetActive(true);
            m_WorldPosition = m_Camera.ScreenToWorldPoint( m_MousePosition );
            
            m_ZoomCamera.position = new Vector3(m_WorldPosition.x * m_CameraOffset.x, m_WorldPosition.y * m_CameraOffset.y, m_ZoomCamera.position.z);
            m_QuadRenderTexture.position = m_WorldPosition;
        }
        else
        {
            m_QuadRenderTexture.gameObject.SetActive(false);
        }
    }
}
