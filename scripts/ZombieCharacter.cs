using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCharacter : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody _rigidbody;
    private float _yRotation = 0f;
    private bool _jump = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        _yRotation += horizontal * rotationSpeed * Time.fixedDeltaTime;
        _rigidbody.MoveRotation(Quaternion.Euler(0f, _yRotation, 0f));
        _rigidbody.AddForce(transform.forward * vertical * moveSpeed);

        if (_jump)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
            _jump = false;
        } 
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            _jump = true;
    }
}
