using System.Collections.Generic;
using UnityEngine.UI;

public class UICommandHandler<T>
{
    private Dictionary<Button, List<ICommand>> commands;
    private T customizable;

    public UICommandHandler(T _customizable)
    {
        commands = new Dictionary<Button, List<ICommand>>();
        customizable = _customizable;
    }

    public void AddCommand(Button button, IReversibleCommand command)
    {
        if (commands.ContainsKey(button) && commands[button] == null)
        {
            commands[button] = new List<ICommand>();
        }
        else if (commands.ContainsKey(button) && commands[button] != null)
        {
            commands[button].Add(command);
        }
        else
        {
            commands.Add(button, new List<ICommand>());
        }

        button.onClick.AddListener(() => command.Execute());
    }
}
