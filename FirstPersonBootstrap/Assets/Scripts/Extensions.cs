using UnityEngine;

public static class Extensions
{
    public static bool IsActive(this GameObject go)
    {
        return go.activeInHierarchy;
    }

    /// <summary>
    /// Sets to required settings for a GameObject to be used as a trigger volume
    /// </summary>
    public static void InitializeTrigger(this GameObject go)
    {
        var trigger = go.GetComponent<Collider>();

        if (!trigger)
        {
            Debug.LogError("You tried to initialize a trigger object that does not have a collider attached.");
            return;
        }

        var ignoreRaycast = LayerMask.NameToLayer("Ignore Raycast");

        if (go.layer != ignoreRaycast)
        {
            go.layer = ignoreRaycast;
        }

        if (go.transform.localScale != Vector3.one)
            go.transform.localScale = Vector3.one;

        if (!trigger.isTrigger)
            trigger.isTrigger = true;
    }

    public static bool IsPlayer(this GameObject go)
    {
        return go.CompareTag("Player");
    }
}
