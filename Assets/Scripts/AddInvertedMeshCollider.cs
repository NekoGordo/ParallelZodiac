using UnityEngine;
using System.Linq;
using System.Collections;

public static class AddInvertedMeshCollider
{
    public static void CreateInvertedMeshCollider(GameObject go)
    {
        InvertMesh(go);
        go.AddComponent<MeshCollider>();
    }

    static void InvertMesh(GameObject go)
    {
        Mesh mesh = go.GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
        go.GetComponent<MeshFilter>().mesh = mesh;  //TODO: Necessary?
    }
}