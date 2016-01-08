#pragma strict

function Start () {

}

function Update () {
	// GetAxis() returns a value between 1 and -1
	// Depending on which arrow key is pressed
	
	// So we change the spaceship X velocity
	// By GetAxis("Horizontal") * 10
	GetComponent.<Rigidbody2D>().velocity.x = Input.GetAxis("Horizontal") * 5;
	GetComponent.<Rigidbody2D>().velocity.y = Input.GetAxis("Vertical") * 5;
}