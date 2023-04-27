using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base class for interactive Game Objects
/// </summary>
public class Interact : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public UnityEvent onInteract = new();

    [SerializeField, ReadOnly]
    bool isNear;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameObject.InitializeTrigger();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isNear)
        {
            if (Input.GetKeyDown(interactKey))
            {
                onInteract?.Invoke();
            }
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.IsPlayer())
        {
            isNear = true;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.IsPlayer())
        {
            isNear = false;
        }
    }
}
