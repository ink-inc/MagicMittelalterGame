namespace MenuScripts
{
    
    /// <summary>
    /// Contains links to all sub settings menus.
    /// </summary>
    public class SettingsMenu : CloseableMenu
    {
        //The audio settings menu
        public AudioSettingsMenu audioSettingsMenu;
        /// <summary>
        /// Calls the audio settings menu.
        /// </summary>
        public void AudioSettingsButton()
        {
            audioSettingsMenu.Show();
        }
    }
}