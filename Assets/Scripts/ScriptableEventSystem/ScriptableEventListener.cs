using System.Collections.Generic;
using ScriptableEventSystem;
using UnityEngine;

namespace ScriptableEventSystem
{
    public class ScriptableEventListener : MonoBehaviour
    {
        public List<GameEventListener> GameEventListeners;

        public void OnEnable()
        {
            foreach (var eventListener in GameEventListeners)
                eventListener.OnEnable();
        }

        public void OnDisable()
        {
            foreach (var eventListener in GameEventListeners)
                eventListener.OnDisable();
        }
        
    }
}
