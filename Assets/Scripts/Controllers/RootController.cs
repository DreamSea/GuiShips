using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RootController : MonoBehaviour {

	public GameState gameState;
	public GameObject player;


	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 4 * 3, 100, 25), "History")) {
			SceneManager.LoadScene ("History");
		}
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("RootController: Start "+gameState.getPlayerData().getCount());
		Instantiate (player, Vector3.zero, Quaternion.identity).name = "Player";
		setupPlayer ();
	}

	void Awake () {

	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("RootController: Update");
	}

	// stuff like specific level multipliers go here
	private void setupPlayer() {
		// player.setWhatever()
	
	}
}
