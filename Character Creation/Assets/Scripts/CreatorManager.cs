using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatorManager : MonoBehaviour
{
    public enum Direction { Next, Previous };

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        EventSystem.Subscribe(EventSystem.EventName.CHARACTER_DONE, LoadNextScene);
    }

    private void OnDisable()
    {
        EventSystem.Subscribe(EventSystem.EventName.CHARACTER_DONE, LoadNextScene);
    }

    public void LoadPreviousScene()
    {
        SwitchScene(Direction.Previous);
    }

    public void LoadNextScene(EventSystem.EventName eventName, object _object)
    {
        SwitchScene(Direction.Next);
    }

    public void SwitchScene(Direction dir)
    {
        int directionValue = dir == Direction.Next ? 1 : -1;

        // Hoe zorg je dat deze later gaat?
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
