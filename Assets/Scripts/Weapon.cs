using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	private int cooldown;
	private int cooldownCurrent;



	private static Object prefab = Resources.Load ("Prefabs/weapon");

	public static GameObject CreateWeapon(WeaponData data) {
		GameObject newWeapon = Instantiate(prefab, Vector2.zero, Quaternion.identity) as GameObject;

		Weapon weapon = newWeapon.GetComponent<Weapon> ();
		weapon.InitWeapon (data);

		return newWeapon;
	}

	private void InitWeapon(WeaponData data) {
		SetCooldown (data.GetCooldown());
		//Debug.Log (cooldown);
	}

	void Start()
	{
		cooldownCurrent = 0;
	}

	void FixedUpdate()
	{
		if (cooldownCurrent > 0) {
			cooldownCurrent--;
		}
	}

	void SetCooldown(int cooldown) {
		this.cooldown = cooldown;
	}

	public void Fire(Vector2 location, Vector2 direction) {
		if (cooldownCurrent == 0) {
			cooldownCurrent = cooldown;


			//BulletLogic.SpawnBullet (location, direction);

			// trololol
			Quaternion a = Quaternion.Euler (0, 0, Random.Range (-5, 5));
			BulletLogic.SpawnBullet (location, a*direction);
		}
	}

	public int GetCooldown() {
		return cooldown;
	}
}
