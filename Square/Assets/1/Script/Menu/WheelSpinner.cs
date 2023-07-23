using UnityEngine;

[System.Serializable]
public struct StopPosition
{
    public float position;
    public float stopDuration;
    public int probability;
}

public class WheelSpinner : MonoBehaviour
{
    [Header("Spin Settings")]
    public float minSpinSpeed = 100f;
    public float maxSpinSpeed = 500f;
    public AnimationCurve spinSpeedCurve; // To control the spin speed over time
    public float spinDuration = 5f; // How long the wheel should spin before slowing down
    public StopPosition[] stopPositions; // Array of stop positions and their corresponding stop durations

    private bool isSpinning = false;
    private float currentSpinSpeed;
    private float spinTimeElapsed;
    private float stopTimeElapsed;
    private float initialRotationZ;
    private Quaternion targetRotation;
    private int totalProbability; // Total probability for stop durations at a given position

    private void Start()
    {
        initialRotationZ = transform.rotation.eulerAngles.z;

        // Calculate the total probability for each position
        foreach (StopPosition stopPos in stopPositions)
        {
            totalProbability += stopPos.probability;
        }
    }

    private void Update()
    {
        if (isSpinning)
        {
            spinTimeElapsed += Time.deltaTime;

            if (spinTimeElapsed < spinDuration)
            {
                // Calculate current spin speed using the animation curve
                float t = spinTimeElapsed / spinDuration;
                currentSpinSpeed = Mathf.Lerp(minSpinSpeed, maxSpinSpeed, spinSpeedCurve.Evaluate(t));

                // Rotate the wheel around the Z-axis
                transform.Rotate(Vector3.forward, currentSpinSpeed * Time.deltaTime);
            }
            else
            {
                // Slow down the wheel gradually when reaching each stop position
                stopTimeElapsed += Time.deltaTime;
                float targetStopDuration = stopPositions[0].stopDuration;

                for (int i = 0; i < stopPositions.Length; i++)
                {
                    if (transform.rotation.eulerAngles.z > stopPositions[i].position)
                    {
                        targetStopDuration = stopPositions[i].stopDuration;
                    }
                }

                if (stopTimeElapsed < targetStopDuration)
                {
                    float t = stopTimeElapsed / targetStopDuration;
                    currentSpinSpeed = Mathf.Lerp(maxSpinSpeed, minSpinSpeed, t);
                    transform.Rotate(Vector3.back, currentSpinSpeed * Time.deltaTime);
                }
                else
                {
                    // Stop spinning when the stop duration is reached
                    isSpinning = false;
                }
            }
        }
    }

    // Call this method to start spinning the wheel
    public void SpinWheel()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            spinTimeElapsed = 0f;
            stopTimeElapsed = 0f;

            // Reset spinDuration to its default value
            spinDuration = 5f;

            // Randomly select a stop duration based on probabilities
            int randomValue = Random.Range(0, totalProbability);
           
            foreach (StopPosition stopPos in stopPositions)
            {
                if (randomValue < stopPos.probability)
                {
                    Debug.Log("randomValue -->" + randomValue);
                    // Set the selected stop duration for this spin
                    spinDuration = stopPos.stopDuration;
                    break;
                }

                randomValue -= stopPos.probability; // Reduce the random value by the current probability
            }
        }
    }


}
