using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJump : MonoBehaviour
{
    public float jumpForce = 5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= 0)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
