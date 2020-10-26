using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float drive = 10;
    public float drag = 1;
    public float jumpImpulse = 50;

    private Vector3 dir = Vector3.zero;
    private bool jumpPressed = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dir = Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        // scale so it has a maximum length of 1 in any direction
        dir = Mathf.Max(Mathf.Abs(dir.x), Mathf.Abs(dir.z)) * dir.normalized;

        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(drive * dir);

        // drag in the opposite direction to velocity
        float speed = rigidbody.velocity.magnitude;
        Vector3 dragForce = drag * speed * -rigidbody.velocity;
        rigidbody.AddForce(dragForce);

        if (jumpPressed)
        {
            rigidbody.velocity = rigidbody.velocity + jumpImpulse * Vector3.up;
            // only add impulse on the first frame
            // rigidbody.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
            jumpPressed = false;
        }

    }
}
