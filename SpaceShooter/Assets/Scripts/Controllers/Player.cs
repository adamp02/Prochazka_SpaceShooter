using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;



    private Vector3 velocity = Vector3.zero;

    //public float targetSpeed = 3f;
    //public float timeToReachTargetSpeed = 2f;

    public float maxSpeed = 3f;
    public float accelerationTime = 2f;

    public float accel = 1f;

    //public float accelerationTime = 4f;


    private void Start()
    {
        accel = maxSpeed / accelerationTime;
        //accel = targetSpeed / timeToReachTargetSpeed;
    }

    void Update()
    {

        PlayerMovement();

        

    }




    private void PlayerMovement()
    {

        //reset velocity, otherwise it keeps going when no keys are pressed
        //velocity = Vector3.zero;

        // set 'isKeyPressed' variables to false here, then set to true in each GetKey
        // if any keyPressed values are false, apply decel time
        // or always * decel in each GetKey, just change decel outside of them?

        if (Input.GetKey("left") && PlayerWithinBounds(1))
        {
            velocity += Vector3.left * accel * Time.deltaTime;
        }

       if (Input.GetKey("right") && PlayerWithinBounds(2))
        {
            velocity += Vector3.right * accel * Time.deltaTime;
        } 

        if (Input.GetKey("up") && PlayerWithinBounds(3))
        {
            velocity += Vector3.up * accel * Time.deltaTime;
        }

        if (Input.GetKey("down") && PlayerWithinBounds(4))
        {
            velocity += Vector3.down * accel * Time.deltaTime;
        }

        //velocity = velocity.normalized * moveSpeed;

        /* if (velocity.x > maxSpeed)
         {
             velocity.x = maxSpeed;
         }

         if (velocity.x < -maxSpeed)
         {
             velocity.x = -maxSpeed;
         }

         if (velocity.y > maxSpeed)
         {
             velocity.y = maxSpeed;
         }

         if (velocity.y < -maxSpeed)
         {
             velocity.y = -maxSpeed;
         }*/
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);


        transform.position += velocity * Time.deltaTime;



    }

    //1 = left, //2 = right, 3 = up, 4 = down

    public bool PlayerWithinBounds(int bounds)
    {
        // could set the bounds as variables in case the boundaries need to change
        // i.e. "> verticalBounds" or "< -verticalBounds"

        return true; //TESTING!

        if (bounds == 1 && transform.position.x < -18)
        { 
            velocity = Vector3.zero;
            return false;
        }

        if (bounds == 2 && transform.position.x > 18)
        { return false; }

        if (bounds == 3 && transform.position.y > 9.5)
        { return false; }

        if (bounds == 4 && transform.position.y < -9.5)
        { return false; }

        return true;

    }

}
