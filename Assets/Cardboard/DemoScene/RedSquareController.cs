using UnityEngine;
using System.Collections;

public class RedSquareController : MonoBehaviour {

	public GameObject zombie;

	private Vector3 offset = new Vector3(100, 150, 0);
	private Vector3 previousPosition;
	private Vector3 positionVec;
	private Vector3 zombiePosition;

	void Start () {
		previousPosition = getTranslatedPosition ();
		updatePosition ();
	}

	void Update () {
		updatePosition ();
	}

	private Vector3 getTranslatedPosition () {
		zombiePosition = zombie.transform.position;
		zombiePosition.y = Mathf.Clamp (zombiePosition.z, -20, 20);
		zombiePosition.x = Mathf.Clamp (zombiePosition.x, -20, 20);
		zombiePosition.z = 0;
		return zombiePosition;
	}

	private void updatePosition() {
		positionVec = getTranslatedPosition();
		transform.localPosition = positionVec + offset;
		previousPosition = positionVec;
	}
}
