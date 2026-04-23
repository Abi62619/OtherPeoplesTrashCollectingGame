using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Collections.Generic;

public class UpgradeScript : MonoBehaviour
{
    public List<GameObject> CollectorAi;
    public GameObject CollectorAiPrefab;
    public TMP_Text pointsTxt;


    public int upgrade1Cost;
    public float speedIncrease;

    public int upgrade2Cost;
    public void Btn1Press()
    {
        if (DropOff.points >= upgrade1Cost)
        {
            for (int i = 0; i < CollectorAi.Count; i++)
            {
                CollectorAi[1].GetComponent<NavMeshAgent>().speed += speedIncrease;
            }
            DropOff.points -= upgrade1Cost;
            pointsTxt.text = (DropOff.points).ToString();
        }
    }
    public void Btn2Press()
    {
        if (DropOff.points >= upgrade2Cost)
        {
            GameObject lastSpawn = Instantiate(CollectorAiPrefab, new Vector3(0, 0.74f, 0), Quaternion.identity);
            CollectorAi.Add(lastSpawn);
            DropOff.points -= upgrade1Cost;
            pointsTxt.text = (DropOff.points).ToString();
        }
    }


}
