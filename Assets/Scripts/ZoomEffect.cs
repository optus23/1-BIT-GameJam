
using UnityEngine;

public class ZoomEffect : MouseController
{
    [SerializeField]
    protected Transform m_ZoomCamera;
    
    [SerializeField]
    protected Transform m_QuadRenderTexture;
    [SerializeField]
    protected Vector3 m_CameraOffset;
    
    public override void Update()
    {
        base.Update();
        Cursor.visible = false;

        m_MousePosition = Input.mousePosition;
        m_MousePosition.z = m_Camera.nearClipPlane + 1;

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
