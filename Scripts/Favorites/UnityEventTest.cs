using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    [SerializeField] UnityEvent m_EventSpaceDown;
    
    void Start()
    {
        if (m_EventSpaceDown == null)
            m_EventSpaceDown = new UnityEvent();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_EventSpaceDown != null)
        {
            m_EventSpaceDown.Invoke();
        }
    }

}
