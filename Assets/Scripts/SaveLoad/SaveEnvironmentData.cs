using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveEnvironmentData
{
    readonly static string SAVE_FILE_PATH = Application.persistentDataPath + "/environment.dt";

    public static void Save(GameObject[] celestialBodies, GameObject spaceStation)
    {
        if (celestialBodies != null && spaceStation != null)
        {
            EnvironmentData environmentData = new EnvironmentData(celestialBodies, spaceStation);

            string json = JsonUtility.ToJson(environmentData);

            StreamWriter streamWriter = new StreamWriter(SAVE_FILE_PATH, false);
            streamWriter.Write(json);
            streamWriter.Close();
        }
    }
}
