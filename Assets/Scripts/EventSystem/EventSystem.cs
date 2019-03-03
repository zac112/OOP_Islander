using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventSystem
{
    static Dictionary<EventType, List<IAction>> events = new Dictionary<EventType, List<IAction>>();


    public static void AddEvent(EventType name, IAction target) {
        if (!events.ContainsKey(name))
            events.Add(name, new List<IAction>());
        events[name].Add(target);
    }

    public static void EventHappened(EventType name)
    {
        if (events.ContainsKey(name))
        {
            foreach (IAction e in events[name]){
                e.React(name);
            }
        }
    }
}
