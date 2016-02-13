using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public StageLogic stage;

	private GUIStyle style = new GUIStyle ();

	void Start () {
		// create and use a gray pixel as the background
		Texture2D texture = new Texture2D (1, 1);
		texture.SetPixel (1, 1, new Color (1f, 1f, 1f, 0.4f));
		texture.Apply ();
		style.normal.background = texture;
	}

	void OnGUI() {
		GUI.Box (new Rect (20, 10, 100, 40), "Time: "+stage.getGameTime(), style);
	}
}
