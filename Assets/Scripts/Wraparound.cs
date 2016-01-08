using UnityEngine;
using System.Collections;

public class Wraparound : MonoBehaviour {

	public Configuration config;

	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 myPosition = rb2D.position;
		if (myPosition.x > config.getRightBoundary()) {
			rb2D.MovePosition(rb2D.position + Vector2.left*(config.getWidth()));
		}
		if (myPosition.x < config.getLeftBoundary()) {
			rb2D.MovePosition(rb2D.position + Vector2.right*(config.getWidth()));
		}
		if (myPosition.y > config.getTopBoundary()) {
			rb2D.MovePosition(rb2D.position + Vector2.down*(config.getHeight()));
		}
		if (myPosition.y < config.getBottomBoundary()) {
			rb2D.MovePosition(rb2D.position + Vector2.up*(config.getHeight()));
		}
	}
}