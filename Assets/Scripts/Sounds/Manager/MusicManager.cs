using UnityEngine;
using UnityEngine.Audio;

namespace Sounds.Manager
{
    /// <summary>
    /// Coordinates the playing of music.
    /// </summary>
    public class MusicManager : MonoBehaviour, ISoundManager
    {
        public AudioMixerGroup mixerGroup;

        public PlaylistScriptable defaultPlaylist;
        
        private PlayList _playlist;
        private bool _isPlaying;
        private DoubleAudioSource _audioSource;

        /// <summary>
        /// Sets up the essential components.
        /// </summary>
        private void Start()
        {
            _audioSource = gameObject.AddComponent<DoubleAudioSource>();
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
        /// Starts playing a given playlist.
        /// </summary>
        /// <param name="playList">Playlist to play</param>
        public void PlayPlaylist(PlaylistScriptable playList = null)
        {
            if (playList == null)
            {
                playList = defaultPlaylist;
            }
            
            if (_playlist != null) {
                if (_playlist.Name == playList.name) return;
            
                _playlist.FadeOut();
            }

            _audioSource.MixerGroup = mixerGroup;

            _playlist = PlayList.Load(playList, _audioSource);;
            _isPlaying = true;
            _playlist.Play(3);
            
        }
    }
}