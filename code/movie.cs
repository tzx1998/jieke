using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class movie : MonoBehaviour {
    public VideoClip _VideoClip;
    public VideoPlayer vp;
    public List<VideoClip> videocliplist;

	// Use this for initialization
	void Start () {
        vp = GetComponent<VideoPlayer>();
        vp.clip = _VideoClip;
        vp.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))

        {

            Application.Quit();

        }
    }
}
