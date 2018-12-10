using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable()]
public class PlayerProfile : MonoBehaviour
{
    private string username;

    private int distanceTraveled;

    public void Print()
    {
        Console.WriteLine(this.ToString());
    }
}
