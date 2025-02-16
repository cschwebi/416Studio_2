using UnityEngine;

public class BallController : MonoBehaviour
{
private bool isBallLaunched;
[SerializeField] private Transform ballAnchor;
[SerializeField] private Transform launchIndicator;
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
        ResetBall();
    }

    private void LaunchBall()
    {
        if(isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
        
    }

    public void ResetBall()
    {
    isBallLaunched = false;

    // We are setting the ball to be a Kinematic Body
    ballRB.isKinematic = true;

    launchIndicator.gameObject.SetActive(true);
    transform.parent = ballAnchor;
    transform.localPosition = Vector3.zero;
    }

}
