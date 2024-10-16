using UnityEngine;
using UnityEngine.Events;

public class EventOnKeyPress : MonoBehaviour
{
    [Tooltip("Key that will call the event when it's pressed")]
    [SerializeField] KeyCode keyToCallEvent;
    [Tooltip("Event that will be called")]
    [SerializeField] UnityEvent m_EventKeyDown;
    void Start()
    {
        if (m_EventKeyDown == null)
            m_EventKeyDown = new UnityEvent();
    }

    void Update()
    {
        if (keyToCallEvent != KeyCode.None && m_EventKeyDown != null)
        {
            if (Input.GetKeyDown(keyToCallEvent))
            {
                m_EventKeyDown.Invoke();
            }
        }
    }
}
