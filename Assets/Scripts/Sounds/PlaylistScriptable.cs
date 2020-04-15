using System.Collections.Generic;
using UnityEngine;

namespace Sounds
{
    [CreateAssetMenu(fileName = "Playlist", menuName = "ScriptableObjects/PlaylistScriptable", order = 1)]
    public class PlaylistScriptable : ScriptableObject
    {
        public List<AudioClip> playlist;
    }
}