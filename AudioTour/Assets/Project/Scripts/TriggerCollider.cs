using UnityEngine;
using System.Collections;

public class TriggerCollider : MonoBehaviour {

	public GameObject otherObject;
	public AudioClip defaultClip;
	public AudioClip ratings;
	private bool showRatings = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (!otherObject.audio.isPlaying && showRatings) {
			otherObject.audio.clip = ratings;
			otherObject.audio.Play();
			showRatings = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!otherObject.audio.isPlaying) {
			otherObject.audio.clip = defaultClip;
		    otherObject.audio.Play ();
			showRatings = true;
		}
	}
}
