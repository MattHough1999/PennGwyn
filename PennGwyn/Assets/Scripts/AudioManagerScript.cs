using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    [Header(" Effects Related ")]
    public AudioMixerGroup EffectsMixer;
    public int NumberOfAudioSources = 25;
    public List<AudioSource> AudioSourcesList = new List<AudioSource>();

    public GameObject SoundEffectsGo;
    private bool ranStart = false;

    private void Awake()
    {

        if (ranStart) { return; }
        ranStart = true;

        AudioSource source;
        for (int i = 0; i < NumberOfAudioSources; i++)
        {
            source = SoundEffectsGo.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = EffectsMixer;
            AudioSourcesList.Add(source);
        }

    }

    public IEnumerator PlayEffect(AudioClip clip)
    {

        //Debug.Log("Play effect");
        AudioSource _audioSource = null;
        foreach (AudioSource source in AudioSourcesList)
        {
            if (source.clip == null)
            {
                // Not being used.
                _audioSource = source;
                break;
            }
        }

        if (_audioSource == null) { Debug.Log("Audio source ran out of sources."); }
        else
        {

            //Debug.Log("Play");
            _audioSource.clip = clip;
            _audioSource.Play();

            yield return new WaitForSeconds(_audioSource.clip.length);

            _audioSource.clip = null;

        }
    }
}
