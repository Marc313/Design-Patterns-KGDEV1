using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizable : MonoBehaviour
{
    public sMeshList meshList;

    [SerializeField] private GameObject UISet;
    private Button leftButton;
    private Button rightButton;
    private Image leftDisplay;
    private Image rightDisplay;


    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private int currentMeshIndex;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        //ParseUI();
        UpdateVariantModelAndMaterial(meshList.variants[0]);
    }

    private void OnEnable()
    {
        ParseUI();
        leftButton?.onClick.AddListener(previousVariants);
        rightButton?.onClick.AddListener(nextVariants);
    }

    private void OnDisable()
    {
        leftButton?.onClick.RemoveListener(previousVariants);
        rightButton?.onClick.RemoveListener(nextVariants);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            nextVariants();
        }
    }

    private void previousVariants()
    {
        if (meshList == null || meshList.variants.Count == 0) return;

        currentMeshIndex = ((currentMeshIndex - 1 + meshList.variants.Count) % meshList.variants.Count);
        Variant currentMesh = meshList.variants[currentMeshIndex];
        UpdateVariantModelAndMaterial(currentMesh);
    }

    private void nextVariants()
    {
        if (meshList == null || meshList.variants.Count == 0) return;

        currentMeshIndex = ((currentMeshIndex + 1) % meshList.variants.Count);
        Variant currentMesh = meshList.variants[currentMeshIndex];
        UpdateVariantModelAndMaterial(currentMesh);
    }

    public void UpdateVariantModelAndMaterial(Variant _variant)
    {
        meshFilter.mesh = _variant.mesh;
        meshRenderer.material = _variant.material;

        UpdateUISet();
    }

    private void ParseUI()
    {
        Identifiable[] uiElements = UISet.GetComponentsInChildren<Identifiable>();
        foreach (Identifiable id in uiElements)
        {
            switch(id.ID)
            {
                case 0:
                    leftDisplay = id.GetComponent<Image>();
                    break;
                case 1: 
                    rightDisplay = id.GetComponent<Image>();
                    break;
                case 2:
                    leftButton = id.GetComponent<Button>();
                    break;
                case 3:
                    rightButton = id.GetComponent<Button>();
                    break;
            }
        }
    }

    private void UpdateUISet()
    {
        leftDisplay.sprite = meshList.variants[(currentMeshIndex - 1 + meshList.variants.Count) % meshList.variants.Count].sprite;
        rightDisplay.sprite = meshList.variants[(currentMeshIndex + 1) % meshList.variants.Count].sprite;
    }
}
