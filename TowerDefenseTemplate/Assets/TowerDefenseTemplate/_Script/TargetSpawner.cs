using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetObj;
    public Transform spawnPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(targetObj, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
