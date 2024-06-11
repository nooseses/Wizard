using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float normalSpeed = 5f;
    private float currentSpeed;
    private bool isSlowed = false;
    private float slowFactor;
    private float slowDuration;
    private float slowEndTime;
    public float speed = 1.0f;  // Speed of the cube movement
    public Vector3 areaSize = new Vector3(10, 0, 10);  // Size of the area within which the cube can move
    private Vector3 targetPosition;

    void Start()
    {
        // Set an initial random target position
        SetRandomTargetPosition();
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Move the cube towards the target position
        MoveTowardsTarget();

        // If the cube has reached the target position, set a new target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
        if (isSlowed && Time.time >= slowEndTime)

        {
            // Slow effect has expired, return to normal speed
            currentSpeed = normalSpeed;
            isSlowed = false;
        }
    }

    void SetRandomTargetPosition()
    {
        // Generate a random position within the area
        float randomX = Random.Range(-areaSize.x / 2, areaSize.x / 2);
        float randomZ = Random.Range(-areaSize.z / 2, areaSize.z / 2);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    void MoveTowardsTarget()
    {
        // Move the cube towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    public void ApplySlow(float factor, float duration)
    {
        if (!isSlowed || duration > (slowEndTime - Time.time))
        {
            slowFactor = factor;
            slowDuration = duration;
            slowEndTime = Time.time + duration;
            isSlowed = true;
            currentSpeed *= factor;
        }
    }
}