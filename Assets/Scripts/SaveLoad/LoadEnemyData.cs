using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class LoadEnemyData
{
    readonly static string SAVE_FILE_PATH = Application.persistentDataPath + "/enemy.dt";

    public static EnemyData Load()
    {
        if (File.Exists(SAVE_FILE_PATH))
        {
            StreamReader streamReader = new StreamReader(SAVE_FILE_PATH);
            string json = streamReader.ReadToEnd();

            EnemyData enemyData = JsonUtility.FromJson<EnemyData>(json);

            streamReader.Close();

            return enemyData;
        }
        else
        {
            Debug.LogError("Save file not found in " + SAVE_FILE_PATH);
            return null;
        }
    }
}
