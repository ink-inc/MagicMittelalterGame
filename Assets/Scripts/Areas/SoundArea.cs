using System;
using Sounds;
using UnityEngine;

namespace Areas
{
    public abstract class SoundArea : MonoBehaviour
    {
        [Tooltip("Name of the playlist to be played.")][Obsolete] public string playlist;
        [Tooltip("Load a playlist into it, which will be played upon entering.")]
        public PlaylistScriptable playlistScriptable;
    }
}   