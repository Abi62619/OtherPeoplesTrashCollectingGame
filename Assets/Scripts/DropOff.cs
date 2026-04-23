using UnityEngine;

public class DropOff : MonoBehaviour
{
    public GameObject DropOffPrefab;
    public Transform DropOffLocation;

    // Instantiate the prefab when any collider enters this object's trigger,
    // then destroy the instantiated object after 2 seconds.
    private void OnTriggerEnter(Collider other)
    {
        if (DropOffPrefab == null)
            return;

        Vector3 spawnPos = DropOffLocation != null ? DropOffLocation.position : transform.position;
        GameObject spawned = Instantiate(DropOffPrefab, spawnPos, Quaternion.identity);
        Destroy(spawned, 2f); // remove the spawned object after 2 seconds
    }
}
