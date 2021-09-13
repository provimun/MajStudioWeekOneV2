using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    //remember to init stuff in the editor!!! 
    //also, set sounds to decompress on load 

    AudioSource myAudioSource;

    public float audioScale;
    public float speed;

    float loopCoordsPos = 8.0F;
    float loopCoordsNeg = -8.0F;

    bool hasPlayedSound = false; //safeguard
    float prevX;
    bool isTravellingLeft;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        prevX = transform.position.x;
        isTravellingLeft = speed > 0 ? false : true; 
    }

    void Update() {

        //adding rudimentary movement cause programmer is busy 
        transform.Translate(speed * Time.deltaTime, 0, 0);

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
            transform.Translate((loopCoordsNeg - transform.position.x), 0, 0);
            resetMe();
        } else if(isTravellingLeft && transform.position.x < loopCoordsNeg) {
            //overflow negative, return to positive 
            transform.Translate((loopCoordsPos - transform.position.x), 0, 0);
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
