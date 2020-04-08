namespace MenuScripts
{
    public class SettingsMenu : CloseableMenu
    {
        //The audio settings menu
        public AudioSettingsMenu audioSettingsMenu;
        public void AudioSettingsButton()
        {
            audioSettingsMenu.Show();
        }
    }
}