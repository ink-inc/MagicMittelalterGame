using System;
using UnityEngine;

namespace Sounds.Manager
{
    public class MusicManager : MonoBehaviour, ISoundManager
    {
        private PlayList _playlist;
        private bool _isPlaying;
        private DoubleAudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.AddComponent<DoubleAudioSource>();
            _audioSource.name = "Music Source";
            _isPlaying = false;
            _playlist = null;
        }

        public void FixedUpdate()
        {
            if (_isPlaying)
            {
                _playlist.CheckPlaying();
            }
        }

        public void Pause()
        {
            _isPlaying = false;
            throw new NotImplementedException();
        }

        public void Continue()
        {
            _isPlaying = true;
            throw new NotImplementedException();
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public void Fight()
        {
            throw new NotImplementedException();
        }

        public void Background(string area)
        {
            if (_playlist != null) {
                if (_playlist.Name == area) return;
            
            _playlist.Stop();
            }

            
            _playlist = PlayList.Load(area, _audioSource);
            _isPlaying = true;
            _playlist.Play();
        }
    }
}