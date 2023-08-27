using UnityEngine;

public class SquareFallObstacle : MonoBehaviour
{
    public float speed;

    
    public void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
