using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    public float maxSpeed = 3f;
    public float accelerationTime = 2f;
    public float accel = 1f;

    public Transform playerObj;

    private void Start()
    {
        accel = maxSpeed / accelerationTime;
    }

    private void Update()
    {
        MoveTowardsPlayer();
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
