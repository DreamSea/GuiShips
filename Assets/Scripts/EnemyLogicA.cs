using UnityEngine;
using System.Collections;

public class EnemyLogicA : MonoBehaviour {

	private float degree;
	private float speed;
	private float maxSpeed;

	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		speed = 5;
		rb2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		Vector2 currentRotation = Random.insideUnitCircle;
		rb2D.AddRelativeForce (currentRotation * speed);
	}
}
