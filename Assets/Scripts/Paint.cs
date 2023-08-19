using UnityEngine;

public class Paint : MouseController
{

        
    public LayerMask IgnoreLayerMask;

    
    public Texture2D tex;
    public Material mat;

    public struct AsignMaterials
    {
        public Texture2D texture2D;
        public Material mat;
    }

    public AsignMaterials asignMat;
    
    public void AssignTexture( MultipleCaster caster )
    {
        tex = caster.texture2D;
        mat = caster.mat;
        
        mat.mainTexture = tex;
        
    }

    public override void Update()
    {
        base.Update();
        
        if (tex != null )
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~IgnoreLayerMask))
            {
                if (Input.GetButton("Fire1"))
                {
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
    
}
