using UnityEngine;

public class SpawnObject1 : MonoBehaviour
{
    
    [SerializeField] Vector3 positionToSpawn;

    public void SpawnObject(GameObject objectToSpawn)
    {
        if (objectToSpawn != null && positionToSpawn != null)
        {
            Instantiate(objectToSpawn, positionToSpawn, Quaternion.identity);
        }
    }

    public void SpawnOnThisPosition(GameObject objectToSpawn)
    {
        if (objectToSpawn)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
