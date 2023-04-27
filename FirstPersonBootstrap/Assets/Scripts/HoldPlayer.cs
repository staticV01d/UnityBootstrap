using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayer : MonoBehaviour
{
    MovingPlatform platform;

    const string player = "Player";

    void Start()
    {
        platform = GetComponentInParent<MovingPlatform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player))
        {
            other.transform.parent = transform;
            platform.SetIsOccupied(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(player))
        {
            other.transform.parent = null;
            platform.SetIsOccupied(false);
        }
    }
}
