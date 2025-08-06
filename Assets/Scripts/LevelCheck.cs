using UnityEngine;
using UnityEngine.UI;

public class LevelCheck : MonoBehaviour
{
	public string LevelName = "Level";
	public Level AttachedLevel = null;
	private LevelLoaderButton AttachedButton = null;

	private void OnEnable()
	{
		if (AttachedLevel == null)
		{
			Debug.LogError("Please attach a level to this game object: " + gameObject.name);
			return;
		}

		AttachedButton = GetComponent<LevelLoaderButton>();

		if (AttachedLevel.IsLevelCompleted)
		{
			AttachedButton.interactable = true;
		}
		else
		{
			AttachedButton.interactable = false;
		}
	}
}
