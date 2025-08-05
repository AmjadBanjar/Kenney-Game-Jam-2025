// Copyright Amjad Banjar 2025, All rights reserved.
using UnityEngine;

public class Level : ScriptableObject
{
	public string LevelName = "Level";
	public GameObject LevelPrefab = null;
	public bool IsLevelComplete = false;

	public void Awake()
	{
		
	}
}
