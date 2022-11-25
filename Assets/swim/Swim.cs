using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    public Animator anim;

    public float speed = 0.5f;
    public float rotationSpeed = 100.0f;
    public float currentSpeed = 0.0f;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        currentSpeed *= translation;
        anim.SetFloat("speed", currentSpeed);
        transform.Rotate(0,rotation,0);

        if(translation != 0)
        {
            anim.SetBool("Swimming", true);
        }
        else
        {
            anim.SetBool("Swimming", false);
            currentSpeed = 0;
        }
    }
}
