using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEventSystem
{
    [Serializable]
    public class GameEventListener
    {
        public GameEvent Event;
        public UnityEvent Response;

        public void OnEnable()
        { Event.RegisterListener(this); }

        public void OnDisable()
        { Event.UnregisterListener(this); }

        public void OnEventRaised()
        { Response.Invoke(); }
    }
}