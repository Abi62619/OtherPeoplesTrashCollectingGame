using UnityEngine;
using UnityEngine.AI;

public class AICollection : MonoBehaviour
{
    public NavMeshAgent Robot;
    public Transform DropOff;
    public GameObject DropOffObject;

    public float collectRadius = 0.5f; // distance considered "collected"
    public float dropOffRadius = 1f;   // distance considered "at drop-off"

    private bool goingToDropOff;

    private void Awake()
    {
        DropOffObject = GameObject.FindGameObjectWithTag("Finish");
        DropOff = DropOffObject.transform;
    }
    void Update()
    {
        if (Robot == null)
            return;

        // If currently heading to drop-off, keep going there and resume collecting when arrived
        if (goingToDropOff)
        {
            if (DropOff == null)
            {
                goingToDropOff = false;
                return;
            }

            Robot.SetDestination(DropOff.position);

            // arrival check using NavMeshAgent remainingDistance
            if (!Robot.pathPending && Robot.remainingDistance <= dropOffRadius)
                goingToDropOff = false; // arrived -> resume collecting

            return;
        }

        // Otherwise find nearest collectable and go to it
        var collectables = GameObject.FindGameObjectsWithTag("Collectable");
        if (collectables == null || collectables.Length == 0)
            return;

        GameObject nearest = null;
        float minSqr = float.MaxValue;
        Vector3 pos = transform.position;

        foreach (var obj in collectables)
        {
            float sqr = (obj.transform.position - pos).sqrMagnitude;
            if (sqr < minSqr)
            {
                minSqr = sqr;
                nearest = obj;
            }
        }

        if (nearest != null)
            Robot.SetDestination(nearest.transform.position);
    }

    // When this AI touches a Collectable, destroy it, go to DropOff, then resume collecting after arrival.
    // Make collectable colliders "Is Trigger = true" so NavMeshAgent movement triggers this reliably.
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Collectable"))
            return;

        Destroy(other.gameObject);     // pick up the collectable
        goingToDropOff = true;         // switch to drop-off behavior

        if (DropOff != null && Robot != null)
            Robot.SetDestination(DropOff.position);
    }
}
