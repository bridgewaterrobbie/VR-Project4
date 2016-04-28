using UnityEngine;
using System.Collections;

public class ShowChoicesAfterAudio : MonoBehaviour {
	public GameObject Canvas;
	AudioSource audio;

	public bool audioStarted = false;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void Update() {
		if (audio.isPlaying) {
			audioStarted = true;
		}

		if (!audio.isPlaying && audioStarted) {
			Canvas.SetActive (true);
		}
	}
}