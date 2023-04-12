using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody _rb;
    Vector3 lastVelocity;
    private float minVelocity=20f;
    private Vector3 initialVelocity;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = initialVelocity;       
    }

    private void Update()
    {
        lastVelocity = _rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }
    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastVelocity.magnitude*0.3f;
        var direction = Vector3.Reflect(lastVelocity.normalized, collisionNormal);
        transform.rotation = Quaternion.LookRotation(direction);
        _rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}
