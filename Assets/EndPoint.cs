using UnityEngine;

public class EndPoint : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Cart"))
		{
			if (GameManager.Manager.PointsCollected != GameManager.Manager.MaxPoints)
			{
				GameManager.Manager.EndGame("<color=green> Finished the ride safely!\n<color=red>Still missing some <color=yellow>stars", false);
			}
			else
			{
				GameManager.Manager.EndGame("<color=green> Finished the ride safely!", true);
			}
		}
	}
}
