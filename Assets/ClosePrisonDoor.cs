using UnityEngine;
using System.Collections;

public class ClosePrisonDoor : MonoBehaviour {
	public Transform target;
	public float speed;

	// Use this for initialization
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
