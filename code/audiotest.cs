using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotest : MonoBehaviour {
    public AudioSource s;
   // public AudioSource c;

    // Use this for initialization
    void Start () {
        AudioConfiguration audio_config = AudioSettings.GetConfiguration();
        AudioSettings.Reset(audio_config);
        //  this.c.Play();	
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        { this.s.Play(); }
	}
}
