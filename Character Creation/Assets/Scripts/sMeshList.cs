using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MeshList", menuName ="Character Creator/MeshList")]
public class sMeshList : ScriptableObject
{
    public List<Variant> variants;
}
