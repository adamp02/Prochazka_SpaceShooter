using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public Vector2 newPos = new Vector2(0f, 0f);
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        SetTarget();
    }

    void Update()
    {
        AsteroidMovement();
    }


    public void SetTarget()
    {
        newPos = new Vector2(transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance),
            transform.position.y + Random.Range(-maxFloatDistance, maxFloatDistance));
    }

    public void AsteroidMovement()
    {
        if (newPos.x > transform.position.x)
        {
            velocity += Vector3.right * moveSpeed;
        }

        if (newPos.x < transform.position.x)
        {
            velocity += Vector3.left * moveSpeed;
        }

        if (newPos.y > transform.position.y)
        {
            velocity += Vector3.up * moveSpeed;
        }

        if (newPos.y < transform.position.y)
        {
            velocity += Vector3.down * moveSpeed;
        }

        float distance = Vector3.Distance(newPos, transform.position);
        if (distance < arrivalDistance)
        {
            SetTarget();
        }

        transform.position += velocity * Time.deltaTime;

    }

}
