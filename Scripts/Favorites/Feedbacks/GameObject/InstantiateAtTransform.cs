using UnityEngine;

public class InstantiateAtTransform : MonoBehaviour
{

    [SerializeField] Transform transformToSpawnAt;

    //Spawn object on transformToSpawnAt transform's position and **object's self rotation**
    public void SpawnOnTransformsPosition(GameObject objectToSpawn)
    {
        if (objectToSpawn != null && transformToSpawnAt != null)
        {
            Instantiate(objectToSpawn, transformToSpawnAt.position, Quaternion.identity);
        }
    }

    //Spawn object on transformToSpawnAt transform's position and rotation
    public void SpawnOnTransform(GameObject objectToSpawn) 
    {
        if (objectToSpawn != null && transformToSpawnAt != null)
        {
            Instantiate(objectToSpawn, transformToSpawnAt.position, transformToSpawnAt.rotation);
        }
    }

    //Spawn object on the object's transform that this script is attached to
    public void SpawnOnSelfPosition(GameObject objectToSpawn)
    {
        if (objectToSpawn)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
