using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    public Transform orbitAround;
    float currentAngle = 0f;
    public float rotationSpeed = 0.05f;
    public float radius = 1f;
    public float detectionRange = 5f;


    private Vector3 velocity = Vector3.zero;
    public float maxSpeed = 3f;
    public float accelerationTime = 2f;
    public float accel = 1f;

    public Transform playerObj;

    bool isDetached = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!isDetached)
        {
            PlayerDetection();
            OrbitalMotion(radius, rotationSpeed, orbitAround);
        }
        
        else
        {
            MoveTowardsPlayer();
        }
    }


    public void PlayerDetection()
    {
        float distanceToTarget = Vector3.Distance(transform.position, playerObj.position);

        if (distanceToTarget <= detectionRange)
        {
            isDetached = true;
        }

    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        if (currentAngle > 360) { currentAngle = 0f; }
        currentAngle += speed * Time.deltaTime;

        float rad = currentAngle * Mathf.Deg2Rad;

        Vector3 p = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

        transform.position = target.position + p;


    }

    public void MoveTowardsPlayer()
    {

        if (playerObj.position.x > transform.position.x)
        {
            velocity += Vector3.right * accel * Time.deltaTime;
        }

        if (playerObj.position.x < transform.position.x)
        {
            velocity += Vector3.left * accel * Time.deltaTime;
        }

        if (playerObj.position.y < transform.position.y)
        {
            velocity += Vector3.down * accel * Time.deltaTime;
        }

        if (playerObj.position.y > transform.position.y)
        {
            velocity += Vector3.up * accel * Time.deltaTime;
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
    }

}
