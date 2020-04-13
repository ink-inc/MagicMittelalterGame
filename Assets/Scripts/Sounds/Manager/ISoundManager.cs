namespace Sounds.Manager
{
    public interface ISoundManager
    {
        /// <summary>
        /// Pauses all sounds.
        /// </summary>
        void Pause();

        /// <summary>
        /// Continue all sounds from where they stopped.
        /// </summary>
        void Continue();
    }
}