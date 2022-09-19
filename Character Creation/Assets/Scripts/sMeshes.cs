using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meshes", menuName = "Character Creator/MeshPrefabs")]
public class sMeshList : ScriptableObject
{
    public List<Mesh> meshes;
}
