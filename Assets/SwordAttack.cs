using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection {
        LEFT,
        RIGHT
    }

    public AttackDirection attackDirection;
    Collider2D swordCollider;
    Vector2 hitBoxOffsetRight;

    // Start is called before the first frame update
    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        hitBoxOffsetRight = transform.position;
    }
    
    public void Attack() {
        switch (attackDirection) {
            case AttackDirection.LEFT:
                AttackLeft();
                break;
            case AttackDirection.RIGHT:
                AttackRight();
                break;
        }
    }

    private void AttackRight() {
        Debug.Log("Attacking to the right..");
        swordCollider.enabled = true;
        transform.position = new Vector3(hitBoxOffsetRight.x, hitBoxOffsetRight.y);

    }

    private void AttackLeft() {
        Debug.Log("Attacking to the left..");
        swordCollider.enabled = true;
        transform.position = new Vector3(hitBoxOffsetRight.x * -1, hitBoxOffsetRight.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }
    



}
