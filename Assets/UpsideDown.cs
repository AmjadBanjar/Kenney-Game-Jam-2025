using UnityEngine;

public class UpsideDown : MonoBehaviour
{
	public Rigidbody Rb = null;
	public float ExplosionForce = 100f;

	private void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.CompareTag("Star"))
		{
			Rb.AddExplosionForce(ExplosionForce, other.transform.position, 1f, 0, ForceMode.Impulse);
			GameManager.Manager.EndGame("<color=red>The Cart got flipped!!", false);
		}
	}
}
