using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class KeyboardListener : MonoBehaviour
{
    private PlayerListener PlayerListenerScript;
    private MouseListener MouseListenerScript;
    
    private void Start()
    {
        PlayerListenerScript = GetComponent<PlayerListener>();
        MouseListenerScript = GetComponentInChildren<MouseListener>();
    }
    
    private void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        if (Input.GetKeyDown(KeyCode.Space) && PlayerListenerScript.currentState != PlayerListener.State.Airborne)
        {
            PlayerListenerScript.Jump(5f);
        }

        transform.Translate(x, 0f, z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.TogglePauseMenu();
            MouseListenerScript.enabled = !GameManager.Instance.isPaused;
            

        }
    }
}