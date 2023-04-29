using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public float jumpStrength = 5;
    public KeyCode jumpKey = KeyCode.Space;

    private Rigidbody rb;

    // Ground check 
    private bool isGrounded = true;

    [SerializeField]
    float rayLength = 1.45f;

    [SerializeField]
    float groundCheckRadius = .5f;

    /// <summary>
    /// What layers to reconize as 'Ground'
    /// </summary>
    [SerializeField]
    LayerMask groundMask;

    Move playerMovementComponent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMovementComponent = FindAnyObjectByType<Move>();
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded && playerMovementComponent.canMove)
        {
            rb.AddForce(rb.transform.up * jumpStrength, ForceMode.Impulse);
        }

        isGrounded = GroundCheck();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + rayLength * (Vector3.up * -1), groundCheckRadius);
    }

    bool GroundCheck()
    {
        var ray = new Ray()
        {
            origin = transform.position,
            direction = Vector3.up * -1
        };

        return Physics.SphereCast(ray, groundCheckRadius, rayLength, groundMask, QueryTriggerInteraction.UseGlobal);
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = true;
    //     }
    // }

    // private void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = false;
    //     }
    // }
}
