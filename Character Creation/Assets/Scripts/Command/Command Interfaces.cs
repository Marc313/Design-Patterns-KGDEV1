using System.Collections.Generic;

public interface ICommand
{
    public void Execute();
}

public interface ICommand<T>
{
    public void Execute(T t);
} 

public interface IReversibleCommand : ICommand
{
    public void Undo();
}

public interface IReversibleCommand<T> : ICommand<T>
{
    public void Undo(T t);
}

public interface ICommandStackOwner<T>
{
    Stack<T> history { get; }

    public void Undo();
}