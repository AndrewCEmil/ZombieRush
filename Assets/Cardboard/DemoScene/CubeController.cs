using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(Collider))]
public class CubeController : MonoBehaviour, ICardboardGazeResponder {

	public GameObject player;

	private Rigidbody rb;
	private Rigidbody playerRb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerRb = player.GetComponent<Rigidbody> ();
		SetGazedAt(false);
	}

	void LateUpdate() {
		Cardboard.SDK.UpdateState();
		if (Cardboard.SDK.BackButtonPressed) {
			Application.Quit();
		}
	}

	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = playerRb.position - rb.position;
		rb.velocity = 3f * diff / diff.magnitude;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			//Player has been struck
			Handheld.Vibrate ();
			TeleportToNewLocation ();
		}
	}
	public void TeleportToNewLocation() {
		Vector3 loc = new Vector3 (
			(UnityEngine.Random.value - .5f) * 60,
			UnityEngine.Random.value * 20f,
			5);
		transform.localPosition = loc;
	}

	#region ICardboardGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see CardboardGaze).
	public void OnGazeEnter() {
		SetGazedAt(true);
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		SetGazedAt(false);
	}

	// Called when the Cardboard trigger is used, between OnGazeEnter
	/// and OnGazeExit.
	public void OnGazeTrigger() {
		TeleportToNewLocation();
	}

	#endregion
}

