using UnityEngine;
using System.Collections;

public class GuiLabel : MonoBehaviour {

	public string text;
	public float offsetX;
	public float offsetY;
	public Color color;

	private GUIStyle style = new GUIStyle ();

	private Rigidbody2D rb2D;
	private Rect labelRect;
	private Vector2 offset;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		labelRect = new Rect (0, 0, 100, 100);
		offset = new Vector2 (offsetX, offsetY);
	}

	void OnGUI() {
		style.normal.textColor = color;
		Vector3 point = Camera.main.WorldToScreenPoint (rb2D.position);
		labelRect.x = point.x + offset.x;
		labelRect.y = Screen.height - point.y + offset.y;
		GUI.Label (labelRect, text, style);
	}


	// Update is called once per frame
	void Update () {

	}

	public void setAlpha(float alpha) {
		color.a = alpha;
	}
}
