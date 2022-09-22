using UnityEngine;

public class UndoCommand : ICommand
{
    private ICommandStackOwner<IReversibleCommand> owner;

    public UndoCommand(ICommandStackOwner<IReversibleCommand> _owner)
    {
        owner = _owner;
    }

    public void Execute()
    {
        owner.Undo();
    }
}
