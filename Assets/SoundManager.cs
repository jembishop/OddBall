using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip[] clips;
    public AudioSource audiosource;
    bool muted;
    private void Start()
    {
      
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = clips[PlayerPrefs.GetInt("Track")];
        audiosource.Play();
    }
    public void Next(){
        if (PlayerPrefs.GetInt("Track") < clips.Length)
        {
            PlayerPrefs.SetInt("Track", PlayerPrefs.GetInt("Track") + 1);
            audiosource.clip = clips[PlayerPrefs.GetInt("Track")];
            print(audiosource.clip);
            audiosource.Play();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {

            if (!muted) { audiosource.Pause(); muted = true; }
            else
            {
                muted = false;
                audiosource.UnPause();
            }
           
        }
    }
}
        