using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;

	void Start()
	{

	}

	void FixedUpdate()
	{
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void Damage(float damage) {
		health -= damage;
	}
}
