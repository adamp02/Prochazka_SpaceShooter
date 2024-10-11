using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DotProduct : MonoBehaviour
{

    public float redAngle = 25f;
    public float blueAngle = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float rad1 = redAngle * Mathf.Deg2Rad;
        //Vector3 redVector = new Vector3(Mathf.Cos(rad1), Mathf.Sin(rad1)) * 1;
        Vector3 redVector = MathUtil.AngleToVector(redAngle);
        Debug.DrawLine(Vector3.zero, redVector, Color.red);

        float rad2 = blueAngle * Mathf.Deg2Rad;
        Vector3 blueVector = new Vector3(Mathf.Cos(rad2), Mathf.Sin(rad2)) * 1;
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);


        if (Input.GetKeyDown("space"))
        {
            float dotProduct = redVector.x * blueVector.x + redVector.y * blueVector.y;
            Debug.Log("The Dot Product of redVector & blueVector is: " + dotProduct);
        }

    }
}
