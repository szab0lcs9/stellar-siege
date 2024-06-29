using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavePlayerData
{
    readonly static string SAVE_FILE_PATH = Application.persistentDataPath + "/player.dt";

    public static void Save(Player player, PlayerInventory inventory)
    {
        if (player != null && inventory != null)
        {
            PlayerData playerData = new PlayerData(player, inventory);

            string json = JsonUtility.ToJson(playerData);

            StreamWriter streamWriter = new StreamWriter(SAVE_FILE_PATH, false);
            streamWriter.Write(json);
            streamWriter.Close(); 
        }
    }
}
