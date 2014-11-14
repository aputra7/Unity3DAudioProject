using UnityEngine;
using System.Collections;

public class TriggerCollider : MonoBehaviour {

	public GameObject otherObject;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (!otherObject.audio.isPlaying) {
		    otherObject.audio.Play ();
		}
	}
}
