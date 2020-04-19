using System.Collections.Generic;
using UnityEngine;

namespace Sounds
{
    [CreateAssetMenu(fileName = "Playlist", menuName = "ScriptableObjects/PlaylistScriptable", order = 1)]
    public class PlaylistScriptable : ScriptableObject
    {
        [Tooltip("Name of the playlist. Must be unique.")]
        public new string name;
        [Tooltip("Load all audio clips in it. First enter the number of clips you want to have (can later be changed).")]
        public List<AudioClip> playlist;
    }
}