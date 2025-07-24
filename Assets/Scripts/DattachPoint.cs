using UnityEngine;

public class DattachPoint : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.CompareTag("Cart"))
		{
			other.GetComponent<SplinePhysicsAnimate>().ToggleAttachment();
		}
	}
}
