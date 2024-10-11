using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MathUtil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 AngleToVector(float angle)
    {

        float rad = angle * Mathf.Deg2Rad;
        Vector3 vector = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));

        return vector;
    }

}
