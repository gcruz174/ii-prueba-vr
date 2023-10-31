using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : MonoBehaviour
{
    public float jumpForce = 50f;

    public delegate void KillEvent();
    public static event KillEvent OnKilled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody.velocity.y < 0 && playerRigidbody.transform.position.y > transform.position.y) 
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce);
                OnKilled?.Invoke();
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
