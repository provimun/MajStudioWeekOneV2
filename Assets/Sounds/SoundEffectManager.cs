using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    //remember to init stuff in the editor!!! 
    //also, set sounds to decompress on load 

    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider otherCollider) {

        //if the collider is the one in the middle, play my sound 
        
        //myAudioSource.PlayOneShot(); 

        //if the collider is the player, play my sound but fucked up

    }


}
