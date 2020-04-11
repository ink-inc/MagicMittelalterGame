using UnityEngine;
using UnityEngine.Audio;

namespace Sounds.Manager
{
    public class AmbientSoundManager : MonoBehaviour, ISoundManager
    {
        public AudioMixerGroup mixerGroup;

        public AudioClip ambientClip;

        private DoubleAudioSource _audioSource;

        /// <summary>
        /// Setups up the ambient sound manager.
        /// </summary>
        private void Start()
        {
            _audioSource = gameObject.AddComponent<DoubleAudioSource>();
            _audioSource.Start();
            _audioSource.MixerGroup = mixerGroup;
            PlayOnAwake();
        }

        /// <summary>
        /// Pauses the ambient sound.
        /// </summary>
        public void Pause()
        {
            _audioSource.Pause();
        }

        /// <summary>
        /// Unpause the ambient sound.
        /// </summary>
        public void Continue()
        {
            _audioSource.UnPause();
        }

        /// <summary>
        /// Plays the sound when the object is instantiated.
        /// </summary>
        private void PlayOnAwake()
        {
            _audioSource.IsLoop = true;
            if (_audioSource.IsPlaying) return;
            float clipLength = ambientClip.length;
            float startTime = Random.Range(0f, clipLength);
            _audioSource.CrossFadeToNewClip(ambientClip, startTime: startTime);
        }
    }
}