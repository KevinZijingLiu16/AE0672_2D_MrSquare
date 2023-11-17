using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    public Transform startPoint; // The starting point.
    public Transform endPoint;   // The ending point.
    public float moveSpeed = 2.0f; // Adjust the movement speed as needed.

    private Vector3 currentTarget; // The current target position.

    private void Start()
    {
        // Initialize the current target to the starting point.
        currentTarget = startPoint.position;
    }

    private void Update()
    {
        // Move the trap towards the current target position.
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // If the trap reaches the current target, switch to the other target.
        if (transform.position == currentTarget)
        {
            currentTarget = (currentTarget == startPoint.position) ? endPoint.position : startPoint.position;
        }
    }
}
