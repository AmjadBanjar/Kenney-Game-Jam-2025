using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplinePhysicsAnimate : MonoBehaviour
{
	[SerializeField] private SplineContainer SplineCont = null;

	private Spline Spline = null;

	private Rigidbody Rb = null;


	[SerializeField] private bool TurnWithTrack = false;
	[SerializeField] private bool OnTrack = true;

	[SerializeField] private float DistanceFromPath = 0.15f;

	[SerializeField] private float Speed = 10f;

	[SerializeField] private float GravityPull = 10f;

	private Vector3 StartingPosition = Vector3.zero;

	[Button]
	public void Restart() => transform.position = StartingPosition; 

	private void Awake()
	{
		StartingPosition = transform.position;
		Spline = SplineCont.Spline;
		Rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Rb.AddForce(Vector3.down * GravityPull);

		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
		{
			Rb.AddForce(-transform.forward * Speed);
		}
		if (TurnWithTrack)
		{
			var native = new NativeSpline(Spline);

			float distance = SplineUtility.GetNearestPoint(native, transform.position, out float3 nearest, out float t);

			//nearest += (float3)SplineCont.transform.position;
			//transform.position = nearest;
			//transform.position += SplineCont.transform.position;

			Vector3 forward = Vector3.Normalize(native.EvaluateTangent(t));
			Vector3 up = native.EvaluateUpVector(t);

			var remappedForward = new Vector3(0, 0, 1);
			var remappedUp = new Vector3(0, 1, 0);
			var axisRemapRotation = Quaternion.Inverse(Quaternion.LookRotation(remappedForward, remappedUp));

			if (OnTrack)
			{
				transform.rotation = Quaternion.LookRotation(-forward, up) * axisRemapRotation;
			}
			//Rb.linearVelocity = Rb.linearVelocity.magnitude * -transform.forward;
		}


	}

	public void ToggleAttachment()
	{
		OnTrack = !OnTrack;
		if (OnTrack)
		{
			var native = new NativeSpline(Spline);
			float distance = SplineUtility.GetNearestPoint(native, transform.position, out float3 nearest, out float t);
			transform.position = nearest;
			Rb.useGravity = false;
		}
		else
		{
			Rb.useGravity = true;
		}
	}
}
