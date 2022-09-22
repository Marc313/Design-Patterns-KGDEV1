using System.Collections.Generic;
using UnityEngine;

public class InputHandler<T>
{
    private Dictionary<KeyCode, T> commands = new Dictionary<KeyCode, T>();

    public void AddCommand(KeyCode key, T command)
    {
        commands.Add(key, command);
    }

    public T HandleInput()
    {
        foreach (KeyCode key in commands.Keys)
        {
            if (Input.GetKeyDown(key)) { return commands[key]; }
        }
        return default(T);
    }
}
