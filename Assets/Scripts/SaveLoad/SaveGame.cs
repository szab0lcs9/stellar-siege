using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame
{
    public static void Save(Player player, PlayerInventory inventory, Alien alien, GameObject[] celestialBodies, GameObject spaceStation)
    {
		try
		{
			SavePlayerData.Save(player, inventory);
			SaveEnemyData.Save(alien);
			SaveEnvironmentData.Save(celestialBodies, spaceStation);
			Debug.Log("Game saved successfully!");
		}
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
    }
}
