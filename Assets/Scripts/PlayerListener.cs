using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerListener
{
    public enum State
    {
        Grounded, Airborne
    }

    public State CurrentState { get; set; }
    
    
}
