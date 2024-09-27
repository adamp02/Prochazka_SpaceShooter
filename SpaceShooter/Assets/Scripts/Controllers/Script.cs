using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    public List<float> angles;

    public float currentAngle;
    public float radius = 2f;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = angles[counter];
        StartCoroutine(ChangeAngles());


        Debug.Log("Mathf.Cos(45) = " + Mathf.Cos(45 * Mathf.Deg2Rad));
        Debug.Log("Mathf.Cos(-45) = " + Mathf.Cos(-45 * Mathf.Deg2Rad));
        Debug.Log("Mathf.Acos(0.7071068) = " + Mathf.Acos(0.7071068f) * Mathf.Rad2Deg);

    }

    // Update is called once per frame
    void Update()
    {

        currentAngle = angles[counter];

        float rad = currentAngle * Mathf.Deg2Rad;

        Vector3 p = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

        Debug.DrawLine(Vector3.zero, p, Color.red);

        if(Input.GetKeyDown("space"))
        {
            if (counter == angles.Count - 1)
            {
                counter = 0;
            } 
            else
            {
                counter++;
            }
        }
        
    }

    public IEnumerator ChangeAngles()
    {

        yield return new WaitForSeconds(1f);

        if (counter == angles.Count - 1)
        { counter = 0;}
        else { counter++; }

        StartCoroutine(ChangeAngles());


    }
}
