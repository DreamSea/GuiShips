using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

// responsible for loading any save data then
// persisting itself and providing access to
// playerData for every other script (hue)

public class GameState : MonoBehaviour {

	private PlayerData playerData;

	public PlayerData getPlayerData() {
		return playerData;
	}

	// all awake is called before any start
	void Awake() {
		try {
			playerData = SaveLoad.Load ();
		} catch (FileNotFoundException e) {
			playerData = new PlayerData ();
		}

		DontDestroyOnLoad (this);
	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 25), "Save")) {
			SaveLoad.Save (playerData);
			Debug.Log ("Saved");
		}

		GUI.TextArea (new Rect (Screen.width / 2, Screen.height / 4, 100, 25), SceneManager.GetActiveScene().name+": "+playerData.getCount());
	}
			
	
	// Update is called once per frame
	void Update () {
	}
}
