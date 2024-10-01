using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    float currentAngle = 0f;
    public float rotationSpeed = 0.05f;
    public float radius = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, rotationSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        if (currentAngle > 360) { currentAngle = 0f; }
        currentAngle += speed;

        float rad = currentAngle * Mathf.Deg2Rad;

        Vector3 p = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

        transform.position = target.position + p;

     

     

    }
}
