using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

    private float speed;
    private float maxSpeed;

    private Vector2 direction;
    public Vector2 getDirection()
    {
        return direction;
    }
    public void setDirection(Vector2 dir)
    {
        direction = dir;
    }

	private Rigidbody2D rb2D;

	void Start () {
		speed = 10;
		maxSpeed = 5;
		rb2D = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
	}

	void FixedUpdate()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		rb2D.AddRelativeForce (Vector2.right * inputX * speed);
		rb2D.AddRelativeForce (Vector2.up * inputY * speed);

        // store rotation into direction vector

		if (rb2D.velocity.magnitude > maxSpeed) {
			rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
		}

        if (Input.GetKey("space"))
             spawnBulletA();
            
	}

    //
    private void spawnBulletA()
    {
		BulletLogic.SpawnBullet (rb2D.position, getDirection());
        //Instantiate(enemyA, new Vector3(xSpawn + config.getLeftBoundary(), ySpawn + config.getBottomBoundary(), 0), Quaternion.identity);
    }
}
