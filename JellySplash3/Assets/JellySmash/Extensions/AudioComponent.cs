using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace JellySmash.Extensions
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioComponent : MonoBehaviour, IPointerDownHandler
    {
        public AudioClip Clip;
        public AudioPlayScenario PlayScenario;

        private AudioSource _audioSource;

        private void Start()
        {    
            _audioSource = this.GetComponent<AudioSource>();

            SetAudioClip();

            if (PlayScenario == AudioPlayScenario.START)
            {
                PlayAudio();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (PlayScenario == AudioPlayScenario.POINTER_DOWN)
            {
                PlayAudio();
            }
        }

        private void SetAudioClip()
        {
            _audioSource.clip = Clip;
        }

        public void PlayAudio()
        {
            _audioSource.Play();
        }
    }

    public enum AudioPlayScenario {POINTER_DOWN, START};
}
