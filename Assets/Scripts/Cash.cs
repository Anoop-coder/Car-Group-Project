using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    [SerializeField] int currentMoney = 0;
    [SerializeField] int cashGet = 10000;
    [SerializeField] int carHitSubtract = 100;
    [SerializeField] int carSecondPlace = 2000;

    public GameObject[] npcCar;
    public List<GameObject> npcCarList;


    private void Awake()
    {
        npcCar = GameObject.FindGameObjectsWithTag("Npc");
        List<GameObject> npcCarList = new List<GameObject> ();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SubtractMoney")
        {
            cashGet = cashGet - carHitSubtract;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            currentMoney = currentMoney + cashGet;
        }
    }
}
