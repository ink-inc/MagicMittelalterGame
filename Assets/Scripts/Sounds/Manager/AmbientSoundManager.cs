using UnityEngine;
using UnityEngine.Audio;

namespace Sounds.Manager
{
    public class AmbientSoundManager : MonoBehaviour, ISoundManager
    {
        public AudioMixerGroup mixerGroup;

        private DoubleAudioSource _audioSource;

        /// <summary>
        /// Setups up the ambient sound manager.
        /// </summary>
        private void Start()
        {
            _audioSource = gameObject.AddComponent<DoubleAudioSource>();
            _audioSource.Start();
            _audioSource.MixerGroup = mixerGroup;
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
    }
}