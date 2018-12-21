using System;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MouseListener : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float smoothing = 2.0f;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    private GameObject character;
    
    private void Start ()
    {
        character = transform.parent.gameObject;
    }
 
    private void Update ()
    {
        CameraLook();
    }

    private void CameraLook()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(mouseSensitivity, mouseSensitivity));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1.0f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1.0f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y,-85f,85f);
        
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

    }
}