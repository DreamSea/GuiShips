using UnityEngine;
using System.Collections;

public class EnemyLabel : MonoBehaviour {

	public string enemyName;

	private GUIStyle blackStyle = new GUIStyle ();

	private Rigidbody2D rb2D;
	private Rect labelRect;
	private Vector2 offset;
	private Health health;

	// Use this for initialization
	void Start () {
		blackStyle.normal.textColor = Color.black;
		rb2D = GetComponent<Rigidbody2D>();
		labelRect = new Rect (0, 0, 100, 100);
		offset = new Vector2 (-5, -5);
		health = gameObject.GetComponent<Health> ();
	}

	void OnGUI() {
		Vector3 point = Camera.main.WorldToScreenPoint (rb2D.position);
		labelRect.x = point.x + offset.x;
		labelRect.y = Screen.height - point.y + offset.y;
		if (health != null) {
			GUI.Label (labelRect, enemyName + " " + health.health, blackStyle);
		} else {
			GUI.Label (labelRect, enemyName, blackStyle);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
