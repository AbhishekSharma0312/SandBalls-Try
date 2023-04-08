using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    float width = 1, height = 1;
    Camera m_camera;
    Mesh m_mesh;
    MeshFilter m_meshFilter;
    MeshRenderer m_meshRenderer;

    int verticesCount;
    int triCount;

    Vector3[] verts;

    Vector3 startPosi;


    void Start()
    {
        m_meshRenderer = gameObject.AddComponent<MeshRenderer>();
        m_meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        m_meshFilter = gameObject.AddComponent<MeshFilter>();

        m_mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(0, height, 0),
            new Vector3(width, height, 0)
        };
        m_mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        m_mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        m_mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        m_mesh.uv = uv;
        m_meshFilter.mesh = m_mesh;

        StartCoroutine(TestMehtod());
    }

    IEnumerator TestMehtod()
    {
        yield return new WaitForSecondsRealtime(5f);
        verts = m_mesh.vertices;

        Vector3[] newVerts = new Vector3[verts.Length + 2];
        for(int i = 0; i < verts.Length; i++)
        {
            newVerts[i] = verts[i];
        }
        newVerts[verts.Length] = new Vector3(2,0,0);
        newVerts[verts.Length + 1] = new Vector3(2,1,0);
        m_mesh.vertices = newVerts;

        m_meshFilter.mesh = m_mesh;

    }
}
