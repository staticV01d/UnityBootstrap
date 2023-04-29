using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistance : MonoBehaviour
{
    [SerializeField]
    GameObject A, B;

    // Start is called before the first frame update
    void Start()
    {
        if (A && B)
        {
            print(GetDistanceFromAtoB() + "m");
        }
    }

    float GetDistanceFromAtoB()
    {
        return (A.transform.position - B.transform.position).magnitude;
    }
}
