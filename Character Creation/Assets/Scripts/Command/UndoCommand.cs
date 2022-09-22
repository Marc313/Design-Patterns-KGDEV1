using UnityEngine;

public class UndoCommand : ICommand
{
    ICommandStackOwner<IReversibleCommand> owner;

    public UndoCommand(ICommandStackOwner<IReversibleCommand> _owner)
    {
        owner = _owner;
    }

    public void Execute()
    {
        Debug.Log("U pressed");
        owner.Undo();
    }
}
