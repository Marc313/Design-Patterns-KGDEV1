using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizable : MonoBehaviour
{
    public sMeshList meshList;

    //private GameObject UISet;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    //private Image leftDisplay;
    //private Image rightDisplay;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private int currentMeshIndex;
    private Variant currentVariant;

    public enum Direction { Next, Previous};

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

    /*private void OnEnable()
    {
        //ParseUI();
        leftButton?.onClick.AddListener(previousVariants);
        rightButton?.onClick.AddListener(nextVariants);
    }

    private void OnDisable()
    {
        leftButton?.onClick.RemoveListener(previousVariants);
        rightButton?.onClick.RemoveListener(nextVariants);
    }*/

    private void OnEnable()
    {
        EventSystem.Subscribe(EventSystem.EventName.BUTTON_CLICK, CheckButtonClick);
        EventSystem.Subscribe(EventSystem.EventName.CHARACTER_DONE, ApplyVariant);
    }

    private void OnDisable()
    {
        EventSystem.Unsubscribe(EventSystem.EventName.BUTTON_CLICK, CheckButtonClick);
        EventSystem.Unsubscribe(EventSystem.EventName.CHARACTER_DONE, ApplyVariant);
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
        switchVariant(Direction.Previous);
    }

    private void nextVariants()
    {
        switchVariant(Direction.Next);
    }

    private void CheckButtonClick(EventSystem.EventName eventName, object _button)
    {
        if (_button.Equals(leftButton))
        {
            previousVariants();
        } 
        else if (_button.Equals(rightButton))
        {
            nextVariants();
        }
    }

    private void switchVariant(Direction direction)
    {
        if (meshList == null || meshList.variants.Count == 0) return;

        int variantCount = meshList.variants.Count;
        int directionValue = direction == Direction.Next ? 1 : -1;

        currentMeshIndex = ((currentMeshIndex + directionValue + variantCount) % meshList.variants.Count);
        currentVariant = meshList.variants[currentMeshIndex];
        UpdateVariantModelAndMaterial(currentVariant);
    }

    public void UpdateVariantModelAndMaterial(Variant _variant)
    {
        meshFilter.mesh = _variant.mesh;
        meshRenderer.material = _variant.material;

        //UpdateUISet();
    }

    private void ApplyVariant(EventSystem.EventName eventName, object _object)
    {
        Character.SaveFeature(this, currentVariant);
    }

    public void LoadVariant(Variant _variant)
    {
        currentVariant = _variant;
        UpdateVariantModelAndMaterial(_variant);
    }

    /*private void ParseUI()
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
    }*/

    /* private void UpdateUISet()
     {
         leftDisplay.sprite = meshList.variants[(currentMeshIndex - 1 + meshList.variants.Count) % meshList.variants.Count].sprite;
         rightDisplay.sprite = meshList.variants[(currentMeshIndex + 1) % meshList.variants.Count].sprite;
     }*/
}
