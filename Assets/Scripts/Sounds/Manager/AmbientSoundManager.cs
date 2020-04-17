using UnityEngine;
using UnityEngine.Audio;

namespace Sounds.Manager
{
    [AddComponentMenu("Sound/Ambient Sound Manager")]
    public class AmbientSoundManager : MonoBehaviour, ISoundManager
    {
        [Tooltip("Mixer of the ambient sounds")]
        public AudioMixerGroup mixerGroup;
        
        [Tooltip("Audio Clip of the ambient sound.")]
        public AudioClip ambientClip;
        
        [Tooltip("Distance when you start hearing the ambient sound.")]
        public int rollOffMaxDistance = 50;


        private DoubleAudioSource _audioSource;
        private AudioReverbZone _reverbZone;
        public float targetVolume = 0.5f;

        /// <summary>
        /// Setups up the ambient sound manager.
        /// </summary>
        private void Start()
        {
            _audioSource = gameObject.AddComponent<DoubleAudioSource>();
            _reverbZone = GetComponent<AudioReverbZone>();
            if (_reverbZone != null)
            {
                _reverbZone.enabled = false;
            }
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
        /// Activates the reverb zone if player enters.
        /// </summary>
        /// <param name="other">Object entering the zone.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player") _reverbZone.enabled = true;
        }

        /// <summary>
        /// Disables the reverb zone if player leaves.
        /// </summary>
        /// <param name="other">Object leaving zone.</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Player") _reverbZone.enabled = false;
        }

        /// <summary>
        /// Plays the sound when the object is instantiated.
        /// </summary>
        private void PlayOnAwake()
        {
            _audioSource.IsLoop = true;
            if (_audioSource.IsPlaying || ambientClip == null) return;
            float clipLength = ambientClip.length;
            float startTime = Random.Range(0f, clipLength);
            _audioSource.MixerGroup = mixerGroup;
            _audioSource.FadeIn(ambientClip, startTime: startTime, rollOffMaxDistance:rollOffMaxDistance,
                targetVolume:targetVolume);
        }
    }
}