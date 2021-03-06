using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    public Rigidbody2D rb;

    private Vector2 moveDirection;

    public bool playerCanMove;

    private Camera theCam;

    void Start()
    {
        theCam = Camera.main;
        playerCanMove = true;

    }
    void Update()
    {
        if (playerCanMove == true)
        {   
            ProcessInputs();
        }
    }
    private void FixedUpdate()
    {
        if (playerCanMove == true)
        {
            Move();
            Turn();          
        }
    }
    
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
    }

    void Turn()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    } 
}

