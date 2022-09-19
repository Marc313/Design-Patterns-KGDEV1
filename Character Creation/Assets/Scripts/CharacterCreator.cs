using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    [SerializeField] private sMeshList meshes;

    // Lots of duplication for each category
    private int currentHairIndex;
    private int currentShirtIndex;
    private int currentPantsIndex;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            nextHair();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            nextShirt();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            nextPants();
        }
    }

    private void nextHair()
    {
        currentHairIndex++;
        // Set playermodel hair to the mesh at currentHairIndex
        // WITH OBSERVER  
    }

    private void nextShirt()
    {
        currentShirtIndex++;
        // Set playermodel shirt to the mesh at currentShirtIndex
    }

    private void nextPants()
    {
        currentPantsIndex++;
        // Set playermodel pants to the mesh at currentPantsIndex
    }
}
