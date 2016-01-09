using UnityEngine;
using System.Collections;

public class StageLogic : MonoBehaviour {

	int gameTime;
	private Configuration config;

	public Rigidbody2D enemyA;


	void Start () {
		config = this.GetComponent<Configuration> ();
		gameTime = 0;
	}

	void FixedUpdate () {
		gameTime++;
		if (gameTime % 200 == 0) {
			spawnEnemyA ();
		}
	}

	public int getGameTime() {
		return gameTime;
	}

	private void spawnEnemyA() {
		float xSpawn = Random.value * config.getWidth ();
		float ySpawn = Random.value * config.getHeight ();

		Instantiate(enemyA, new Vector3(xSpawn+config.getLeftBoundary(), ySpawn+config.getBottomBoundary(), 0), Quaternion.identity);
	}
}
