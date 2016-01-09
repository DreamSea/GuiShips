using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	private float speed;
	private float maxSpeed;

	private Rigidbody2D rb2D;

	void Start () {
		speed = 10;
		maxSpeed = 5;
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		rb2D.AddRelativeForce (Vector2.right * inputX * speed);
		rb2D.AddRelativeForce (Vector2.up * inputY * speed);

		if (rb2D.velocity.magnitude > maxSpeed) {
			rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
		}
	}
}
