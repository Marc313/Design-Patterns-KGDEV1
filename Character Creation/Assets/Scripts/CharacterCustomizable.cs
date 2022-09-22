using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizable : MonoBehaviour, ICommandStackOwner<IReversibleCommand<CharacterCustomizable>>
{
    public enum Direction { Next, Previous };
    public Stack<IReversibleCommand<CharacterCustomizable>> history { get; private set; }

    [SerializeField] private sMeshList meshList;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private int currentMeshIndex;
    private Variant currentVariant;
    private UICommandHandler<CharacterCustomizable> commandHandler;
    private InputHandler<ICommand<CharacterCustomizable>> inputHandler;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        commandHandler = new UICommandHandler<CharacterCustomizable>(this);

        history = new Stack<IReversibleCommand<CharacterCustomizable>>();
        inputHandler = new InputHandler<ICommand<CharacterCustomizable>>();
    }

    private void Start()
    {
        //ParseUI();
        LoadSavedVariant();

        commandHandler.AddCommand(leftButton, new PreviousVariantCommand());
        commandHandler.AddCommand(rightButton, new NextVariantCommand());
        inputHandler.AddCommand(KeyCode.U, new UndoCommand<CharacterCustomizable>(this));
    }

    private void Update()
    {
        ICommand<CharacterCustomizable> command = inputHandler.HandleInput();
        command?.Execute(this);
    }

    private void LoadSavedVariant()
    {
        int savedVariantIndex = meshList.savedVariantIndex;
        Variant savedVariant = meshList.variants[savedVariantIndex];
        UpdateVariantModelAndMaterial(savedVariant);
    }

    private void OnEnable()
    {
        //EventSystem.Subscribe(EventSystem.EventName.BUTTON_CLICK, CheckButtonClick);
        EventSystem.Subscribe(EventSystem.EventName.CHARACTER_DONE, ApplyVariant);
    }

    private void OnDisable()
    {
        //EventSystem.Unsubscribe(EventSystem.EventName.BUTTON_CLICK, CheckButtonClick);
        EventSystem.Unsubscribe(EventSystem.EventName.CHARACTER_DONE, ApplyVariant);
    }

    public void PreviousVariants()
    {
        history.Push(new PreviousVariantCommand());
        SwitchVariant(Direction.Previous);
    }

    public void NextVariants()
    {
        history.Push(new NextVariantCommand());
        SwitchVariant(Direction.Next);
    }

    public void Undo()
    {
        IReversibleCommand<CharacterCustomizable> command = history.Pop();
        command.Undo(this);
        // Push to redo stack
    }

    private void SwitchVariant(Direction direction)
    {
        if (meshList == null || meshList.variants.Count == 0) return;

        int variantCount = meshList.variants.Count;
        int directionValue = direction == Direction.Next ? 1 : -1;

        currentMeshIndex = ((currentMeshIndex + directionValue + variantCount) % meshList.variants.Count);
        currentVariant = meshList.variants[currentMeshIndex];
        UpdateVariantModelAndMaterial(currentVariant);
    }

    private void CheckButtonClick(EventSystem.EventName eventName, object _button)
    {
        if (_button.Equals(leftButton))
        {
            PreviousVariants();
        }
        else if (_button.Equals(rightButton))
        {
            NextVariants();
        }
    }

    public void UpdateVariantModelAndMaterial(Variant _variant)
    {
        meshFilter.mesh = _variant.mesh;
        meshRenderer.material = _variant.material;
    }

    private void ApplyVariant(EventSystem.EventName eventName, object _object)
    {
        meshList.savedVariantIndex = currentMeshIndex;
    }

    /*public void LoadVariant(Variant _variant)
    {
        currentVariant = _variant;
        UpdateVariantModelAndMaterial(_variant);
    }*/

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
