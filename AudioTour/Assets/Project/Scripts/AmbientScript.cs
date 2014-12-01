using UnityEngine;
using System.Collections;

public class AmbientScript : MonoBehaviour {

	public GameObject otherObject;
	private bool fadeOut = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeOut) {
			if (otherObject.audio.volume > 0) {
			    otherObject.audio.volume -= 1 * Time.deltaTime;
			} else {
				otherObject.audio.Stop();
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		fadeOut = false;
		otherObject.audio.volume = 1;
		if (!otherObject.audio.isPlaying) {
			otherObject.audio.Play ();
			otherObject.audio.loop = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (otherObject.audio.isPlaying) {
			fadeOut = true;
		}
	}
}
