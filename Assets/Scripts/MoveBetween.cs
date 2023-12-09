using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour //Inheritance from MonoBehaviour
{
    public Transform startPoint; // The starting point.
    public Transform endPoint;   // The ending point.
    public float moveSpeed = 2.0f; // Adjust the movement speed as needed.
    // the reason why we use public is because we want to expose the variable to Unity Inspector.
    // oop : encapsulation.

    private Vector3 currentTarget; // The current target position.
    //declare a variable named currentTarget of type Vector3.

    private void Start()
    {
        // Initialize the current target to the starting point.
        currentTarget = startPoint.position;
    }

    private void Update()
    {
        // Move the platform towards the current target position.
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // If the platform reaches the current target, switch to the other target.
        if (transform.position == currentTarget)
        {
            currentTarget = (currentTarget == startPoint.position) ? endPoint.position : startPoint.position;
            // if the currentTarget is equal to startPoint.position, then update teh current target to endPoint position, else currentTarget = startPoint.position.
        }
    }
}
