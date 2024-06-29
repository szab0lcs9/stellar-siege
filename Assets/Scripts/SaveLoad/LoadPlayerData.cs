using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadPlayerData
{
    readonly static string SAVE_FILE_PATH = Application.persistentDataPath + "/player.dt";

    public static PlayerData Load()
    {
        if (File.Exists(SAVE_FILE_PATH))
        {
            StreamReader streamReader = new StreamReader(SAVE_FILE_PATH);
            string json = streamReader.ReadToEnd();

            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            streamReader.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("Save file not found in " + SAVE_FILE_PATH);
            return null;
        }
    }
}
