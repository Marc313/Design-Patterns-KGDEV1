using UnityEngine;

public class CharacterCustomizable : MonoBehaviour
{
    public sMeshList meshList;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    public int ID;

    private int currentMeshIndex;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            nextVariants();
        }
    }

    private void nextVariants()
    {
        if (meshList == null || meshList.variants.Count == 0) return;

        currentMeshIndex = ((currentMeshIndex + 1) % meshList.variants.Count);
        Variant currentMesh = meshList.variants[currentMeshIndex];
        UpdateVariant(currentMesh);
    }

    public void UpdateVariant(Variant _variant)
    {
        meshFilter.mesh = _variant.mesh;
        meshRenderer.material = _variant.material;
    }
}
