using UnityEngine.Audio;
using System;
using UnityEngine;

//The code in this class is from. https://www.youtube.com/watch?v=6OT43pvUyfY . This is how we manage audio in the scene
public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance { get; private set; }

    [SerializeField]
    private SoundClass[] sounds;

    void Awake()
    {
        //This enables singleton pattern to be used. The same pattern also exists in GameManagerScript.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        foreach (SoundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    public void Play(string sound)
    {
        SoundClass s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }

}
