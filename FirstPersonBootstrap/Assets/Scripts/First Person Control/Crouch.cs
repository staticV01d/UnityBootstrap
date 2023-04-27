using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputStyle { Hold, Toggle }

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Crouch : MonoBehaviour
{
    public float crouchAmount = 0.25f;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public InputStyle inputStyle = InputStyle.Hold;

    private Rigidbody rb;
    private float normalYLocalPosition = 1;

    bool isCrouching;

    float crouching;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalYLocalPosition = rb.transform.localScale.y;
        crouching = normalYLocalPosition - crouchAmount;
    }


    void Update()
    {
        HandleCrouching();
    }

    void HandleCrouching()
    {
        switch (inputStyle)
        {
            case InputStyle.Hold:
                if (Input.GetKey(crouchKey))
                {
                    if (!isCrouching)
                        StartCrouch();
                }
                else
                {
                    EndCrouch();
                }
                break;
            case InputStyle.Toggle:
                if (Input.GetKeyDown(crouchKey))
                {
                    if (isCrouching)
                    {
                        EndCrouch();
                    }
                    else
                    {
                        StartCrouch();
                    }
                }
                break;
        }
    }

    void StartCrouch()
    {
        rb.transform.localScale = new Vector3(rb.transform.localScale.x, crouching, rb.transform.localScale.z);
        isCrouching = true;
    }

    void EndCrouch()
    {
        rb.transform.localScale = new Vector3(rb.transform.localScale.x, normalYLocalPosition, rb.transform.localScale.z);
        isCrouching = false;
    }
}
