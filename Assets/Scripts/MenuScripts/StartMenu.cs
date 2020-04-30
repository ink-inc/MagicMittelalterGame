using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenuScripts
{
    /// <summary>
    /// The Main menu script.
    /// Contains all methods for scene loading, settings menu, in the main menu.
    /// </summary>
    public class StartMenu : MonoBehaviour
    {
        public string defaultScene = "Main";

        public GameObject sceneSelectorObjectPrefab;
        public string[] sceneNames;

        public Transform startMenuParent;
        public Transform sceneSelectorParent;

        private void Start()
        {
            Time.timeScale = 1;
            Logger.log("Scenes found: " + sceneNames.Length);
            for (int i = sceneNames.Length - 1; i >= 0; i--) //Array wird von hinten durchlaufen, damit die Reihenfolge des Editor-Arrays beibehalten wird
            {
                string sceneName = sceneNames[i];
                GameObject obj = Instantiate(sceneSelectorObjectPrefab, sceneSelectorParent); //Create Button instance to load scene
                obj.name = "SceneSelectorObject_" + sceneName; //Set name for editor clarity
                Button buttonComponent = obj.GetComponent<Button>();
                buttonComponent.onClick.AddListener(delegate () { StartScene(sceneName); }); //Add button click handler to load specified scene
                obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = sceneName; //Display scene name in Text component
                obj.transform.SetAsFirstSibling(); //Needed for vertical layout, so the "Back"-Button is shown last
            }
        }

        public void StartGameButton()
        {
            StartScene(defaultScene);
        }

        public void ShowSceneSelector()
        {
            startMenuParent.gameObject.SetActive(false);
            sceneSelectorParent.gameObject.SetActive(true);
        }

        public void HideSceneSelector()
        {
            startMenuParent.gameObject.SetActive(true);
            sceneSelectorParent.gameObject.SetActive(false);
        }

        public void StartScene(string name)
        {
            Logger.log("Load scene: " + name);
            SceneManager.LoadScene(name);
        }

        public void StartScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void ExitGameButton()
        {
            Application.Quit();
        }
    }
}