using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Manager;
	public enum GameStates
	{
		Started,
		InProgress,
		Ended
	}
	public GameStates State = GameStates.Started;

	public List<ThrillPoint> PointsToCollect = new();

	public GameObject EndWindow = null;
	public GameObject EndPoint = null;

	public GameObject WinPanel = null;
	public GameObject LosePanel = null;
	public Button NextLevelButton = null;
	public TextMeshProUGUI EndResultTMP = null;
	public TextMeshProUGUI PointsTMP = null;

	[HideInInspector] public int PointsCollected = 0;

	[HideInInspector] public int MaxPoints = 0;

	private void Awake()
	{
		if (Manager != this && Manager != null)
		{
			Destroy(gameObject);
		}
		Manager = this;
	}
	private void Start()
	{
		ThrillPoint.Collected += PointCollected;
		PointsToCollect = FindObjectsByType<ThrillPoint>(FindObjectsSortMode.None).ToList<ThrillPoint>();
	}

	private void Update()
	{
		GameLogic();
	}

	public void GameLogic()
	{
		switch (State)
		{
			case GameStates.Started:
				MaxPoints = PointsToCollect.Count;
				PointsTMP.text = $"{PointsCollected} / {MaxPoints}";
				State = GameStates.InProgress;
				break;
			case GameStates.InProgress:
				if (PointsToCollect.Count <= 0)
				{
					EndPoint.SetActive(true);
				}
				break;
			case GameStates.Ended:
				break;
			default:
				break;
		}
	}

	public void PointCollected(ThrillPoint point)
	{
		PointsToCollect.Remove(point);
		PointsCollected++;
		PointsTMP.text = $"{PointsCollected} / {MaxPoints}";
	}

	public void EndGame(string message, bool win)
	{
		if (EndWindow.activeInHierarchy)
		{
			return;
		}

		if (win)
		{
			//LevelTracker.Tracker.UnlockLevel();
			PrefabLevelLoader.Instance.CurrentActiveLevel.UnlockLevel();
			WinPanel.SetActive(true);
			NextLevelButton.interactable = true;
		}
		else
		{
			NextLevelButton.interactable = false;
			LosePanel.SetActive(true);
		}

		EndResultTMP.text = message;
		EndWindow.SetActive(true);
		State = GameStates.Ended;
	}

}
