using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    //remember to init stuff in the editor!!! 
    //also, set sounds to decompress on load 

    AudioSource myAudioSource;

    public AudioClip soundEffect;
    public float audioScale;

    bool hasPlayedSound = false; //safeguard
    float prevX;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        prevX = transform.position.x;
    }

    void Update() {

        //if the object crosses x=0, ie if the signs are different, ie if they multiply to a negative number...
            //now this is a nice trick. have to remember this one 
        if((prevX * transform.position.x) < 0 && !hasPlayedSound) {
            //..it's crossed the center, so play its sound! 
            myAudioSource.PlayOneShot(soundEffect, audioScale); 
            hasPlayedSound = true; 
        }

        //finally, update the previous x pos 
        prevX = transform.position.x;

    }

    void OnTriggerEnter(Collider otherCollider) {

        //if the collider is the player, play my sound but fucked up 
        //myAudioSource.PlayOneShot(soundEffect, audioScale); 
        //hasPlayedSound = true; 

    }

    //for resetting values every time this obstacle gets looped back to where it started 
    public void resetMe() {
        prevX = transform.position.x; 
        hasPlayedSound = false; 
    }


}
