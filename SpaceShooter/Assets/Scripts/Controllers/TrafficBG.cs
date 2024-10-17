using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficBG : MonoBehaviour
{

    public float xSpeed = 1f;
    public float ySpeed = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;



        if (transform.position.x > 90)
        {
            transform.position = new Vector3(-90, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -90)
        {
            transform.position = new Vector3(90, transform.position.y, transform.position.z);

        }


        if (transform.position.y > 90)
        {
            transform.position = new Vector3(transform.position.x, -90, transform.position.z);
        }

        if (transform.position.y < -90)
        {
            transform.position = new Vector3(transform.position.x, 90, transform.position.z);
        }




    }
}
