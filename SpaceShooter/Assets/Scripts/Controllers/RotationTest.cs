using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{

    public float angularSpeed = 0f;
    public float targetAngle = 90f;

    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        FindAngle();
    }


    public void FindAngle()
    {
        // https://docs.unity3d.com/ScriptReference/Vector3.Angle.html
        Vector3 targetDirection = targetTransform.position - transform.position;
        float angle = Vector3.Angle(targetDirection, transform.up);

        if (angle < targetAngle) { targetAngle = angle; }


    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.up, Color.green);

        // could also do https://docs.unity3d.com/ScriptReference/Transform-rotation.html
        // to smoothly dampen towards target


        if (transform.eulerAngles.z < targetAngle)
        {
            transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
        }

        Debug.DrawLine(transform.position, targetTransform.position, Color.blue);

    }


}
