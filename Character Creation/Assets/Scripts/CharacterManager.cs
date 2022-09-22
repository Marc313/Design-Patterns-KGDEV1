/*using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, ICommandStackOwner<IReversibleCommand<CharacterCustomizable>>
{
    [SerializeField] private CharacterCustomizable[] customizables;

    private InputHandler<ICommand<CharacterCustomizable>> inputHandler;

    public Stack<IReversibleCommand<CharacterCustomizable>> history { get; private set; }

    private void Awake()
    {
        inputHandler = new InputHandler<ICommand<CharacterCustomizable>>();
    }

    private void Start()
    {
        inputHandler.AddCommand(KeyCode.U, new UndoCommand<CharacterCustomizable>(this));
    }

    private void Update()
    {
        ICommand<CharacterCustomizable> command = inputHandler.HandleInput();
        command?.Execute(customizables[0]);
    }

    public void Undo()
    {
        IReversibleCommand<CharacterCustomizable> command = history.Pop();
        command.Undo(customizables[0]);
    }
}
*/