using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayMovie : MonoBehaviour {
	MovieTexture movie;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		Renderer r = GetComponent<Renderer>();
		movie = (MovieTexture)r.material.mainTexture;
		audio = GetComponent<AudioSource>();
		PlayMyClip ();
	}

	void PlayMyClip()
	{    
		Debug.Log ("Called once");
		// Play clip
		movie.Play();
		audio.Play ();
		// Wait for the clip to finish
		StartCoroutine(Wait(64.4f, OnWaitFinished)); 
	}

	private void OnWaitFinished()
	{
		SceneManager.LoadScene ("Court Scene");
	}

	private IEnumerator Wait(float duration, System.Action callback)
	{
		yield return new WaitForSeconds(duration);
		if(callback != null) callback();
	}


}
