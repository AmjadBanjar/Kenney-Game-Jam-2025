using UnityEngine;
using UnityEngine.Splines;

public class TrainController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SplineContainer Spline = null;
    [SerializeField] private SplineAnimate Animate = null;
    [SerializeField] private Rigidbody Rb = null;

    [Header("Attributes")]
    [SerializeField] private float TrainSpeed = 0f;
    [SerializeField] private float TrainAcceleration = 0f;
    private float CurrentSpeed = 0f;

    [SerializeField] private bool IsAttachedToSpine = true;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Animate.MaxSpeed += TrainAcceleration * Time.deltaTime;
            
        }
        else if(Animate.MaxSpeed > 0)
        {
            Animate.ElapsedTime -= 2 * Time.deltaTime;
            Animate.MaxSpeed -= TrainAcceleration * Time.deltaTime;
        }
        else if (Animate.MaxSpeed == 0)
        {
            Animate.ElapsedTime = 0;
        }

    }

}
