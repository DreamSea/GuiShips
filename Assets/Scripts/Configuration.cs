using UnityEngine;
using System.Collections;

public class Configuration : MonoBehaviour {

	private float leftBoundary;
	private float rightBoundary;
	private float topBoundary;
	private float bottomBoundary;

	// Use this for initialization
	void Start () {
		leftBoundary = -7.5f;
		rightBoundary = 7.5f;
		topBoundary = 5.0f;
		bottomBoundary = -5.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getLeftBoundary() {
		return leftBoundary;
	}

	public float getRightBoundary() {
		return rightBoundary;
	}

	public float getTopBoundary() {
		return topBoundary;
	}

	public float getBottomBoundary() {
		return bottomBoundary;
	}

	public float getWidth() {
		return rightBoundary - leftBoundary;
	}

	public float getHeight() {
		return topBoundary - bottomBoundary;
	}
}

