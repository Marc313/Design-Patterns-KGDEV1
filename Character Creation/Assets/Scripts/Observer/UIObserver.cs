using UnityEngine;
using UnityEngine.UI;

public class UIObserver : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void PijltjeClicked()
    {
        //EventSystem.RaiseEvent(EventSystem.EventName.BUTTON_CLICK, button);
    }

    public void SectionDoneClicked()
    {
        //EventSystem.RaiseEvent(EventSystem.EventName.CHARACTER_DONE, button);
    }
}
