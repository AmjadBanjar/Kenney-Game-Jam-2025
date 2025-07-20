using UnityEngine;
using UnityEngine.UI;

public class LevelCheck : MonoBehaviour
{
	public string LevelName = "Level";
	private Button AttachedButton = null;

	private void OnEnable()
	{
		AttachedButton = GetComponent<Button>();

		if (LevelTracker.Tracker.IsLevelWon(LevelName))
		{
			AttachedButton.interactable = true;
		}
	}
}
