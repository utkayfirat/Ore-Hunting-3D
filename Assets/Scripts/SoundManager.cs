using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip digStone, destroyStone, coinBlink;
    static AudioSource audioSrc;

    void Start(){
        digStone = Resources.Load<AudioClip>("dig_stone");
        destroyStone = Resources.Load<AudioClip>("destroy");
        coinBlink = Resources.Load<AudioClip>("coin_blink");

        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip){
        switch(clip){
            case "dig":
                audioSrc.PlayOneShot(digStone,0.7f);
                break;
            
            case "destroy":
                audioSrc.PlayOneShot(destroyStone,0.7f);
                break;

            case "money":
                audioSrc.PlayOneShot(coinBlink,0.8f);
                break;
        }
    }
}
