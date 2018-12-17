using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntityTurtle : Entity
{
    public float MoveSpeed = 0f;
    
    private Vector3 _direction;
    private Rigidbody _rigidBody;
    private LayerMask _wallMask;
    private LayerMask _groundMask;
    
    private void Start()
    {   
        _wallMask = LayerMask.GetMask("Wall");
        _wallMask = LayerMask.GetMask("Ground");
        _rigidBody = GetComponent<Rigidbody>();
        
        StartCoroutine("SeekDestination");
    }

    private void FixedUpdate()
    {
        
    }

    IEnumerator SeekDestination()
    {
        var destination = getDestination();
        transform.rotation = Quaternion.LookRotation(destination);
        float x, z;
        
        while (transform.position != destination)
        {
            x = Time.deltaTime * MoveSpeed;
            z = Time.deltaTime * MoveSpeed;
            
            transform.Translate(x,0f,z);
            
            if (Physics.Raycast(transform.position, transform.forward, 10f, _wallMask))
            {
                destination = getDestination();
                Debug.Log(name + " Wall layer hit from 10f");
            }
            
            yield return null;
        }

        
    }
    
    private void ChangeVelocity()
    {
        _direction = SetDirection();
        _rigidBody.velocity = _direction * MoveSpeed;
        
        transform.rotation = Quaternion.LookRotation(_direction);
        
        Debug.LogFormat(this.name + ": x={0}, y={1}, z={2}", 
            _rigidBody.velocity.x, _rigidBody.velocity.y, _rigidBody.velocity.z );
    }
        
    private Vector3 SetDirection()
    {
        var x = Random.Range(-3,3);
        var z = Random.Range(-3,3);
            
        return new Vector3(x,0,z);
    }

    private Vector3 getDestination()
    {
        var turtlePos = transform.position;

        var deltaX = turtlePos.x + Random.Range(-5, 5);
        var deltaZ = turtlePos.z + Random.Range(-5, 5);
       
        return new Vector3(deltaX,turtlePos.y,deltaZ);
    }
}
