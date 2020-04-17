using UnityEngine;
using UnityEngine.Audio;

namespace Sounds.Manager
{
    /// <summary>
    /// Coordinates the playing of music.
    /// </summary>
    [AddComponentMenu("Sound/Music Sound Manager")]
    public class MusicManager : MonoBehaviour, ISoundManager
    {
        public AudioMixerGroup mixerGroup;
        
        private PlayList _playlist;
        private bool _isPlaying;
        private DoubleAudioSource _audioSource;

        /// <summary>
        /// Sets up the essential components.
        /// </summary>
        private void Start()
        {
            _audioSource = gameObject.AddComponent<DoubleAudioSource>();
            _audioSource.Start();
            _audioSource.MixerGroup = mixerGroup;
            _audioSource.ReverbZoneMix = 0f;
            _isPlaying = false;
            _playlist = null;
        }

        /// <summary>
        /// Checks if the current track is finished and would start the next one.
        /// </summary>
        public void FixedUpdate()
        {
            if (_isPlaying)
            {
                _playlist.CheckPlaying();
            }
        }

        /// <summary>
        /// Pauses all music.
        /// </summary>
        public void Pause()
        {
            _isPlaying = false;
            _audioSource.Pause();
        }

        /// <summary>
        /// Continues music from where it stopped
        /// </summary>
        public void Continue()
        {
            _isPlaying = true;
            _audioSource.UnPause();
        }

        /// <summary>
        /// Skips the current track and plays the next one.
        /// </summary>
        public void Next()
        {
            _playlist.Play();
        }

        /// <summary>
        /// Trigger for playing the fighting playlist.
        /// </summary>
        public void Fight()
        {
            if (_playlist != null) {
                if (_playlist.Name == "fight") return;
            
                _playlist.FadeOut();
            }
            
            _playlist = PlayList.Load("fight", _audioSource);
            _isPlaying = true;
            _playlist.Play(3, fadeDuration: 5f);
        }

        /// <summary>
        /// Plays the background music for a given area.
        /// </summary>
        /// <param name="area">Area where the player currently is</param>
        public void Background(string area)
        {
            if (_playlist != null) {
                if (_playlist.Name == area) return;
            
            _playlist.FadeOut();
            }

            _audioSource.MixerGroup = mixerGroup;
            _playlist = PlayList.Load(area, _audioSource);
            _isPlaying = true;
            _playlist.Play();
        }
    }
}