using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTracker : MonoBehaviour
{
	public static LevelTracker Tracker;

	public List<string> LevelNames = new();

	public string LevelToUnlock = "";


	private void Awake()
	{
		if (Tracker != null && Tracker != this)
		{
			Destroy(gameObject);
		}

		Tracker = this;
		DontDestroyOnLoad(gameObject);
	}

	public void UnlockLevel()
	{
		string currnetScene = SceneManager.GetActiveScene().name;
		PlayerPrefs.SetString(currnetScene, "Win");
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
