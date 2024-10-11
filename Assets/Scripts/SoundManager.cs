using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //Es mejor hacer un array e ir indivisualmente a cada objeto que emita sonidos y añadirle el script de sonidos junto al de sound manager. Y vas eliginedo los audios en cuestion
    public static SoundManager instance;

    public AudioSource _audioSource;
    public AudioClip coinAudio;
    public AudioClip jumpAudio;

    public AudioClip hurtAudio;

    public AudioClip pauseAudio;

    public AudioClip mimicAudio;



    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        _audioSource = GetComponent<AudioSource>();
    }
    

   /* public void CoinSFX()
    {
        _audioSource.PlayOneShot(_coinAudio);
    }*/

    public void PlaySFX(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }


}
