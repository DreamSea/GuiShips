using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {


    private float maxSpeed;
    private float damage;
	private int lifespan;
	private int currentLife;
    private Vector2 direction;

    private Rigidbody2D rb2D;

	private static Object prefab = Resources.Load ("Prefabs/playerBullet");

	public static GameObject SpawnBullet(Vector2 location, Vector2 direction)
	{
		GameObject newBullet = Instantiate (prefab, location, Quaternion.identity) as GameObject;

		BulletLogic logic = newBullet.GetComponent<BulletLogic> ();
		logic.SetDirection (direction);
		logic.SetLifespan (100);
		logic.InitBullet ();

		return newBullet;
	}

	void InitBullet()
	{
		rb2D = GetComponent<Rigidbody2D>();
		maxSpeed = 250;
		rb2D.AddRelativeForce(direction * maxSpeed);
		currentLife = lifespan;
	}

    void Start()
    {
 
    }

    void FixedUpdate()
    {
		currentLife--;
		if (currentLife <= 0) {
			Destroy (this.gameObject); // kill the Bullet object this script is attached to
		}

        // On collision stuff

    }

	void SetDirection(Vector2 direction) {
		this.direction = direction;
	}

	void SetLifespan(int lifespan) {
		this.lifespan = lifespan;
	}
}
