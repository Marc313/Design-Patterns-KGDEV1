using System.Collections.Generic;
using UnityEngine.UI;

public class UICommandHandler<T>
{
    private Dictionary<Button, List<IReversibleCommand>> commands;
    private T customizable;

    public UICommandHandler(T _customizable)
    {
        commands = new Dictionary<Button, List<IReversibleCommand>>();
        customizable = _customizable;
    }

    public void AddCommand(Button button, IReversibleCommand command)
    {
        if (commands.ContainsKey(button) && commands[button] == null)
        {
            commands[button] = new List<IReversibleCommand>();
        }
        else if (commands.ContainsKey(button) && commands[button] != null)
        {
            commands[button].Add(command);
        }
        else
        {
            commands.Add(button, new List<IReversibleCommand>());
        }

        button.onClick.AddListener(() => command.Execute());
    }

    /*private void AddCommandsAsButtonListener()
    {
        foreach (Button button in commands.Keys)
        {
            foreach (IReversibleCommand<CharacterCustomizable> command in commands[button])
            {
                button.onClick.AddListener(() => command.Execute(customizable));
            }
        }
    }*/
}
