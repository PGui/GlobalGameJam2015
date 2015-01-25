using UnityEngine;
using System.Collections;

public class footballAudio : MonoBehaviour {

	public AudioClip soundBall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		GetComponent<AudioSource>().PlayOneShot(soundBall);
	}
}
