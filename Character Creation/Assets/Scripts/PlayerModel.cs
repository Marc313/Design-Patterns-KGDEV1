using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    CharacterCustomizable[] meshFilters;
    public Mesh mesh;

    private void Awake()
    {
        meshFilters = GetComponentsInChildren<CharacterCustomizable>();
    }

    private void Start()
    {
    }
}
