using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	public AudioClip[] tracks;
	public AudioClip BLOOD;
	public AudioClip DNA;
	public AudioClip YAH;
	public AudioClip ELEMENT;
	public AudioClip FEEL;
	public AudioClip LOTALTY;
	public AudioClip PRIDE;
	public AudioClip HUMBLE;
	public AudioClip LUST;
	public AudioClip LOVE;
	public AudioClip XXX;
	public AudioClip FEAR;
	public AudioClip GOD;
	public AudioClip DUCKWORTH;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		this.audioSource = this.GetComponent<AudioSource>();
		SelectAndPlay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Randomly selects a song in track list and plays it
	private void SelectAndPlay() {
		this.audioSource.clip = tracks[Random.Range(0, 13)];
		this.audioSource.Play();
	}
}
