using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizable : MonoBehaviour
{
    public enum Direction { Next, Previous };

    [SerializeField] private sMeshList meshList;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private int currentMeshIndex;
    private Variant currentVariant;

    private ICommandStackOwner<IReversibleCommand> commandStackOwner;
    private UICommandHandler<CharacterCustomizable> commandHandler;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        commandHandler = new UICommandHandler<CharacterCustomizable>(this);
    }

    private void Start()
    {
        LoadSavedVariant();

        commandHandler.AddCommand(leftButton, new PreviousVariantCommand(this));
        commandHandler.AddCommand(rightButton, new NextVariantCommand(this));
    }

    private void OnEnable()
    {
        EventSystem.Subscribe(EventSystem.EventName.CHARACTER_DONE, ApplyVariant);
    }

    private void OnDisable()
    {
        EventSystem.Unsubscribe(EventSystem.EventName.CHARACTER_DONE, ApplyVariant);
    }

    public void InjectStackOwner(ICommandStackOwner<IReversibleCommand> _stackOwner)
    {
        commandStackOwner = _stackOwner;
    }

    public void PreviousVariants(bool _addToHistory = true)
    {
        if (_addToHistory)
        {
            commandStackOwner.history.Push(new PreviousVariantCommand(this));
        }

        SwitchVariant(Direction.Previous);
    }

    public void NextVariants(bool _addToHistory = true)
    {
        if (_addToHistory)
        {
            commandStackOwner.history.Push(new NextVariantCommand(this));
        }

        SwitchVariant(Direction.Next);
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

    private void LoadSavedVariant()
    {
        int savedVariantIndex = meshList.savedVariantIndex;
        currentMeshIndex = savedVariantIndex;
        Variant savedVariant = meshList.variants[savedVariantIndex];
        UpdateVariantModelAndMaterial(savedVariant);
    }

    private void UpdateVariantModelAndMaterial(Variant _variant)
    {
        meshFilter.mesh = _variant.mesh;
        meshRenderer.material = _variant.material;
    }

    private void ApplyVariant(EventSystem.EventName eventName, object _object)
    {
        meshList.savedVariantIndex = currentMeshIndex;
    }
}
