using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CubeController : MonoBehaviour {

	public GameObject player;

	private Rigidbody rb;
	private Rigidbody playerRb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerRb = player.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = playerRb.position - rb.position;
		rb.velocity = diff / diff.magnitude;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			//Player has been struck
			Handheld.Vibrate ();
			TeleportRandomlyCopied ();
		}
	}
	public void TeleportRandomlyCopied() {
		Vector3 direction = UnityEngine.Random.onUnitSphere;
		direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
		float distance = 5 * UnityEngine.Random.value + 1.5f;
		transform.localPosition = direction * distance;
	}
}
