using UnityEngine;

public class Void : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Cart"))
		{
			GameManager.Manager.EndGame("<color=red>Fell into the void!", false);
		}
	}
}
