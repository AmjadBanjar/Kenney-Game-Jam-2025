using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-10)]
public class LevelTracker : MonoBehaviour
{
	public static LevelTracker Tracker;

	public List<string> LevelNames = new();

	public string LevelToUnlock = "";


	private void Awake()
	{
		Tracker = this;
	}

	[Obsolete]
	public void UnlockLevel()
	{
		string currnetScene = SceneManager.GetActiveScene().name;
		PlayerPrefs.SetString(currnetScene, "Win");
	}

	public void UnlockLevelPrefab(string levelName)
	{

	}

	[Button]
	public void UnlockLevelDebug()
	{
		PlayerPrefs.SetString(LevelToUnlock, "Win");
	}
	public bool IsLevelWon(string name)
	{
		string savedLevel = PlayerPrefs.GetString(name, "");

		if (savedLevel == "Win")
		{
			return true;
		}
		else
		{
			return false;
		}

	}
	[Button]
	public void ClearPlayerPrefs()
	{
		foreach (string scene in LevelNames)
		{
			PlayerPrefs.SetString(scene, "");
		}
	}
}
