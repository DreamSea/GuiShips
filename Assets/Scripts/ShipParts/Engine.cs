using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	private int speed;

	private static Object enginePrefab;

	public static GameObject CreateEngine(EngineData data) {
		GameObject newEngine = Instantiate(GetEnginePrefab(), Vector2.zero, Quaternion.identity) as GameObject;

		Engine engine = newEngine.GetComponent<Engine> ();
		engine.InitEngine (data);

		return newEngine;
	}

	private static Object GetEnginePrefab() {
		if (enginePrefab == null) {
			enginePrefab = Resources.Load ("Prefabs/engine");
		}
		return enginePrefab;
	}

	private void InitEngine(EngineData data) {
		// does nothing yet besides arbitrary speed
		speed = 10;
	}

	void Start()
	{

	}

	void FixedUpdate()
	{

	}

	// Probably using term 'thrust' incorrectly.
	// And 'speed'. how do i even physics :/
	public float CalculateThrust(float forwardness) {
		return forwardness * speed;
	}

	public float CalculateTorque(float turn) {
		return turn * speed;
	}
}
