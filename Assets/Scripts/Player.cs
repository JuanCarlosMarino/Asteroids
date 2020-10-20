using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float accerleration;

    public float maxSpeed;

    public float drag;

    public float angularSpeed;

    private Rigidbody2D rb;

    private float vertical;

    private float horizontal;

    private bool shooting;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = InputManager.Vertical;
        horizontal = InputManager.Horizontal;
        shooting = InputManager.Fire;

        Rotate();
    }

    private void FixedUpdate()
    {
        var fowardMotor = Mathf.Clamp(vertical,0f,1f);
        rb.AddForce(transform.up * accerleration * fowardMotor);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Rotate()
    {
        if (horizontal == 0)
        {
            return;
        }
        transform.Rotate(0,0,-angularSpeed *horizontal *Time.deltaTime);
    }
}
