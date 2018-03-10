using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour {

    public string[] footStepSoundNames;
	
    public void PlayFootStepSound()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayRandom(footStepSoundNames);
    }
}
