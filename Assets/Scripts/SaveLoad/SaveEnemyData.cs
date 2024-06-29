using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveEnemyData
{
    readonly static string SAVE_FILE_PATH = Application.persistentDataPath + "/enemy.dt";

    public static void Save(Alien alien)
    {
        if (alien != null)
        {
            EnemyData enemyData = new EnemyData(alien);

            string json = JsonUtility.ToJson(enemyData);

            StreamWriter streamWriter = new StreamWriter(SAVE_FILE_PATH, false);
            streamWriter.Write(json);
            streamWriter.Close(); 
        }
    }
}
