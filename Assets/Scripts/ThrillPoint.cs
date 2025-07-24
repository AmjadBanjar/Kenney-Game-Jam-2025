using System;
using UnityEngine;

public class ThrillPoint : MonoBehaviour
{
    public static event Action<ThrillPoint> Collected;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Cart"))
		{
			Collected?.Invoke(this);
			Destroy(gameObject);
		}
	}
}
