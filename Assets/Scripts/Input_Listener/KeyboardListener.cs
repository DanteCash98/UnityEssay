using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class KeyboardListener : MonoBehaviour
{
    private PlayerListener PlayerListener;
    
    void Start()
    {
        PlayerListener = new PlayerListener();
    }
    
    void Update()
    {
        var y = 0.0f;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        if (Input.GetKeyDown(KeyCode.Space) && PlayerListener.CurrentState != PlayerListener.State.Airborne)
        {
            y = Time.deltaTime * 10.0f;
            //PlayerListener.CurrentState = PlayerListener.State.Airborne;
        }

        transform.Translate(x, y, z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.TogglePauseMenu();
        }
    }
    
    
}