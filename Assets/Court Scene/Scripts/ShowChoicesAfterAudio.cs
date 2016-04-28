using UnityEngine;
using System.Collections;

public class ShowChoicesAfterAudio : MonoBehaviour {
	public GameObject Canvas;
	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void Update() {
		if (!audio.isPlaying) {
			Canvas.SetActive (true);
		}
	}
}