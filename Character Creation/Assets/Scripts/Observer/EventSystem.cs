using System.Collections.Generic;

public delegate void EventCallback(EventSystem.EventName eventName, object value);

public static class EventSystem
{
    public enum EventName
    {
        BUTTON_CLICK,
        SECTION_DONE,
        CHARACTER_DONE
    }

    private static Dictionary<EventName, List<EventCallback>> eventRegister = new Dictionary<EventName, List<EventCallback>>();

    public static void Subscribe(EventName eventName, EventCallback func)
    {
        if (!eventRegister.ContainsKey(eventName))
        {
            eventRegister[eventName] = new List<EventCallback>();
        }

        eventRegister[eventName].Add(func);
    }

    public static void Unsubscribe(EventName eventName, EventCallback func)
    {
        if (eventRegister.ContainsKey(eventName))
        {
            eventRegister[eventName].Remove(func);
        }
    }

    public static void RaiseEvent(EventName eventName, object value)
    {
        if (eventRegister.ContainsKey(eventName))
        {
            foreach (EventCallback e in eventRegister[eventName])
            {
                e.Invoke(eventName, value);
            }
        }
    }
}

