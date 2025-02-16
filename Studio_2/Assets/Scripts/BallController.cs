using UnityEngine;

public class BallController : MonoBehaviour
{
private bool isBallLaunched;
[SerializeField] private Transform ballAnchor;
[SerializeField] private float force = 1f;
[SerializeField] private InputManager inputManager;
private Rigidbody ballRB;
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

// Add a listener to the OnSpacePressed event.
// When the space key is pressed the
// LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

    private void LaunchBall()
    {
        if(isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        
    }
}
