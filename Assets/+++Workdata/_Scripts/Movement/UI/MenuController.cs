using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ___Workdata._Scripts.Movement.UI
{
    public class MenuController : MonoBehaviour
    {


        [Header("main")] 
        [SerializeField] private CanvasGroup canvasGroupMain;

        [SerializeField] private Button buttonNewGame;
        [SerializeField] private Button buttonLevelSelection;
        [SerializeField] private Button buttonExit;

        [Header("LevelSelection")]
        [SerializeField] private CanvasGroup canvasGroupLevelSelection;

        [SerializeField] private Button buttonBack;
        [SerializeField] private Button buttonLevel1;
        [SerializeField] private Button buttonLevel2;
        [SerializeField] private Button buttonLevel3;
    
    
    
        [SerializeField] private string[] sceneNamesLevel;
    
    
    
        // Start is called before the first frame update
        void Start()
        {
            canvasGroupMain.ShowCanvasGroup();
            canvasGroupLevelSelection.HideCanvasGroup();
        
        
            buttonNewGame.onClick.AddListener(LoadLevel1);
            buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
            buttonExit.onClick.AddListener(ExitGame);
            buttonBack.onClick.AddListener(BackToMain);
        
            buttonLevel1.onClick.AddListener(LoadLevel1);
            buttonLevel2.onClick.AddListener(LoadLevel2);
            buttonLevel3.onClick.AddListener(LoadLevel3);

            buttonLevel2.interactable = false;
            if (PlayerPrefs.HasKey(sceneNamesLevel[1]))
            {
                if (PlayerPrefs.GetInt(sceneNamesLevel[1]) == 1)
                    buttonLevel2.interactable = true; 
            }
        
            buttonLevel3.interactable = false;
            if (PlayerPrefs.HasKey(sceneNamesLevel[2]))
            {
                if (PlayerPrefs.GetInt(sceneNamesLevel[2]) == 1)
                    buttonLevel3.interactable = true; 
            }
        
        
        }

        public void LoadLevel1()
        {
            SceneManager.LoadScene(sceneNamesLevel[0]);
        }

        void LoadLevel2()
        {
            SceneManager.LoadScene(sceneNamesLevel[1]);
        }
    
        void LoadLevel3()
        {
            SceneManager.LoadScene(sceneNamesLevel[2]);
        }
    
    
        void ShowLevelSelection()
        {
            canvasGroupMain.HideCanvasGroup();
            canvasGroupLevelSelection.ShowCanvasGroup();
        }

        void ExitGame()
        {
            Application.Quit(); 
        }

        void BackToMain()
        {
            canvasGroupMain.ShowCanvasGroup();
            canvasGroupLevelSelection.HideCanvasGroup();
        }
    }
}
