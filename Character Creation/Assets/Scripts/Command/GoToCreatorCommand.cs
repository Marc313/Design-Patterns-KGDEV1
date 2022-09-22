using UnityEngine.SceneManagement;

public class GoToCreatorCommand : ICommand
{
    public void Execute()
    {
        SceneManager.LoadScene(0);
    }
}
