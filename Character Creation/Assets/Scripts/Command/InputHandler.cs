using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    Dictionary<KeyCode, ICommand> commands = new Dictionary<KeyCode, ICommand>();

    public void AddCommand(KeyCode key, ICommand command)
    {
        commands.Add(key, command);
    }

    public ICommand HandleInput()
    {
        foreach (KeyCode key in commands.Keys)
        {
            if (Input.GetKeyDown(key)) { return commands[key]; }
        }
        return null;
    }
}
