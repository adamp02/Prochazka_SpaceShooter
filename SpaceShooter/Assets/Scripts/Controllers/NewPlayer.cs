using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;

    public float movementSpeed = 2f;

    public bool boost = false;

    public Transform hitboxDEMO;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetKeyDown("x")) //also check what keys are pressed -> no movement = no boost
        {
            boost = true;
        }
    }

    void FixedUpdate()
    {

        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        
        if (boost == true && direction != Vector3.zero)
        {
            boost = false;
            hitboxDEMO.gameObject.SetActive(false);
            rb.AddForce(direction.normalized * (movementSpeed * 40f)); // also set i-frames & ghost sprite effect
            StartCoroutine(ApplyBoost());

        }

        else
        {
            boost = false; //DOLLARAMA CODE - FIX LATER! shouldn't even get boosted at all if direction == V3.z!
            rb.AddForce(direction.normalized * movementSpeed);
        }

    }

    IEnumerator ApplyBoost()
    {
        yield return new WaitForSeconds(0.35f);
        hitboxDEMO.gameObject.SetActive(true);
    }
}
