using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIManager : MonoBehaviour
    {
        #region Singleton
        
        private static UIManager _instance = null;
        static UIManager(){}
        private UIManager(){}

        public static UIManager Instance
        {
            get
            {
                return _instance;
            }
        }
        
        #endregion

        public enum UIMenu
        {
            Main, Pause, LoadGame, Achievement
        }
        
        [SerializeField]
        public GameObject[] Menus = new GameObject[4];

        private void Start()
        {
            foreach (var menu in Menus)
            {
                if (menu == null)
                {
                    Debug.LogWarning(menu.name + " is undefined in UIManager inspector");
                    continue;
                }
                menu.gameObject.SetActive(false);
            }
        }
        
        private void Awake()
        {
            if(_instance == null)
                _instance = this;
            else if(_instance !=this)
                Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);

        }

        public void ToggleUIElement(UIMenu menu)
        {
            var activeMenu = Menus[(int)menu];

            if (activeMenu == null)
            {
                Debug.LogWarning("UI element is undefined in UIManager inspector");
                return;
            }
            
            if (activeMenu.activeInHierarchy)
            {
                activeMenu.gameObject.SetActive(false);
            }
            else
            {
                activeMenu.gameObject.SetActive(true);
            }
        }
    }
}