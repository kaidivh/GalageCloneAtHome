using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosion : MonoBehaviour
{
	public AudioSource audioSource;

    public AudioClip audioClipOne;
	
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClipOne;
    }

	public void PlaySound(){
		audioSource.Play();
	}
}
