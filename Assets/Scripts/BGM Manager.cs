using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
   public static BGMManager instance;

    private AudioSource _audioSource;

    public AudioClip backgroundMusic;
   void Awake()
   {
        if(instance != null && instance != this)  //singelton, sirve para acceder desde otro scripts, evita que haya mas de un gamemanager, y se puede acceder facilmente a todo lo que haya dentro
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        _audioSource = GetComponent<AudioSource>();
   }

   public void PlayBGM(AudioClip clip)
   {
        _audioSource.clip = clip;
        _audioSource.Play();
   }
}
