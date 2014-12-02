using UnityEngine;
using System.Collections;

public class InnerCollider : MonoBehaviour {

	public GameObject otherObject;
	public AudioClip[] clips = new AudioClip[2];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (!otherObject.audio.isPlaying) {
			float f = Random.Range(0f,100f);
			if (f > 50f) {
			    otherObject.audio.clip = clips[1];
			} else {
				otherObject.audio.clip = clips[0];
			}
			otherObject.audio.Play ();
		}
	}
}
