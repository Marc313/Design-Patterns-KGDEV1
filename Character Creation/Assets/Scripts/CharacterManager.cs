using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, ICommandStackOwner<IReversibleCommand>
{
    public Stack<IReversibleCommand> history { get; private set; } = new Stack<IReversibleCommand>();

    [SerializeField] private CharacterCustomizable[] customizables;
    private InputHandler<ICommand> inputHandler;


    private void Awake()
    {
        inputHandler = new InputHandler<ICommand>();
        InjectSelfOnCustomizable();
    }

    private void Start()
    {
        inputHandler.AddCommand(KeyCode.U, new UndoCommand(this));
    }

    private void Update()
    {
        ICommand command = inputHandler.HandleInput();
        command?.Execute();
    }

    public void Undo()
    {
        if (history.Count > 0)
        {
            IReversibleCommand command = history.Pop();
            command.Undo();
        }
    }

    public void AddCommandToHistory(IReversibleCommand command)
    {
        history.Push(command);
    }

    private void InjectSelfOnCustomizable()
    {
        foreach(CharacterCustomizable cc in customizables)
        {
            cc.InjectStackOwner(this);
        }
    }
}
