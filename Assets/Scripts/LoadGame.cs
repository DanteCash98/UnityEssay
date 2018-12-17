using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class LoadGame
{
    public static PlayerProfile LoadPlayer()
    {
        var path = Application.persistentDataPath + DateTime.Now.ToString("en-US").Replace('/','-') + ".cash";

        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            Stream stream = File.Open("data.xml", FileMode.Open);
            var playerProfile = (PlayerProfile) formatter.Deserialize(stream);
            stream.Close();

            return playerProfile;

        }
        else
        {
            Debug.Log("No save files exist in " + path);
            return null;
        }
    }

}
