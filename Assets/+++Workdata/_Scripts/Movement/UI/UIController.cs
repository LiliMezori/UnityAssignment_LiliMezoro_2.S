using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ___Workdata._Scripts.Movement.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasStart;
        [SerializeField] private CanvasGroup canvasWin;
        [SerializeField] private CanvasGroup canvasLost;
        [SerializeField] private CanvasGroup canvasPauseMenu;

        [SerializeField] private Button buttonStartGame;
        [SerializeField] private Button buttonPlayAgainWin;
        [SerializeField] private Button buttonPlyAgainLose;
        [SerializeField] private Button buttonBackToMenu1;
        [SerializeField] private Button buttonBackToMenu2;
        [SerializeField] private Button buttonBackToMenu3;
        [SerializeField] private Button buttonContinue;
        [SerializeField] private Button buttonRestart; 
    
        [SerializeField] private Button buttonNextLevel;

        [Header("scene loading")] 
        [SerializeField] private string nameNextLevel;
    

        private int _coinCount;
        [SerializeField] private TextMeshProUGUI txtCoinCount; 

        private void Start()
        {
            Time.timeScale = 0f;
            txtCoinCount.text = _coinCount.ToString(); 
        
            canvasStart.ShowCanvasGroup();
            canvasLost.HideCanvasGroup();
            canvasWin.HideCanvasGroup();
            canvasPauseMenu.HideCanvasGroup();
        
            buttonStartGame.onClick.AddListener(StartGame);
            buttonPlyAgainLose.onClick.AddListener(ReloadCurrentScene); 
            buttonPlayAgainWin.onClick.AddListener(ReloadCurrentScene);
  
            buttonNextLevel.onClick.AddListener(LoadNextLevel);
        
            buttonBackToMenu1.onClick.AddListener(BackToMenu);
            buttonBackToMenu2.onClick.AddListener(BackToMenu);
            buttonBackToMenu3.onClick.AddListener(BackToMenu);
        
            buttonContinue.onClick.AddListener(ContinueCurrentLevel);
            buttonRestart.onClick.AddListener(ReloadCurrentScene);
        }
    
        void StartGame()
        {
            Time.timeScale = 1f; 
        
            canvasStart.HideCanvasGroup();
        }

        public void GameLost()
        {
            Time.timeScale = 0f;
        
            canvasLost.ShowCanvasGroup();
        }

        public void GameWin()
        {
            PlayerPrefs.SetInt(nameNextLevel,1); 
        
            Time.timeScale = 0f;
        
            canvasWin.ShowCanvasGroup();
        }

        public void AddCoin()
        {
            _coinCount++;
            txtCoinCount.text = _coinCount.ToString();

        }


        void ContinueCurrentLevel()
        {
            Time.timeScale = 1; 
            canvasPauseMenu.HideCanvasGroup();
        }
    
        void LoadNextLevel()
        {
            SceneManager.LoadScene(nameNextLevel);
        }
    
    

        void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        void BackToMenu()
        {
            SceneManager.LoadScene("menu"); 
        }
    
  
    }

    public static class ExtensionMethods
    {
    


        public static void ShowCanvasGroup (this CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public static void HideCanvasGroup (this CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

    }
}