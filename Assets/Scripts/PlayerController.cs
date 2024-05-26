using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject initialMap;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator anim;

    public bool IsMoving { get; private set; }

    //Komponenttien alustus
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Camera.main.GetComponent<MainCamera>().SetBound(initialMap);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        IsMoving = moveDirection != Vector2.zero;
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (IsMoving)
        {
            //Kävely animaatiot
            anim.SetFloat("MoveX", moveDirection.x);
            anim.SetFloat("MoveY", moveDirection.y);
            anim.SetBool("Walking", true);
        }
        else
        {
            //idle animaatiot
            anim.SetBool("Walking", false);
        }
    }

    private void HandlePlayerMovement()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            HandlePlayerMovement();
        }
    }
}
