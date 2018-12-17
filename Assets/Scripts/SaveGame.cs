using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveGame
{
    public static void SavePlayer(PlayerProfile playerProfile)
    {
        var formatter = new BinaryFormatter();
        String path = Application.persistentDataPath + DateTime.Now.ToString("en-US").Replace('/','-') + ".cash";
        Stream stream = File.Open(path, FileMode.Create);

        formatter.Serialize(stream, playerProfile);
        stream.Close();
    }
}
