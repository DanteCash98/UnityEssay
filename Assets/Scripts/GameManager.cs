using System.Xml;
using Boo.Lang;
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

        private PlayerProfile _playerProfile;
        public bool isPaused = false;

        private void Start()
        {
            _playerProfile = LoadGame.LoadPlayer();
        }

        private void Awake()
        {
            if(_instance == null)
                _instance = this;
            else if(_instance != this)
                Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);
            
        }

        public void TogglePauseMenu()
        {
            if (!isPaused)
            {
                isPaused = true;
                Debug.Log("Toggling ui; is paused = " + isPaused);
                UIManager.Instance.ToggleUIElement(UIManager.UIMenu.Pause);
                Time.timeScale = 0.0f;

            }
            else if (isPaused)
            {
                isPaused = false;
                Debug.Log("Toggling ui; is paused = " + isPaused);
                UIManager.Instance.ToggleUIElement(UIManager.UIMenu.Pause);
                Time.timeScale = 1.0f;
            }
        }

        
        
        public void Save()
        {
            SaveGame.SavePlayer(_playerProfile);
        }
    }
}