using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

    private float maxSpeed;
    private float damage;
    private Vector2 direction;

    private Rigidbody2D rb2D;

    void Start()
    {
        maxSpeed = 250;
        rb2D = GetComponent<Rigidbody2D>();
        direction = PlayerLogic.getDirection();
        rb2D.AddRelativeForce(PlayerLogic.getDirection() * maxSpeed);
    }

    void FixedUpdate()
    {

        // On collision stuff

    }
}
