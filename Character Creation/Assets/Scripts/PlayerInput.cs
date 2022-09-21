using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputHandler inputHandler;

    private void Awake()
    {
        inputHandler = new InputHandler();
    }

    void Start()
    {
        inputHandler.AddCommand(KeyCode.E, new GoToCreatorCommand());
    }

    void Update()
    {
        ICommand command = inputHandler.HandleInput();
        command?.Execute();
    }
}
