// Copyright Amjad Banjar 2025, All rights reserved.
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabLevelLoader : MonoBehaviour
{
	public static PrefabLevelLoader Instance;

	public Level CurrentActiveLevel = null;
	private GameObject ActiveLevelPrefab = null;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		Instance = this;
	}

	/// <summary>
	/// This is to be used only with buttons from the main menu
	/// </summary>
	/// <param name="levelToLoad"></param>
	public async void LoadLevel(Level levelToLoad, int indexOfScene = 1)
	{
		if (ActiveLevelPrefab != null)
		{
			Destroy(ActiveLevelPrefab);
		}

		AsyncOperation operation = SceneManager.LoadSceneAsync(indexOfScene, LoadSceneMode.Single);

		while (!operation.isDone)
		{
			if (destroyCancellationToken.IsCancellationRequested)
			{
				return;
			}
			await Task.Yield();
		}

		ActiveLevelPrefab = Instantiate(levelToLoad.LevelPrefab);
		CurrentActiveLevel = levelToLoad;
	}

	public void LoadPrefab(Level levelToLoad)
	{
		if (ActiveLevelPrefab != null)
		{
			Destroy(ActiveLevelPrefab);
		}

		ActiveLevelPrefab = Instantiate(levelToLoad.LevelPrefab);
		CurrentActiveLevel = levelToLoad;
	}
}
