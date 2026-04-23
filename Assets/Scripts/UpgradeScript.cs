using UnityEngine;
using UnityEngine.AI;

public class UpgradeScript : MonoBehaviour
{
    public GameObject CollectorAi;

    public float speedIncrease;
    public void Btn1Press()
    {
        CollectorAi.GetComponent<NavMeshAgent>().speed += speedIncrease;
    }


}
