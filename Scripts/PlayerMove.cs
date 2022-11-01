using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private float jspd;
    private Rigidbody2D rb2d;
    private bool collide;
    public bool started;
    public bool canMove;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        canMove = true;
        started = false;
    }

    private void Update() {
        if (canMove == true) {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * spd, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && collide == true && canMove == true) {
            Jump();
        }
    }

    private void Jump() {
        rb2d.velocity = new Vector2(rb2d.velocity.x + spd, jspd);
        collide = false;
    }

    private void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Collide") {
            collide = true;
        } if (collider.gameObject.tag == "Starter") {
            started = true;
        }
    }
}
