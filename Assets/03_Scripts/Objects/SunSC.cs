using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SunSC : MonoBehaviour
{
    [HideInInspector] Rigidbody rb;
    [HideInInspector] Vector3 bodyRot = new Vector3(0, 1, 0);
    [HideInInspector] Vector3 curPos;
    [SerializeField] List<GameObject> planetList = new List<GameObject>();

    private float moveSpeedApply;
    private float baseMoveSpeed = 0.01f;

    int moveDir = 0;
    void Start()
    {
        SettingBody();
    }

    void SettingBody()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1;
        rb.useGravity = false;
    }
    void Update()
    {
        SelfRotate();
        VerticalMove();
    }
    public void CaculatingMoveSpeed(int curLvl) 
    {
        if(curLvl != 1)
        {
            moveSpeedApply = baseMoveSpeed  * curLvl;
        }
        else
        {
            moveSpeedApply = baseMoveSpeed;
        }
    }
    private void SelfRotate() {rb.transform.Rotate(bodyRot);}
    private void VerticalMove()
    {
        if (moveDir == 0) { moveDir = -1; } //if center, move to left
        else
        {
            if (moveDir == -1)
            {
                transform.position -= new Vector3(moveSpeedApply, 0, 0);
                curPos = transform.position;
            }
            else if (moveDir == 1)
            {
                transform.position += new Vector3(moveSpeedApply, 0, 0);
                curPos = transform.position;
            }
        }
    }
    public void SpawnPlanet()
    {
        int randPla = 0;
        randPla = Random.Range(1, 12);
        Instantiate(planetList[randPla], new Vector3(curPos.x, curPos.y -1, curPos.z), Quaternion.identity);
    }
    private void ChangeDir(int dir)
    {
        moveDir = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LEdge")
        {
            ChangeDir(1);
        }else if(other.gameObject.tag == "REdge")
        {
            ChangeDir(-1);
        }
    }
}
