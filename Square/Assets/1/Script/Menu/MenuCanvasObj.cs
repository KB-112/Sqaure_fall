using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasObj : MonoBehaviour
{
    [Header("MENU  MOVEMENT CONTROL")]
    [SerializeField] private float moveSpeed = 1f; 
 

    [Header("CAMERA CONTROL")]

    public GameObject cameraDown;
    public Vector2 start; 
    public Vector2 end; 
    public float duration = 1f;
    private float startTime;
    public playBtn playbtn;
    float threshold = 0.01f; // adjust this value to change how close the camera needs to be to the end position to be considered "at destination"


   
    public void MainGameCall()
    {
      
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); 
    }
    private void DeactivateObject()
    {
        gameObject.SetActive(false); 
    }




    private void Start()
    {
        startTime = Time.time;
    }

    public void Update()
    {
        if (playbtn.isPlaying)
        {
            CameraDown();
        }
    }
   public  void CameraDown()
    {    
        float t = Mathf.Clamp01((Time.time - startTime) / duration);
        Vector2 newPosition = Vector2.Lerp(start, end, t);
       cameraDown.transform.position = newPosition;
    }
    public void CameraReachDestination()
    {
        if (Vector2.Distance(cameraDown.transform.position, end) < threshold)
        {
            DeactivateObject();
        }
    }
}

