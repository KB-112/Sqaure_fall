using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheeler : MonoBehaviour
{
     public bool isClockwise = true; // Set this to true for clockwise movement and false for anti-clockwise
     public float wheelSpeed; // Speed of the wheel movement
     public float stopTime; // Time in seconds before the wheel stops
     public float smoothStopDuration; // Duration of the smooth stop transition
     public GameObject centerPoint; // Reference to an empty GameObject as the center point of rotation

     private bool isMoving = false; // Change this to false, as the wheel should not start moving on Start

     public Button SpinHere;


     private void Start()
     {
         SpinHere.onClick.AddListener(StartSpinning); // Attach the StartSpinning method to the button click event

     }

     private void StartSpinning()
     {
         if (!isMoving)
         {
             transform.rotation = Quaternion.Euler(0f, 0f, 6.8f);
             isMoving = true;
             StartCoroutine(RotateWheel());
             StartCoroutine(StopWheel());
         }
     }

     private IEnumerator RotateWheel()
     {
         while (isMoving)
         {
             float direction = isClockwise ? 1f : -1f;
             transform.RotateAround(centerPoint.transform.position, Vector3.forward, direction * wheelSpeed * Time.deltaTime);
             yield return null;
         }
     }

     private IEnumerator StopWheel()
     {
         yield return new WaitForSeconds(stopTime);
         isMoving = false;

         float elapsedTime = 0f;

         float currentSpeed = wheelSpeed;

         while (elapsedTime < smoothStopDuration)
         {
             float t = elapsedTime / smoothStopDuration;
             currentSpeed = Mathf.Lerp(currentSpeed, 0f, t * t); // Apply ease-out interpolation to the speed
             float direction = isClockwise ? 1f : -1f;
             transform.RotateAround(centerPoint.transform.position, Vector3.forward, direction * currentSpeed * Time.deltaTime);
             elapsedTime += Time.deltaTime;
             yield return null;
         }


     }

    



}