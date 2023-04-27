using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Base class for interactive Game Objects
/// </summary>
public class Interact : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public UnityEvent onInteract = new();
    public string info = "(E) Interact";
    public TextMeshPro interactText;

    [SerializeField, ReadOnly]
    bool isNear;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameObject.InitializeTrigger();
        SetInteractText(info);
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
            ShowText(isNear);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.IsPlayer())
        {
            isNear = false;
            ShowText(isNear);
        }
    }

    public void SetInteractText(string text)
    {
        if (interactText)
        {
            interactText.text = text;
        }
    }

    public void ShowText(bool show)
    {
        if (interactText)
        {
            interactText.gameObject.SetActive(show);
        }
    }
}
