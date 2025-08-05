// Copyright Amjad Banjar 2025, All rights reserved.
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelLoaderButton : Selectable, IPointerClickHandler, ISubmitHandler
{
	[Header("")]
	public bool SwitchScenes = false;
	[ShowIf("SwitchScenes"), AllowNesting]
	public int SceneIndex = 1;
	public Level LevelToLoad = null;
	public void OnPointerClick(PointerEventData eventData)
	{
		if (SwitchScenes)
		{
			PrefabLevelLoader.Instance.LoadLevel(LevelToLoad, SceneIndex);
		}
		else
		{
			PrefabLevelLoader.Instance.LoadPrefab(LevelToLoad);
		}
	}

	public void OnSubmit(BaseEventData eventData)
	{
		throw new System.NotImplementedException();
	}
}
