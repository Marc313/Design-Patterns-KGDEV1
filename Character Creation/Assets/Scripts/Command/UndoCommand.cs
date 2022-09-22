using UnityEngine;

public class UndoCommand<T> : ICommand<T>
{
    ICommandStackOwner<IReversibleCommand<T>> owner;

    public UndoCommand(ICommandStackOwner<IReversibleCommand<T>> _owner)
    {
        owner = _owner;
    }

    public void Execute(T t)
    {
        Debug.Log("U pressed");
        owner.Undo();
    }
}
