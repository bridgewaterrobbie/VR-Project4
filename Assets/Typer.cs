using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Text))]
public class Typer : MonoBehaviour {

	public bool replaceMessage3 = false;
	public string msg1 = "Replace";
	public string msg2 = "Replace";
	public string msg3 = "Replace";
	public string msg4 = "Replace";

	private  Text  textComp;
	public float startDelay = 2f;
	public float typeDelay = 0.01f;
	public AudioClip putt;

	public Canvas currentCanvas;
	public AudioSource audio;

	void Start()
	{
		if (replaceMessage3 != false) {
			if (GameController.isPleadingGuilty) {
				msg3 = "Pleading guilty and acknwoledging you made a mistake, does not guarantee you will receive a reduced sentence.";
			} else {
				msg3 = "If you plead not guilty and are convicted, you will face up to 15 years in prison in the State of Florida.";
			}
		}

		StartCoroutine("TypeIn");
	}

	void Awake()
	{
		textComp = GetComponent<Text>();
	}

	public IEnumerator TypeIn()
	{
		yield return new WaitForSeconds(startDelay);
		for (int i = 0;  i <= msg1.Length;  i++)
		{
			textComp.text = msg1.Substring (0, i);
			GetComponent<AudioSource>().PlayOneShot(putt);
			yield return new WaitForSeconds(typeDelay);
		}

		yield return new WaitForSeconds(3.0f);
		for (int i = 0;  i <= msg2.Length;  i++)
		{
			textComp.text = msg2.Substring (0, i);
			GetComponent<AudioSource>().PlayOneShot(putt);
			yield return new WaitForSeconds(typeDelay);
		}

		yield return new WaitForSeconds(3.0f);
		for (int i = 0;  i <= msg3.Length;  i++)
		{
			textComp.text = msg3.Substring (0, i);
			GetComponent<AudioSource>().PlayOneShot(putt);
			yield return new WaitForSeconds(typeDelay);
		}

		yield return new WaitForSeconds(3.0f);
		for (int i = 0;  i <= msg4.Length;  i++)
		{
			textComp.text = msg4.Substring (0, i);
			GetComponent<AudioSource>().PlayOneShot(putt);
			yield return new WaitForSeconds(typeDelay);
		}

		yield return new WaitForSeconds(3.0f);
		currentCanvas.enabled = false;
		audio.Play ();
	}

	public IEnumerator TypeOff()
	{
		for(int i = msg1.Length; i >=0; i --)
		{
			textComp.text = msg1.Substring (0, i);
			yield return new WaitForSeconds(typeDelay);
		}
	}
}