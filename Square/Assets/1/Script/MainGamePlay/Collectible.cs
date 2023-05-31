using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    [Header("DEFAULT VALUES")]

    [SerializeField] private int objectCount;
   

    [Header("USER INPUTS")]
    public float interval = 1f;
    private float destroyInstant;
    public List<GameObject> Collectibles;
   


    void Start()
    {

        StartCoroutine(collectibleSpawning());
    }

    private IEnumerator DestroyCollectibles()
    {
        yield return new WaitForSeconds(8f);
       // Destroy(spawnedObject, destroyInstant);
    }



    private IEnumerator collectibleSpawning()
    {
        while (true)
        {
            if ((objectCount % 5) == 0 && objectCount % 10 != 0 && objectCount != 0)
            {
                int a, b, c;
                a = objectCount;
                b = objectCount + 5;
                c = Random.Range(a, b);

                if (a < c && c < b || a == c || b == c)
                {
                    Debug.Log(c);
                 

                   
                    StartCoroutine(DestroyCollectibles());


                }

            }
            objectCount++;
            yield return new WaitForSeconds(interval);
        }

    }

}
//  [Header("REFERENCE SCRIPTS")]
//public TargetSb targetSb;


/* Check for overlapping objects
int layerMask = 1 << LayerMask.NameToLayer("Obstacles");
Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPosition, objectToSpawn[0].GetComponent<Renderer>().bounds.size, 0);
  Collider2D _collider = Physics2D.OverlapArea(targetSb.rightCorner, targetSb.leftCorner);
if (colliders.Length == 0)
{


}
*/


/*    Vector2 spawnPosition = new Vector3(Random.Range(

                 Mathf.Min(spawnCorner1.x, spawnCorner2.x, spawnCorner3.x, spawnCorner4.x),
                   Mathf.Max(spawnCorner1.x, spawnCorner2.x, spawnCorner3.x, spawnCorner4.x)),

                   Random.Range(
                   Mathf.Min(spawnCorner1.y, spawnCorner2.y, spawnCorner3.y, spawnCorner4.y),
                   Mathf.Max(spawnCorner1.y, spawnCorner2.y, spawnCorner3.y, spawnCorner4.y)));
                spawnedObject = Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity);  

  [Header("SPAWN COORDINATES")]
    public Vector2 spawnCorner1; // First corner of the spawn area
    public Vector2 spawnCorner2; // Second corner of the spawn area
    public Vector2 spawnCorner3; // Third corner of the spawn area
    public Vector2 spawnCorner4; // Fourth corner of the spawn area
 
 */

