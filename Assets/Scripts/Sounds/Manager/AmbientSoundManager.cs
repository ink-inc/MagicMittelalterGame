using UnityEngine;
using UnityEngine.Audio;

namespace Sounds.Manager
{
    public class AmbientSoundManager : MonoBehaviour, ISoundManager
    {
        [Tooltip("Mixer of the ambient sounds")]
        public AudioMixerGroup mixerGroup;
        
        [Tooltip("Audio Clip of the ambient sound.")]
        public AudioClip ambientClip;

        [Header("Reverb Zone Settings")]
        [Tooltip("Preset of the reverb zone.")]
        public AudioReverbPreset reverbPreset;

        [Tooltip("Radius where the reverb effect does not change.")]
        public float minDistance;
        [Tooltip("The most fare radius where the reverb effect does start.")]
        public float maxDistance;
        
        private DoubleAudioSource _audioSource;
        private AudioReverbZone _reverbZone;

        /// <summary>
        /// Setups up the ambient sound manager.
        /// </summary>
        private void Start()
        {
            _audioSource = gameObject.AddComponent<DoubleAudioSource>();
            _reverbZone = GetComponent<AudioReverbZone>();
            _reverbZone.maxDistance = maxDistance;
            _reverbZone.minDistance = minDistance;
            _reverbZone.reverbPreset = reverbPreset;
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