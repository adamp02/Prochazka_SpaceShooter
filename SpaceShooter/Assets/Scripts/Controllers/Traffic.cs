using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Traffic : MonoBehaviour
{

    public Rigidbody2D rb;
    public float sightDistance = 1.5f;
    public float visionAngle = 20f;
    public float currentDirection = 0;
    public float maxMovementSpeed = 2f;
    public float movementSpeed = 2f;


    public Transform targetTransform;

    public float swerveSpeed = 2f;

    public float lane = 0f;

    bool isSwerving = false;

    public bool isVertical = true;

    public float xLimit = 50f;
    public float yLimit = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        rb.AddForce(transform.up.normalized * movementSpeed);
        newWay();


        if (!isSwerving && isVertical)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(lane, transform.position.y, transform.position.z), 0.003f);

            Debug.DrawLine(transform.position, new Vector3(lane, transform.position.y, transform.position.z), UnityEngine.Color.magenta);
        }

        else if (!isSwerving && !isVertical)
        {

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, lane, transform.position.z), 0.003f);
            Debug.DrawLine(transform.position, new Vector3(transform.position.x, lane, transform.position.z), UnityEngine.Color.magenta);
        }

        if (isVertical)
        {
            if (transform.position.y >= yLimit)
            {
                transform.position = new Vector3(transform.position.x, -yLimit + 1f, transform.position.z);
            }

            if (transform.position.y <= -yLimit)
            {
                transform.position = new Vector3(transform.position.x, yLimit - 1f, transform.position.z);
            }
        }


        if (!isVertical)
        {
            if (transform.position.x >= xLimit)
            {
                transform.position = new Vector3(-xLimit + 1f, transform.position.y, transform.position.z);
            }

            if (transform.position.x <= -xLimit)
            {
                transform.position = new Vector3(xLimit - 1f, transform.position.y, transform.position.z);
            }
        }


    }

    public void newWay()
    {




        Vector3 straightVector = transform.up;

        float straightAngle = Mathf.Atan2(straightVector.y, straightVector.x) * Mathf.Rad2Deg;
        float leftAngle = straightAngle + visionAngle / 2;
        float rightAngle = straightAngle - visionAngle / 2;

        Vector3 leftVector = MathUtil.AngleToVector(leftAngle);
        Vector3 rightVector = MathUtil.AngleToVector(rightAngle);

        UnityEngine.Color lineColour = UnityEngine.Color.red;

        // within visionAngle & sightDistance
        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);
        bool isEnemyCloseEnough = distanceToTarget < sightDistance;

        float deltaAngle = Vector3.Angle(straightVector, targetTransform.position - transform.position);
        float deltaAngleSize = Mathf.Abs(deltaAngle);
        bool isObjectInFOV = deltaAngleSize < visionAngle / 2;

        bool isInRange = isEnemyCloseEnough && isObjectInFOV;


        if (isInRange)
        {
            if (distanceToTarget >= 1.7)
            {

                if(isVertical) // this is brute force -> improve by getting the angle
                {

                    if (targetTransform.position.x > transform.position.x && targetTransform.position.y > transform.position.y
                    || targetTransform.position.x < transform.position.x && targetTransform.position.y < transform.position.y)
                    {
                        rb.AddForce(-transform.right * swerveSpeed * Time.deltaTime);
                        Debug.DrawLine(transform.position, -transform.right * 3 + transform.position, UnityEngine.Color.magenta);
                    }


                    if (targetTransform.position.x <= transform.position.x && targetTransform.position.y > transform.position.y
                        || targetTransform.position.x > transform.position.x && targetTransform.position.y < transform.position.y)
                    {
                        rb.AddForce(transform.right * swerveSpeed * Time.deltaTime);
                        Debug.DrawLine(transform.position, transform.right * 3 + transform.position, UnityEngine.Color.magenta);
                    }
                }




                if (!isVertical)
                {

                    if (targetTransform.position.x > transform.position.x && targetTransform.position.y < transform.position.y
                    || targetTransform.position.x < transform.position.x && targetTransform.position.y > transform.position.y)
                    {
                        rb.AddForce(-transform.right * swerveSpeed * Time.deltaTime);
                        Debug.DrawLine(transform.position, -transform.right * 3 + transform.position, UnityEngine.Color.magenta);

                    }


                    if (targetTransform.position.x <= transform.position.x && targetTransform.position.y < transform.position.y
                        || targetTransform.position.x > transform.position.x && targetTransform.position.y > transform.position.y)
                    {
                        rb.AddForce(transform.right * swerveSpeed * Time.deltaTime);
                        Debug.DrawLine(transform.position, transform.right * 3 + transform.position, UnityEngine.Color.magenta);

                    }
                }



                isSwerving = true;
                lineColour = UnityEngine.Color.green;

            }

            else if (distanceToTarget < 1.7)
            {

                movementSpeed = Mathf.Lerp(movementSpeed, -maxMovementSpeed, 0.025f);

                rb.AddForce(-transform.up * movementSpeed * Time.deltaTime);
                Debug.DrawLine(transform.position, -transform.up * 3 + transform.position, UnityEngine.Color.magenta);
            }

        }

        else
        {
            isSwerving = false;
            movementSpeed = Mathf.Lerp(movementSpeed, maxMovementSpeed, 0.025f);
        }

        Debug.DrawLine(transform.position, transform.position + leftVector * sightDistance, lineColour);
        Debug.DrawLine(transform.position, transform.position + rightVector * sightDistance, lineColour);
    }








    


    public bool CheckIfTargetIsInRange(Transform t)
    {
        return true;
    }

    /* unused player avoidance method
    IEnumerator Swerve()
    {
        yield return new WaitForSeconds(0.75f);
        rb.rotation += 0.05f;
        yield return new WaitForSeconds(0.75f);
        rb.rotation -= 0.05f;
    } */ 

}
