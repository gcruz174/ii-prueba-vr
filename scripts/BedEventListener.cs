using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedEventListener : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;

    private BedEventSender _bedEventSender;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _bedEventSender = GameObject.FindWithTag("PersonBed").GetComponent<BedEventSender>();
        _bedEventSender.OnApproachBed += OnApproachBed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        if (_bedEventSender != null)
            _bedEventSender.OnApproachBed -= OnApproachBed;
    }

    private void OnApproachBed()
    {
        if (gameObject.CompareTag("Chair"))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
        }
        else if (gameObject.CompareTag("NormalBed"))
        {
            _rigidbody.AddForce(-transform.forward * moveForce);
        }
    }
}
