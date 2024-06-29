using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class LoadEnvironmentData
{
    readonly static string SAVE_FILE_PATH = Application.persistentDataPath + "/environment.dt";

    public static EnvironmentData Load()
    {
        if (File.Exists(SAVE_FILE_PATH))
        {
            StreamReader streamReader = new StreamReader(SAVE_FILE_PATH);
            string json = streamReader.ReadToEnd();

            EnvironmentData environmentData = JsonUtility.FromJson<EnvironmentData>(json);

            streamReader.Close();

            return environmentData;
        }
        else
        {
            Debug.LogError("Save file not found in " + SAVE_FILE_PATH);
            return null;
        }
    }
}
