using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class CubeController : MonoBehaviour, ICardboardGazeResponder {

	public GameObject player;
	public GameObject scoreboard;

	private Rigidbody rb;
	private Rigidbody playerRb;
	private ScoreboardController scoreboardController;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerRb = player.GetComponent<Rigidbody> ();
		SetGazedAt(false);
		scoreboardController = scoreboard.GetComponent<ScoreboardController> ();
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
			scoreboardController.IncrementHits ();
			TeleportToNewLocation ();
		}
	}
	public void TeleportToNewLocation() {
		Vector3 loc = Random.onUnitSphere * 30;
		loc.y = Mathf.Clamp (loc.y, 1, 20);
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
		scoreboardController.IncrementKills ();
		TeleportToNewLocation();
	}

	#endregion
}

