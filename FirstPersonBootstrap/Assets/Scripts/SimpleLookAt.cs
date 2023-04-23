using UnityEngine;

/// <summary>
/// rotates to face the target only on Y axis
/// </summary>
public class SimpleLookAt : MonoBehaviour
{
    [SerializeField]
    Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
        }
    }
}
