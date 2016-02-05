using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {

	public string sceneTarget;
	public Color glowColor;

	private Rigidbody2D rb2D;
	private Rigidbody2D player;
	private GuiLabel label;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.Find ("Player").GetComponent<Rigidbody2D>();
		}
		if (label == null) {
			label = GetComponent<GuiLabel> ();
		}
		changeLabelAlpha ();

	}

	private void changeLabelAlpha() {
		float distance = Vector2.Distance(rb2D.position, player.position);

		if (distance < 1 && Input.GetKey (KeyCode.Return)) {
			SceneManager.LoadScene (sceneTarget);
		}

		distance /= 5;
		//Debug.Log (distance);
		distance = 1 - distance;
		if (distance < 0)
			distance = 0;
		label.setAlpha (distance);
	}
}
