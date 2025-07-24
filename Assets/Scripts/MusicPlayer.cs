using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer Player;
	private void Awake()
	{
		if (Player != null)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		Player = this;
	}
}
