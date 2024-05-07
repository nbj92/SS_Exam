using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 5;

    private float xInput;
    private float yInput;

    private Vector2 moveDirection;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate() {
        Movement();
    }

    void GetInput() {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void Movement() {
        moveDirection = new Vector2(xInput, yInput).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }
}
