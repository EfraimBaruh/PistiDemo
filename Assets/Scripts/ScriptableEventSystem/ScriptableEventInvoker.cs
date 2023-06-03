using UnityEngine;

namespace ScriptableEventSystem
{
    public class ScriptableEventInvoker : MonoBehaviour
    {
        [SerializeField] 
        private GameEvent _event;
        
        public void Raise()
        {
            _event.Raise();
        }
    }
}
