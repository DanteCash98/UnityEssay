using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
    }

    void Update()
    {
        var y = 0.0f;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        if (Input.GetKey(KeyCode.Space))
            y = Time.deltaTime * 10.0f;
        
        transform.Translate(x, y, z);

        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.TogglePauseMenu();
    }
    
    
}