using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float distanceToReach = 0.5f;
    public Transform firstPoint, secondPoint;
    public bool movingToFirstPoint;

    [Header("Random Points")]
    public bool randomPoints;

    private Vector3 _firstPointPosition, _secondPointPosition;

    private void Awake()
    {
        if (randomPoints)
        {
            var randomX1 = Random.Range(-1f, 1f);
            var randomX2 = Random.Range(-1f, 1f);
            var randomZ1 = Random.Range(-1f, 1f);
            var randomZ2 = Random.Range(-1f, 1f);
            _firstPointPosition = transform.position + new Vector3(randomX1, 0f, randomZ1);
            _secondPointPosition = transform.position + new Vector3(randomX2, 0f, randomZ2);
        }
        else
        {
            _firstPointPosition = firstPoint.position;
            _secondPointPosition = secondPoint.position;
        }
    }

    private void Update()
    {
        Vector3 destination = movingToFirstPoint ? _firstPointPosition : _secondPointPosition;
        Vector3 direction = (destination - transform.position).normalized;
        transform.LookAt(destination);
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, destination) <= distanceToReach)
            movingToFirstPoint = !movingToFirstPoint;
    }
}
