using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetSC : MonoBehaviour
{
    public bool isSpawnByLoad;
    [HideInInspector] Vector3 bodyRot = new Vector3(0,1,0);
    [HideInInspector] GameplaySC manager;
    private int aliveCount;
    private void Start()
    {
        aliveCount = 0;
        if(isSpawnByLoad == false)
        {
            manager = GameObject.Find("GamePlayManager").GetComponent<GameplaySC>();
            StartCoroutine(coutDestroy());
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void Update()
    {
        SelfRotate();
    }
    private void SelfRotate()
    {
        transform.Rotate(bodyRot);
    }
    //private void OnCollisionEnter(Collision other)
    //{
    //    if(other.gameObject.tag == "Basket")
    //    {
    //        manager.IncreaseScore();
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basket")
        {
            manager.IncreaseScore();
            Destroy(gameObject);
        }
    }

    private IEnumerator coutDestroy()
    {
        yield return new WaitForSeconds(5);
        aliveCount++;
        print(aliveCount);
        if (aliveCount == 4)
        {
            manager.CaculatingMissDrop();
        }
        Destroy(gameObject);
    }
}
