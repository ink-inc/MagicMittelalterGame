using UnityEngine;

namespace Database
{
    public class DialogClip
    {
        public string Path { get; }
        public int Id { get; }
        public int LineId { get; }

        public DialogClip(string path, int id, int lineId)
        {
            Path = path;
            Id = id;
            LineId = lineId;
        }

        /// <summary>
        /// Loads the audio clip from disk.
        /// </summary>
        /// <returns>Audio Clip</returns>
        public AudioClip GetAudioClip()
        {
            AudioClip audioClip = Resources.Load<AudioClip>(Path);
            if (audioClip == null) Logger.logWarning($"Audio Clip unable to load from: {Path}");
            return audioClip;
        }
    }
}