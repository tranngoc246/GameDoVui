using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Ins;

    [Range(0,1)]
    public float mucicVolume;
    [Range(0, 1)]
    public float soundVolume;

    public AudioSource soundAus;
    public AudioSource musicAus;

    public AudioClip[] backgroundMusic;
    public AudioClip rightSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    private void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        musicAus.volume = mucicVolume;
        soundAus.volume = soundVolume;
    }

    public void PlayBackgroundMusic()
    {
        if(musicAus && backgroundMusic!=null&& backgroundMusic.Length > 0)
        {
            int randIdx = Random.Range(0, backgroundMusic.Length);
            if (backgroundMusic[randIdx])
            {
                musicAus.clip = backgroundMusic[randIdx];
                musicAus.Play();
            }
        }
    }

    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }
    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound);
    }

    public void PlaySound(AudioClip sound)
    {
        if (soundAus && sound)
        {
            soundAus.PlayOneShot(sound);
        }
    }

    public void StopMusic()
    {
        if (musicAus)
        {
            musicAus.Stop();
        }
    }

    public void MakeSingleton()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
    }
}
