using UnityEngine;
using System.Collections;

public class ViewTriangleController : MonoBehaviour {

	public GameObject player;

	private float currentRotation;

	// Use this for initialization
	void Start () {
		currentRotation = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float newRotation = getPlayerRotation ();
		transform.Rotate (new Vector3(0, 0, currentRotation - newRotation));
		currentRotation = newRotation;
	}

	private float getPlayerRotation() {
		return player.transform.rotation.eulerAngles.y;
	}
}
