using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cus : MonoBehaviour
{
    public Vector2 topPoint;
    public Vector2 bottomPoint;
    public Vector2 leftPoint;
    public Vector2 rightPoint;
    public Vector2 frontPoint;
    public Vector2 backPoint;
    private Mesh m_mesh;
    // Start is called before the first frame update
    public enum CubeFaceType
    {
        Top,
        Bottom,
        Left,
        Right,
        Front,
        Back
    };
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if(meshFilter == null)
        {
            Debug.LogError("Script needs MeshFilter component");
            return;
        }
        Mesh meshCopy = Mesh.Instantiate(meshFilter.sharedMesh) as Mesh;
        meshCopy.name = "Cube";
        m_mesh = meshFilter.mesh = meshCopy;
        m_mesh = meshFilter.mesh;
        if(m_mesh == null || m_mesh.uv.Length != 24)
        {
            Debug.LogError("Script need to be attached to built-in cube");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMeshUVS();
    }
    void UpdateMeshUVS()
    {
        Vector2[] uvs = m_mesh.uv;
        SetFaceTexture(CubeFaceType.Front, uvs);
        // Top
        SetFaceTexture(CubeFaceType.Top, uvs);
        // Back
        SetFaceTexture(CubeFaceType.Back, uvs);
        // Bottom
        SetFaceTexture(CubeFaceType.Bottom, uvs);
        // Left
        SetFaceTexture(CubeFaceType.Left, uvs);
        // Right        
        SetFaceTexture(CubeFaceType.Right, uvs);
        m_mesh.uv = uvs;
    }
    Vector2[] GetUVS(float originX, float originY)
    {
        Vector2[] uvs = new Vector2[4];
        uvs[0] = new Vector2(originX / 3.0f, originY / 3.0f);
        uvs[1] = new Vector2((originX + 1) / 3.0f, originY / 3.0f);
        uvs[2] = new Vector2(originX / 3.0f, (originY + 1) / 3.0f);
        uvs[3] = new Vector2((originX + 1) / 3.0f, (originY + 1) / 3.0f);

        return uvs;
    }
    void SetFaceTexture(CubeFaceType faceType, Vector2[] uvs)
    {
        if (faceType == CubeFaceType.Front)
        {
            uvs[0] = new Vector2(0, 0);
            uvs[1] = new Vector2(1, 0);
            uvs[2] = new Vector2(0, 1);
            uvs[3] = new Vector2(1, 1);
        }
        else if (faceType == CubeFaceType.Back)
        {
            uvs[10] = new Vector2(0, 0);
            uvs[11] = new Vector2(0, 0);
            uvs[6] = new Vector2(0, 0);
            uvs[7] = new Vector2(0, 0);
        }
        else if (faceType == CubeFaceType.Top)
        {
            Vector2[] newUVS = GetUVS(topPoint.x, topPoint.y);
            uvs[8] = new Vector2(0, 0);
            uvs[9] = new Vector2(0, 0);
            uvs[4] = new Vector2(0, 0);
            uvs[5] = new Vector2(0, 0);
        }
        else if (faceType == CubeFaceType.Bottom)
        {
            Vector2[] newUVS = GetUVS(bottomPoint.x, bottomPoint.y);
            uvs[12] = new Vector2(0, 0);
            uvs[14] = new Vector2(0, 0);
            uvs[15] = new Vector2(0, 0);
            uvs[13] = new Vector2(0, 0);
        }
        else if (faceType == CubeFaceType.Left)
        {
            Vector2[] newUVS = GetUVS(leftPoint.x, leftPoint.y);
            uvs[16] = new Vector2(0, 0);
            uvs[18] = new Vector2(0, 0);
            uvs[19] = new Vector2(0, 0);
            uvs[17] = new Vector2(0, 0);
        }
        else if (faceType == CubeFaceType.Right)
        {
            Vector2[] newUVS = GetUVS(rightPoint.x, rightPoint.y);
            uvs[20] = new Vector2(0, 0);
            uvs[22] = new Vector2(0, 0);
            uvs[23] = new Vector2(0, 0);
            uvs[21] = new Vector2(0, 0);
        }
    }
}
