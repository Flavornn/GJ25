using UnityEngine;

public class ButtonHatchController : MonoBehaviour
{
    // Assign these in the Unity Inspector
    [SerializeField] private GameObject hatch; // The object to move
    [SerializeField] private float moveDistance = 5f; // Distance to move the hatch
    [SerializeField] private float moveAngle = 45f; // Angle to move the hatch, in degrees
    [SerializeField] private float moveSpeed = 2f; // Speed of the hatch movement

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        if (hatch != null)
        {
            initialPosition = hatch.transform.position;
            targetPosition = CalculateTargetPosition();
        }
    }

    void OnMouseDown()
    {
        if (hatch != null && !isMoving)
        {
            isMoving = true;
            targetPosition = CalculateTargetPosition();
            StartCoroutine(MoveHatch());
        }
    }

    private Vector3 CalculateTargetPosition()
    {
        // Convert the angle to a direction vector
        float angleInRadians = moveAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0) * moveDistance;
        return initialPosition + offset;
    }

    private System.Collections.IEnumerator MoveHatch()
    {
        float elapsedTime = 0;
        Vector3 startPosition = hatch.transform.position;

        while (elapsedTime < moveDistance / moveSpeed)
        {
            elapsedTime += Time.deltaTime;
            hatch.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / (moveDistance / moveSpeed));
            yield return null;
        }

        hatch.transform.position = targetPosition; // Ensure it reaches the exact position
        isMoving = false;
    }

    // Optional: Reset hatch to its initial position
    public void ResetHatch()
    {
        if (!isMoving)
        {
            hatch.transform.position = initialPosition;
        }
    }
}
