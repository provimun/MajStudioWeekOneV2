using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    //remember to init stuff in the editor!!! 
    //also, set sounds to decompress on load 

    AudioSource myAudioSource;

    public float audioScale;
    public bool isTravellingLeft;

    float loopCoordsPos = 10.0F;
    float loopCoordsNeg = -10.0F;

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
            myAudioSource.PlayOneShot(myAudioSource.clip, audioScale); 
            hasPlayedSound = true; 
        }

        //if we cross a certain x value, we loop back around exactly. 
        if(!isTravellingLeft && transform.position.x > loopCoordsPos) {
            //overflow positive, return to negative 
            transform.Translate((transform.position.x - loopCoordsNeg), 0, 0);
            resetMe();
        } else if(isTravellingLeft && transform.position.x < loopCoordsNeg) {
            //overflow negative, return to positive 
            transform.Translate((transform.position.x - loopCoordsPos), 0, 0);
            resetMe();
        }

        //finally, update the previous x pos 
        prevX = transform.position.x;

    }

    void OnTriggerEnter(Collider otherCollider) {

        //if the collider is the player, play my sound but fucked up 
        //myAudioSource.PlayOneShot(myAudioSource.clip, audioScale); 
        //hasPlayedSound = true; 

    }

    //for resetting values every time this obstacle gets looped back to where it started 
    public void resetMe() {
        prevX = transform.position.x; 
        hasPlayedSound = false; 
    }


}
