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

	string sceneToLoad;

	public void Drive() {
		canvas.enabled = false;
		GameController.isDriving = true;
		SceneManager.LoadScene ("Hospital Scene");
	}

	public void NotDrive() {
		canvas.enabled = false;
		GameController.isDriving = false;
		SceneManager.LoadScene ("Hospital Scene");
	}

	public void PleadGuilty() {
		canvas.enabled = false;
		audio.clip = pleadGuilty;
		audio.Play ();
		GameController.isPleadingGuilty = true;
		SceneManager.LoadScene ("Jail Scene");
	}

	public void NotPleadGuilty() {
		canvas.enabled = false;
		audio.clip = notPleadGuilty;
		audio.Play ();
		GameController.isPleadingGuilty = false;
		SceneManager.LoadScene ("Jail Scene");
	}

	void PlayMyClip()
	{    
		// Play clip
		audio.Play ();
		// Wait for the clip to finish
		StartCoroutine(Wait(audio.clip.length, OnWaitFinished)); 
	}

	private void OnWaitFinished()
	{
		SceneManager.LoadScene (sceneToLoad);
	}

	private IEnumerator Wait(float duration, System.Action callback)
	{
		yield return new WaitForSeconds(duration);
		if(callback != null) callback();
	}
}