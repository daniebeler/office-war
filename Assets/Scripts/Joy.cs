using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joy : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    private Rigidbody rigidbody;

    protected bool jump;
    public float speed = 20f;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float heading = Mathf.Atan2(joystick.Horizontal, joystick.Vertical);
        transform.rotation = Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f);

        if (!jump && (joybutton.Pressed || Input.GetKeyDown("space")))
        {
            jump = true;
            rigidbody.AddForce(transform.forward * speed);
        }

        if (jump && !(joybutton.Pressed || Input.GetKeyDown("space")))
        {
            jump = false;
        }
    }
}
