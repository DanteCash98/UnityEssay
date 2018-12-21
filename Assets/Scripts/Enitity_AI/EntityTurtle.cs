using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Animations;

public class EntityTurtle : Entity
{
    private enum State
    {
        Idling, Seeking
    }
    
    public float moveSpeed = 0f;
    public float rotationSpeed = 0f;
    public GameObject debugPathFlagObject;
    public AnimationClip walkingAnimationClip;
    
    private Vector3 _direction;
    private LayerMask _wallMask;
    private State currentState = State.Idling;
    
    private void Start()
    {   
        _wallMask = LayerMask.GetMask("Wall");
        Debug.Log("Turtle startin dat world!");

    }

    private void FixedUpdate()
    {
        if (currentState == State.Idling)
        {
            StartCoroutine("SeekDestination");
            Debug.Log("Turtle seeking dat destination!");
        }

        //If Entity sees wall, stop seeking
        if (Physics.Raycast(transform.position, transform.forward, 10f, _wallMask))
        {
            Debug.Log(name + " Wall layer hit from 10f");
            StopCoroutine("SeekDestination");
            currentState = State.Idling;
        }
        
        
    }
    
    private IEnumerator SeekDestination()
    {
        currentState = State.Seeking;
        
        var destination = GetDestination();
        var direction = destination - this.transform.position;
        //measure direction on flat plane
        direction.y = 0;

        //rotate towards destination at set speed
        transform.rotation =
            Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        
        //Entity pauses before moving for aesthetic purposes
        yield return new WaitForSeconds(2.5f);
        
        while (transform.position != destination)
        {
            transform.rotation =
                Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.Translate(0f,0f, moveSpeed * Time.deltaTime);

            //wait for next frame
            yield return null;
        }

        currentState = State.Idling;
        
        yield return null;
    }
    
    ///@return random vector of x and y relative to Entity position
    private Vector3 GetDestination()
    {
        var turtlePos = transform.position;

        var deltaX = turtlePos.x + Random.Range(-5, 5);
        var deltaZ = turtlePos.z + Random.Range(-5, 5);
       
        return new Vector3(deltaX,turtlePos.y,deltaZ);
    }
}
