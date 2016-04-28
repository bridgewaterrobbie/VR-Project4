using UnityEngine;
using System.Collections;

public class HomelessDude : MonoBehaviour {
	public bool driverIsDrunk = true;

	// Use this for initialization
	void Start () {
		driverIsDrunk = true;
	}

	// Update is called once per frame
	void Update () {
		if (driverIsDrunk) { 
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);
		}

	}

	void setDriverIsDrunk(bool isDrunk){
		driverIsDrunk = isDrunk;

	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}

		if (collision.relativeVelocity.magnitude > 2)
			GetComponent<AudioSource>().Play(); 
	}
}
