using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeatEmUpMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    Rigidbody2D rb;
    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    public void Move(Vector2 input)
    {
        movement = input;
    }

    public void StopMove()
    {
        movement = Vector2.zero;
    }
}
