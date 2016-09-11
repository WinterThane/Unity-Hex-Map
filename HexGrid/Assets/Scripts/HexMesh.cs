using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    Mesh _hexMesh;
    List<Vector3> _vertices;
    List<Color> _colors;
    List<int> _triangles;    
    MeshCollider _meshColider;

    void Awake()
    {
        GetComponent<MeshFilter>().mesh = _hexMesh = new Mesh();
        _meshColider = gameObject.AddComponent<MeshCollider>();
        _hexMesh.name = "Hex Mesh";
        _vertices = new List<Vector3>();
        _colors = new List<Color>();
        _triangles = new List<int>();        
    }

    public void Triangulate(HexCell[] cells)
    {
        _hexMesh.Clear();
        _vertices.Clear();
        _colors.Clear();
        _triangles.Clear();      

        for (var i = 0; i < cells.Length; i++)
        {
            Triangulate(cells[i]);
        }

        _hexMesh.vertices = _vertices.ToArray();
        _hexMesh.colors = _colors.ToArray();
        _hexMesh.triangles = _triangles.ToArray();       
        _hexMesh.RecalculateNormals();
        _meshColider.sharedMesh = _hexMesh;
    }

    void Triangulate(HexCell cell)
    {
        var center = cell.transform.localPosition;
        for (var i = 0; i < 6; i++)
        {
            AddTriangle(center, center + HexMetrics.corners[i], center + HexMetrics.corners[i + 1]);
        }
        AddTriangleColor(cell.color);
    }

    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        var vertexIndex = _vertices.Count;
        _vertices.Add(v1);
        _vertices.Add(v2);
        _vertices.Add(v3);
        _triangles.Add(vertexIndex);
        _triangles.Add(vertexIndex + 1);
        _triangles.Add(vertexIndex + 2);
    }

    void AddTriangleColor(Color color)
    {
        _colors.Add(color);
        _colors.Add(color);
        _colors.Add(color);
    }
}
