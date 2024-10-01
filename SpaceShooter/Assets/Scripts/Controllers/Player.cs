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


    public float testTime = 0.25f;
    public bool testingSpeed = true;

    public float accel = 1f;

    //public float accelerationTime = 4f;

    //public List<float> angles;

    private void Start()
    {

        accel = maxSpeed / accelerationTime;

        if (testingSpeed)
        {
            StartCoroutine(SpeedTest());
        }
    }

    void Update()
    {
        PlayerMovement();

        EnemyRadar(2f, 8);
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        //currentAngle = angles[counter];

        List<float> angles = new List<float>();

        for (int i = 0; i < circlePoints + 1; i++)
        {
            angles.Add(((360 / circlePoints) * i)    *    Mathf.Deg2Rad);
            Debug.Log(angles[i]);
        }


        float enemyDist = Vector3.Distance(enemyTransform.position, transform.position);

        Color lineColor = Color.white;
        if (enemyDist < radius)
        {
            lineColor = Color.red;
        } else {
            lineColor = Color.green;
        }

        for (int i = 0; i < angles.Count - 1; i++)
        {
            
            Debug.DrawLine(transform.position + new Vector3(Mathf.Cos(angles[i]), Mathf.Sin(angles[i])) * radius,
                transform.position + new Vector3(Mathf.Cos(angles[i+1]), Mathf.Sin(angles[i+1])) * radius, 
                lineColor);

        }

    }


    private void PlayerMovement()
    {

        if (!Input.anyKey)
        {
               if (velocity.magnitude > 0){

                if (velocity.x > 0)
                {
                    velocity += -Vector3.right * (accel * 0.25f) * Time.deltaTime;
                }

                if (velocity.x < 0)
                {
                    velocity += -Vector3.left * (accel * 0.25f) * Time.deltaTime;
                }

                if (velocity.y > 0)
                {
                    velocity += -Vector3.up * (accel * 0.25f) * Time.deltaTime;
                }

                if (velocity.y < 0)
                {
                    velocity += -Vector3.down * (accel * 0.25f) * Time.deltaTime;
                }
            }


        }


        //reset velocity, otherwise it keeps going when no keys are pressed
        //velocity = Vector3.zero;

        if (Input.GetKey("left") && PlayerWithinBounds(1))
        {
             velocity += Vector3.left * accel * Time.deltaTime;
            //velocity += Vector3.left * maxSpeed;
        }

        // USED FOR TESTING!
       if (Input.GetKey("right") && PlayerWithinBounds(2) || testingSpeed)
        {
            velocity += Vector3.right * accel * Time.deltaTime;
            // velocity += Vector3.right * maxSpeed;
        } 

        if (Input.GetKey("up") && PlayerWithinBounds(3))
        {
            velocity += Vector3.up * accel * Time.deltaTime;
            //velocity += Vector3.up * maxSpeed;
        }

        if (Input.GetKey("down") && PlayerWithinBounds(4))
        {
            velocity += Vector3.down * accel * Time.deltaTime;
            //velocity += Vector3.down * maxSpeed;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
    }

    private IEnumerator SpeedTest()
    {
        testingSpeed = true;
        yield return new WaitForSeconds(testTime);
        testingSpeed = false;
        Debug.Log("Current speed = " + velocity.x + " after " + testTime + " seconds." +
            "Should reach " + maxSpeed + " in " + accelerationTime + " seconds");      
    }


    // decel pseudocode!!! v 
    // set 'isKeyPressed' variables to false here, then set to true in each GetKey?
    // if any keyPressed values are false, apply decel time
    // or always * decel in each GetKey, just change decel outside of them?


    // velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

    //1 = left, //2 = right, 3 = up, 4 = down

    public bool PlayerWithinBounds(int bounds)
    {
        // could set the bounds as variables in case the boundaries need to change
        // i.e. "> verticalBounds" or "< -verticalBounds"

        // return true; //TESTING!

        if (bounds == 1 && transform.position.x < -18)
        { return false; }

        if (bounds == 2 && transform.position.x > 18)
        { return false; }

        if (bounds == 3 && transform.position.y > 9.5)
        { return false; }

        if (bounds == 4 && transform.position.y < -9.5)
        { return false; }

        return true;

    }

}
