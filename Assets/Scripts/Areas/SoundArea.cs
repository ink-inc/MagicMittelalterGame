using Sounds;
using Sounds.Manager;
using UnityEngine;

namespace Areas
{
    public class SoundArea : MonoBehaviour
    {
        [Tooltip("Load a playlist into it, which will be played upon entering.")]
        public PlaylistScriptable playlistScriptable;

        private MusicManager _musicManager;

        private void Start()
        {
            _musicManager = GameObject.Find("Player").GetComponent<MusicManager>();
        }

        /// <summary>
        /// Starts playing music upon player entering.
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.name != "Player") return;
            _musicManager.PlayPlaylist(playlistScriptable);
        }
        
        /// <summary>
        /// Switches back to default music upon player leaving.
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit(Collider other)
        {
            if (other.name != "Player") return;
            _musicManager.PlayPlaylist();
        }
    }
}   