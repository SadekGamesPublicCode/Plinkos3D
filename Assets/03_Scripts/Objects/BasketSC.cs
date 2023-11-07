using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketSC : MonoBehaviour
{
    [HideInInspector] Rigidbody rb;

    private float moveSpeedApply;
    private float baseMoveSpeed = 0.01f;
    int moveDir = 0;
    private void Start() => SettingBody();
    void Update() => VerticalMove();
    private void ChangeDir(int dir)
    {
        moveDir = dir;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LEdge")
        {
            ChangeDir(1);
        }
        else if (other.gameObject.tag == "REdge")
        {
            ChangeDir(-1);
        }
    }
    private void VerticalMove()
    {
        if (moveDir == 0) { moveDir = -1; } //if center, move to left
        else
        {
            if (moveDir == -1)
            {
                transform.position -= new Vector3(moveSpeedApply, 0, 0);
            }
            else if (moveDir == 1)
            {
                transform.position += new Vector3(moveSpeedApply, 0, 0);
            }
        }
    }
    public void CaculatingMoveSpeed(int curLvl)
    {
        if (curLvl != 1)
        {
            moveSpeedApply = baseMoveSpeed * curLvl;
        }
        else
        {
            moveSpeedApply = baseMoveSpeed;
        }
    }
    void SettingBody()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1;
        rb.useGravity = false;
    }
}
