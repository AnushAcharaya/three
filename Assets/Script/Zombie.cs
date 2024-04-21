using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Zombie : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the zombie
    public float changeDirectionInterval = 2f; // Interval at which the zombie changes direction
    public float maxDistance = 10f; // Maximum distance the zombie can travel from its starting point

    private Vector3 startingPosition;
    private float timer;

    void Start()
    {
        startingPosition = transform.position;
        timer = changeDirectionInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            ChangeDirection();
            timer = changeDirectionInterval;
        }

        // Move the zombie
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // Generate a random direction within a 180 degree cone
        float angle = Random.Range(-90f, 90f);
        Vector3 newDirection = Quaternion.Euler(0f, angle, 0f) * transform.forward;

        // Check if the new position will still be within max distance
        Vector3 newPosition = transform.position + newDirection;
        float distance = Vector3.Distance(startingPosition, newPosition);
        if (distance <= maxDistance)
        {
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
