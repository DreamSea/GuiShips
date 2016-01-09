using UnityEngine;
using System.Collections;

public class StageLogic : MonoBehaviour {

	int gameTime;

	void Start () {
		gameTime = 0;
	}

	void FixedUpdate () {
		gameTime++;
	}

	public int getGameTime() {
		return gameTime;
	}
}
