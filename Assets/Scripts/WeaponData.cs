using UnityEngine;
using System.Collections;

public class WeaponData {

	private int cooldown;

	public void SetCooldown(int cooldown) {
		this.cooldown = cooldown;
	}

	public int GetCooldown() {
		return cooldown;
	}
}