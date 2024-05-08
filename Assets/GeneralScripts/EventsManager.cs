using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
   public static EventsManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EventsManager();
            return instance;
        }
    }

    private static EventsManager instance;

    private Dictionary<string, List<IListener>> events = new();

    public void AddListener(string eventID, IListener p_listener)
    {
        if (events.TryGetValue(eventID, out var listeners) && !listeners.Contains(p_listener))
        {
            listeners.Add(p_listener);
        }
    }

    public void RemoveListener(string eventID, IListener p_listener)
    {
        if (events.TryGetValue(eventID, out var listeners) && listeners.Contains(p_listener))
        {
            listeners.Remove(p_listener);
        }
    }

    public void DispatchSimpleEvent(string eventID)
    {
        if (events.TryGetValue(eventID, out var listeners))
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventDispatch();
            }
        }
    }

    public void RegisterEvent(string eventID)
    {
        if (!events.ContainsKey(eventID))
        {
            events[eventID] = new List<IListener>();
        }
    }
}
