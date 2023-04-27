using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode runKey = KeyCode.LeftShift;

    string forwardAxis = "Vertical";
    string strafeAxis = "Horizontal";

    float moveSpeed;
    [SerializeField, ReadOnly]
    Vector2 move;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveSpeed = Input.GetKey(runKey) ? runSpeed : walkSpeed;
        move = new Vector2(Input.GetAxis(strafeAxis), Input.GetAxis(forwardAxis));
    }

    void FixedUpdate()
    {
        var movementForce = moveSpeed * move.x * transform.right + moveSpeed * move.y * transform.forward + new Vector3(0, rb.velocity.y, 0);

        if (move != Vector2.zero)
        {
            rb.AddForce(movementForce);
        }
    }
}
