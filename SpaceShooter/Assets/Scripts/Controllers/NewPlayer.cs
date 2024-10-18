using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{


    public Rigidbody2D rb;
    public float movementSpeed = 2f;
    public bool boost = false;
    public Transform hitboxDEMO;
    public GameObject ghostSprite;
    public float torque = 5f;

    public Transform trailer;
    public Transform trailerOffset;
    public float trailerTurnSpeed = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetKeyDown("x") || Input.GetButtonDown("Fire1")) //also check what keys are pressed -> no movement = no boost
        {
            boost = true;
        }

        // not used in final version :(
        trailer.transform.position = trailerOffset.transform.position;
        trailer.transform.rotation = Quaternion.Slerp(trailer.transform.rotation, transform.rotation, trailerTurnSpeed * Time.deltaTime);

      
    }


    

    void FixedUpdate()
    {


        // turn test!
        Vector3 direction = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        float accel = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");
        rb.rotation += turn * -torque;

       
        

        if (boost == true && direction != Vector3.zero)
        {
            boost = false;
            hitboxDEMO.gameObject.SetActive(false);
            rb.AddForce(transform.up * (movementSpeed * 40f));
            StartCoroutine(ApplyBoost());

        }

        else
        {
            boost = false; 
            rb.AddForce(transform.up * movementSpeed * accel);
        }

    }

    IEnumerator ApplyBoost()
    {
        // this looks bad, fix!
        yield return new WaitForSeconds(0.05f);
        Instantiate(ghostSprite, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Instantiate(ghostSprite, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Instantiate(ghostSprite, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Instantiate(ghostSprite, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.35f);
       // hitboxDEMO.gameObject.SetActive(true);
    }
}
