using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreboardController : MonoBehaviour {


	private int kills;
	private int hits;
	private Text text;
	// Use this for initialization
	void Start () {
		kills = 0;
		hits = 0;
		text = GetComponent<Text> ();
	}

	public void IncrementKills() {
		kills = kills + 1;
		UpdateText ();
	}

	public void IncrementHits() {
		hits = hits + 1;
		UpdateText ();
	}

	private void UpdateText() {
		text.text = "KILLS: " + kills + "\nHITS: " + hits;
	}
}
