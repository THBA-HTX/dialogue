using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float _speed = 1f;
    public PlayerActions _playerActions;
    public Vector2 _moveInput;
    public Rigidbody2D _rb;
    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;
    SpriteRenderer spriteRenderer;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private bool canMove = true;

    public void Awake()
    {
        _playerActions = new PlayerActions();
    }

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

   

    private void FixedUpdate() {

        _moveInput = _playerActions.PlayerMovement.movement.ReadValue<Vector2>();

        if(canMove) {

            if (_moveInput != Vector2.zero)
            {

                bool success = TryMove(_moveInput);


                if (!success)
                {
                    success = TryMove(new Vector2(_moveInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, _moveInput.y));
                    }
                }
            }
        } 

        //    // Set direction of sprite to movement direction
        //    if(movementInput.x < 0) {
        //        spriteRenderer.flipX = true;
        //    } else if (movementInput.x > 0) {
        //        spriteRenderer.flipX = false;
        //    }
        //}
    }

    private bool TryMove(Vector2 direction) {


        if(direction != Vector2.zero) {
            // Check for potential collisions
            int count = _rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                _speed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if(count == 0){
                _rb.MovePosition(_rb.position + (direction * _speed * Time.fixedDeltaTime));
                return true;
            } else {
                return false;
            }
        } else {
            foreach (RaycastHit2D hit in castCollisions) {
                print(hit.ToString());
            }
            // Can't move if there's no direction to move in
            return false;
        }        
    }

    void OnMove(InputValue movementValue) {
        Debug.Log("Event OnMove");
        _moveInput = movementValue.Get<Vector2>();
    }

    public void OnEnable()
    {
        _playerActions.PlayerMovement.Enable();
    }

    public void OnDisable()
    {
        _playerActions.PlayerMovement.Disable();
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
