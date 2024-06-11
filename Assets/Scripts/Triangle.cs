using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianglePrefab : MonoBehaviour
{
    public float triangleWidth = 1f;
    public float triangleHeight = 1f;

    void Start()
    {
        CreateTriangle();
    }

    void CreateTriangle()
    {
        GameObject triangle = new GameObject("Triangle");
        MeshFilter meshFilter = triangle.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = triangle.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(triangleWidth, 0, 0);
        vertices[2] = new Vector3(triangleWidth / 2, triangleHeight, 0);
        mesh.vertices = vertices;

        int[] triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        mesh.triangles = triangles;

        Vector2[] uv = new Vector2[3];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0.5f, 1);
        mesh.uv = uv;

        mesh.RecalculateNormals();

        meshRenderer.material = new Material(Shader.Find("Standard"));
    }
}