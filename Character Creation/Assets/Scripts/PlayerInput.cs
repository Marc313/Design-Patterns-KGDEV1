using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputHandler<ICommand> inputHandler;

    private void Awake()
    {
        inputHandler = new InputHandler<ICommand>();
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
