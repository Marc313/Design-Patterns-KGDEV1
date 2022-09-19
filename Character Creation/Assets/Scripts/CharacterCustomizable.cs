using UnityEngine;

public class CharacterCustomizable : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    public int ID;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void UpdateMesh(Mesh mesh)
    {
       meshFilter.mesh = mesh;
    }
}
