using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] audioSources;

    public string[] ids;
    public AudioClip[] audioClips;

    public AudioSource musicSource;
    public AudioClip menu;
    public AudioClip game;

    protected Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

    public float transitionTime = .5f;

    public void Start()
    {
        instance = this;
        musicSource.clip = menu;
        musicSource.loop = true;
        musicSource.Play();
        CreateDict();
    }

    protected void CreateDict()
    {
        for (int i = 0; i < ids.Length; i++)
        {
            clipDict.Add(ids[i], audioClips[i]);
        }
    }

    public void PlaySound(string id)
    {
        AudioSource toUse = null;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if(!audioSources[i].isPlaying)
            {
                toUse = audioSources[i];
                break;
            }
        }

        if(toUse != null)
        {
            toUse.PlayOneShot(clipDict[id]);
        }
    }

    public void SwitchMusicToGameplay()
    {
        StartCoroutine(FadeIn());
    }

    protected IEnumerator FadeIn()
    {
        float volume = musicSource.volume;
        float currentVolume = volume;
        float counter = 0;
        float t;

        while (counter < 0)
        {
            counter += Time.deltaTime;
            t = Mathf.InverseLerp(0, transitionTime, counter);
            currentVolume = Mathf.Lerp(volume,0, t);
            yield return null;
        }

        musicSource.clip = game;
        counter = 0;
        musicSource.Play();
        while (counter < 0)
        {
            counter += Time.deltaTime;
            t = Mathf.InverseLerp(0, transitionTime, counter);
            currentVolume = Mathf.Lerp(0,volume, t);
            yield return null;
        }
    }
}
