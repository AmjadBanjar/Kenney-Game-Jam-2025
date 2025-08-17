// Copyright Amjad Banjar 2025, All rights reserved.
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "PrefabLevelLoader/Level")]
public class Level : ScriptableObject
{
	// If a level is locked the int value is going to be -1
	// If unlocked Value is going to be 0 or more
	public string LevelName = "Level";
	public GameObject LevelPrefab = null;
	public bool IsLevelCompleted
	{
		get
		{
			if (PlayerPrefs.GetInt(LevelName) >= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private set { }
	}

	[Button]
	public void LockLevel()
	{
		PlayerPrefs.SetInt(LevelName, -1);

		if (PlayerPrefs.GetInt(LevelName) < 0)
		{
			Debug.Log("Level Locked");
		}
		else
		{
			Debug.Log("Locking Failed");
		}
	}
	[Button]
	public void UnlockLevel()
	{
		PlayerPrefs.SetInt(LevelName, 0);

		if (PlayerPrefs.GetInt(LevelName) >= 0)
		{
			Debug.Log("Level Unlocked");
		}
		else
		{
			Debug.Log("Unlocking Failed");
		}
	}
}
