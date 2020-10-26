using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float drive = 10;
    public float drag = 1;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        // scale so it has a maximum length of 1 in any direction
        dir = Mathf.Max(Mathf.Abs(dir.x), Mathf.Abs(dir.z)) * dir.normalized;
        rigidbody.AddForce(drive * dir);

        // drag in the opposite direction to velocity
        float speed = rigidbody.velocity.magnitude;
        Vector3 dragForce = drag * speed * -rigidbody.velocity;
        rigidbody.AddForce(dragForce);
    }
}
