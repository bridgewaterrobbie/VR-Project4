using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChoiceManager : MonoBehaviour {
	public Canvas canvas;

	public AudioSource audio;

	public AudioClip drive;
	public AudioClip notDrive;

	public AudioClip pleadGuilty;
	public AudioClip notPleadGuilty;

	public void Drive() {
		canvas.enabled = false;
		audio.clip = notDrive;
		audio.Play ();
		GameController.isDriving = true;
		SceneManager.LoadScene ("Hospital Scene");
	}

	public void NotDrive() {
		canvas.enabled = false;
		audio.clip = notDrive;
		audio.Play ();
		GameController.isDriving = false;
		SceneManager.LoadScene ("Hospital Scene");
	}

	public void PleadGuilty() {
		canvas.enabled = false;
		audio.clip = pleadGuilty;
		audio.Play ();
		GameController.isPleadingGuilty = true;
	}

	public void NotPleadGuilty() {
		canvas.enabled = false;
		audio.clip = notPleadGuilty;
		audio.Play ();
		GameController.isPleadingGuilty = false;
	}
}