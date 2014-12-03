using UnityEngine;
using System.Collections;

public class InnerCollider : MonoBehaviour {

	public GameObject otherObject;
	public GameObject timerObject;
	public GameObject ambientObject;
	public AudioClip[] clips = new AudioClip[2];
	private bool timer = false;
	private bool fadeOut = false;
	private float timerPitch = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeOut) {
			if (ambientObject.audio.volume > 0) {
				ambientObject.audio.volume -= 1 * Time.deltaTime;
			} else {
				ambientObject.audio.Stop();
			}
		}

		if (timer) {
			timerPitch += (float) Time.deltaTime * 0.02f;
			timerObject.audio.pitch = timerPitch;
			timerObject.audio.volume -= (float) Time.deltaTime * 0.0075f;
			if (timerPitch >= 3f) {
				timerObject.audio.Stop();
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (ambientObject.audio.isPlaying) {
			fadeOut = true;
		}

		if (!otherObject.audio.isPlaying) {
			float f = Random.Range(0f,100f);
			if (f > 50f) {
			    otherObject.audio.clip = clips[1];
			} else {
				otherObject.audio.clip = clips[0];
			}
			otherObject.audio.Play ();

			timerPitch = 1f;
			timerObject.audio.pitch = timerPitch;
			timerObject.audio.Play ();
			timer = true;
		}
	}

	void OnTriggerExit(Collider other) {
		fadeOut = false;
		ambientObject.audio.volume = 0.3f;
		if (!ambientObject.audio.isPlaying) {
			ambientObject.audio.Play ();
			ambientObject.audio.loop = true;
		}


		timerObject.audio.Stop ();
		timer = false;
		timerPitch = 1f;
		timerObject.audio.volume = 0.3f;
		timerObject.audio.pitch = timerPitch;
	}
}
