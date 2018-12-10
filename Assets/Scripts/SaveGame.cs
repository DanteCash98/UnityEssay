using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGame
{
    public SaveGame(PlayerProfile playerProfile)
    {
        Console.WriteLine("Before serialization the playerProfile contains: ");
        playerProfile.Print();

        //Opens a file and serializes the playerProfile into it in binary format.
        Stream stream = File.Open(DateTime.Now.ToString("en-US").Replace('/','-') + ".xml", FileMode.Create);

        var formatter = new BinaryFormatter();

        formatter.Serialize(stream, playerProfile);
        stream.Close();
   
        //Opens file "data.xml" and deserializes the playerProfile from it.
        stream = File.Open("data.xml", FileMode.Open);
        formatter = new BinaryFormatter();

        //formatter = new BinaryFormatter();

        playerProfile = (PlayerProfile)formatter.Deserialize(stream);
        stream.Close();

        Console.WriteLine("");
        Console.WriteLine("After deserialization the playerProfile contains: ");
        playerProfile.Print();
    }
}
