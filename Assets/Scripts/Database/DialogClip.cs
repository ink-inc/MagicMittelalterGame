using UnityEngine;

namespace Database
{
    public class DialogClip
    {
        public AudioClip Clip { get; }
        public int Id { get; }
        public int LineId { get; }

        public DialogClip(AudioClip clip, int id, int lineId)
        {
            Clip = clip;
            Id = id;
            LineId = lineId;
        }
    }
}