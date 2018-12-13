using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{

    public sealed class GameManager : MonoBehaviour
    {
        #region Singleton
        
        private static GameManager _instance = null;
        static GameManager(){}
        private GameManager(){}

        public static GameManager Instance
        {
            get
            {
                return _instance;
            }
        }
        
        #endregion
       
        private bool _isPaused = false;

        private void Awake()
        {
            if(_instance == null)
                _instance = this;
            else if(_instance !=this)
                Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);
            
            //enerateMap(new GameSettings());
        }
        
        private static void GenerateMap(GameSettings settings)
        {
            
        }

        public void TogglePauseMenu()
        {
            if (!_isPaused)
            {
                _isPaused = true;
                Debug.Log("Toggling ui; is paused = " + _isPaused);
                UIManager.Instance.ToggleUIElement(UIManager.UIMenu.Pause);
                Time.timeScale = 0.0f;
            }
            else if (_isPaused)
            {
                _isPaused = false;
                Debug.Log("Toggling ui; is paused = " + _isPaused);
                UIManager.Instance.ToggleUIElement(UIManager.UIMenu.Pause);
                Time.timeScale = 1.0f;
            }
        }
        
        public static void SaveGame()
        {
            
        }

        public static void LoadGame()
        {
            
        }
    }
}