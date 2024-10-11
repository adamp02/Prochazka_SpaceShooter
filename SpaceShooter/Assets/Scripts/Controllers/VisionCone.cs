using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class VisionCone : MonoBehaviour
{


    public float sightDistance = 1.5f;
    public float visionAngle = 20f;
    public float currentDirection = 0;
   

    public Transform targetTransform;

    public GameObject message;

    // Start is called before the first frame update
    void Start()
    {
        message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        newWay();
        return;

        float leftSide = (currentDirection + visionAngle);
        //Vector3 redVector = new Vector3(Mathf.Cos(rad1), Mathf.Sin(rad1)) * 1;
        Vector3 leftSightline = MathUtil.AngleToVector(leftSide) * sightDistance;
        Debug.DrawLine(Vector3.zero, leftSightline, UnityEngine.Color.white);

        float rightSide = (currentDirection - visionAngle);
        //Vector3 redVector = new Vector3(Mathf.Cos(rad1), Mathf.Sin(rad1)) * 1;
        Vector3 rightSightline = MathUtil.AngleToVector(rightSide) * sightDistance;
        Debug.DrawLine(Vector3.zero, rightSightline, UnityEngine.Color.green);


        lookForDude();

        if(Input.GetKeyDown("space"))
        {
            //Vector3 targetDirection = dude.position - transform.position;
            //float angle = Vector3.Angle(targetDirection, transform.position);
            float angle = Vector2.Angle(transform.position, targetTransform.transform.position);
            Debug.Log(angle);
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

        message.SetActive(false);
        bool isInRange = isEnemyCloseEnough && isObjectInFOV;
        if (isInRange)
        {
            lineColour = UnityEngine.Color.green;
            message.SetActive(true);
        }

        Debug.DrawLine(transform.position, transform.position + leftVector * sightDistance, lineColour);
        Debug.DrawLine(transform.position, transform.position + rightVector * sightDistance, lineColour);
    }

    public bool CheckIfTargetIsInRange(Transform t)
    {
        return true;
    }

    public void lookForDude()
    {

       

        
        float distance = Vector3.Distance(targetTransform.position, transform.position);
        

        if (distance < sightDistance)
        {
            message.SetActive(true);
        }

        else
        {
            message.SetActive(false);
        }
    }
}
