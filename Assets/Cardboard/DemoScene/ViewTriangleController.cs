using UnityEngine;
using System.Collections;

public class ViewTriangleController : MonoBehaviour {

	public GameObject player;

	private float currentRotation;
	private Vector3 rotationVec;

	// Use this for initialization
	void Start () {
		currentRotation = 0;
		rotationVec = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float newRotation = getPlayerRotation ();
		rotationVec.Set (0, 0, currentRotation - newRotation);
		transform.Rotate (rotationVec);
		currentRotation = newRotation;
	}

	private float getPlayerRotation() {
		return player.transform.rotation.eulerAngles.y;
	}
}
