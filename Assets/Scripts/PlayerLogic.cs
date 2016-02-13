using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerLogic : MonoBehaviour {

    private float speed;
    private float maxSpeed;

	private ICollection<Weapon> weapons = new List<Weapon> (); 
	private ICollection<Engine> engines = new List<Engine>();

    private Vector2 getDirection()
    {
		return rb2D.transform.rotation * Vector2.up;
    }

	private Rigidbody2D rb2D;

	private PlayerLogic player;
	private static Object prefab = Resources.Load ("Prefabs/player");

	public static GameObject CreatePlayer(Vector2 location, PlayerData data) {
		
		GameObject newPlayer = Instantiate(prefab, location, Quaternion.identity) as GameObject;
		newPlayer.name = "Player";

		PlayerLogic player = newPlayer.GetComponent<PlayerLogic> ();

		// data is null if skipping directly to level
		if (data != null) {
			player.InitPlayer (data);
		} else {
			player.AddPlainWeapon ();
			player.AddPlainEngine ();
		}

		return newPlayer;
	}

	private void InitPlayer(PlayerData data) {
		//Debug.Log (data.GetWeaponData());
		foreach (WeaponData w in data.GetWeaponData()) {
			weapons.Add (Weapon.CreateWeapon (w).GetComponent<Weapon> ());
		}
		if (weapons.Count == 0) {
			AddPlainWeapon ();
		}
		if (engines.Count == 0) {
			AddPlainEngine ();
		}
	}

	// default weapon for testing purposes
	private void AddPlainWeapon() {
		WeaponData plain = new WeaponData();
		plain.SetCooldown (5);
		weapons.Add (Weapon.CreateWeapon (plain).GetComponent<Weapon> ());
	}

	// default engine for testing purposes
	private void AddPlainEngine() {
		EngineData plain = new EngineData();
		engines.Add (Engine.CreateEngine (plain).GetComponent<Engine> ());
	}



	void Start () {
		speed = 10;
		maxSpeed = 5;
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		DoEngines ();

		if (Input.GetKey ("space")) {
			FireWeapons ();
			//spawnBulletA ();
		}
            
	}

    //
    private void spawnBulletA()
    {
		BulletLogic.SpawnBullet (rb2D.position, getDirection());
        //Instantiate(enemyA, new Vector3(xSpawn + config.getLeftBoundary(), ySpawn + config.getBottomBoundary(), 0), Quaternion.identity);
    }

	private void FireWeapons() {
		foreach (Weapon w in weapons) {
			w.Fire (rb2D.position, getDirection());
		}
	}

	private void DoEngines() {
		float fowardness = Input.GetAxis ("Vertical");
		float turn = Input.GetAxis ("Horizontal");
		foreach (Engine e in engines) {
			// 'up' is now forward.
			rb2D.AddRelativeForce (Vector2.up * e.CalculateThrust (fowardness));
			rb2D.AddTorque (e.CalculateTorque (-turn));
		}

		// cap movement speed
		if (rb2D.velocity.magnitude > maxSpeed) {
			rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
		}
		if (rb2D.angularVelocity > maxSpeed*10) {
			rb2D.angularVelocity = maxSpeed*10;
		}
		if (rb2D.angularVelocity < -maxSpeed*10) {
			rb2D.angularVelocity = -maxSpeed*10;
		}

		//float inputY = Input.GetAxis("Vertical");

		//rb2D.AddRelativeForce (Vector2.right * inputX * speed);
		//rb2D.AddRelativeForce (Vector2.up * inputY * speed);

		// store rotation into direction vector
	}
}
