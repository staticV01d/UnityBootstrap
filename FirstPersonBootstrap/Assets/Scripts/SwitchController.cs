using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    Animator m_animator;
    int isOnHash = Animator.StringToHash("isOn");

    public UnityEvent onActivated, onDeactivated;

    [SerializeField]
    InteractiveSwitch iSwitch;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void ToggleSwitch()
    {
        if (m_animator.GetBool(isOnHash))
        {
            m_animator.SetBool(isOnHash, false);
        }
        else
        {
            m_animator.SetBool(isOnHash, true);
        }
    }

    public void Activate()
    {
        onActivated?.Invoke();
    }

    public void Deactivate()
    {
        onDeactivated?.Invoke();
    }
}
