using UnityEngine;
using UnityEngine.UI;

public class UIObserver : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void CharacterDoneClicked()
    {
        EventSystem.RaiseEvent(EventSystem.EventName.CHARACTER_DONE, button);
    }
}
