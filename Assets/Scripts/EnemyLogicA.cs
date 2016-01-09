using UnityEngine;
using System.Collections;

public class EnemyLogicA : MonoBehaviour {

	private float degree;
	private float speed;

	private Rigidbody2D rb2D;

	void Start () {
		speed = 5;
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		Vector2 currentRotation = Random.insideUnitCircle;
		rb2D.AddRelativeForce (currentRotation * speed);
	}
}
