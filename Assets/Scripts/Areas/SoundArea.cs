using System;
using Sounds;
using Sounds.Manager;
using UnityEngine;

namespace Areas
{
    public class SoundArea : MonoBehaviour
    {
        [Tooltip("Name of the playlist to be played.")][Obsolete] public string playlist;
        [Tooltip("Load a playlist into it, which will be played upon entering.")]
        public PlaylistScriptable playlistScriptable;

        private MusicManager _musicManager;

        private void Start()
        {
            _musicManager = GameObject.Find("Player").GetComponent<MusicManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name != "Player") return;
            _musicManager.PlayPlaylist(playlistScriptable);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.name != "Player") return;
            _musicManager.PlayPlaylist();
        }
    }
}   