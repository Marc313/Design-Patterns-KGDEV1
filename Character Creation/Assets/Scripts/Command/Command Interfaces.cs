using System.Collections.Generic;

public interface ICommand
{
    public void Execute();
}

public interface IReversibleCommand : ICommand
{
    public void Undo();
}

public interface ICommandStackOwner<T>
{
    Stack<T> history { get; }

    public void Undo();
    public void AddCommandToHistory(T command);
}