using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerListener : MonoBehaviour
{
    public enum State
    {
        Grounded, Airborne
    }
    
    private LayerMask _deathMask;
    private LayerMask _groundMask;

    private Rigidbody _rigidbody;
    private Vector3 jumpHeightVector;
    
    public State currentState = State.Grounded;

    private void Start()
    {
        _deathMask = LayerMask.GetMask("Death");
        _groundMask = LayerMask.GetMask("Ground");
        _rigidbody = GetComponent<Rigidbody>();
        
        jumpHeightVector = new Vector3(0f,8f,0f);
    }

    private void FixedUpdate()
    {
        //State determined by distance to Ground Layer
        if(Physics.Raycast(transform.position, -Vector3.up, .2f, _groundMask))
        {
            currentState = State.Grounded;
            Debug.Log("Hit ground from .2f");
        }
        Debug.Log("State Now: " + currentState);
        
        //If Entity reaches void, Destroy it
        if (Physics.Raycast(transform.position, -Vector3.up, 1f, _deathMask))
        {
            Debug.Log(name + " Death layer hit from 1f");
            Destroy(this);
        }
    }

    public void Jump(float force)
    {
        _rigidbody.AddForce(jumpHeightVector * force, ForceMode.Impulse);
    }
}
