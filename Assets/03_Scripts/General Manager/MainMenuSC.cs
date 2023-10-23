using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSC : MonoBehaviour
{
    [SerializeField] GameObject creditPnl;
    [SerializeField] GameObject leaderPnl;
    [SerializeField] GameObject inforPnl;
    [SerializeField] GameObject marketPnl;
    [SerializeField] GameObject optionPnl;
    [SerializeField] GameObject groupSphere;

    [SerializeField] Vector3 rotBody = new Vector3(1,0,0);

    public bool isPanelActive;
    public void OnShowPanel(int pnlOder)
    {
        switch (pnlOder)
        {
            case 0:
                SceneManager.LoadScene("PlayScene");
                break;
            case 1:
                creditPnl.SetActive(true);
                isPanelActive = true;
                break;
            case 2:
                inforPnl.SetActive(true);
                isPanelActive = true;
                break;
            case 3:
                marketPnl.SetActive(true);
                isPanelActive = true;
                break;
            case 4:
                leaderPnl.SetActive(true);
                isPanelActive = true;
                break;
            case 5:
                optionPnl.SetActive(true);
                isPanelActive = true;
                break;
        }
    }
    private void Update()
    {
        //SelfRot();
    }

    private void SelfRot() 
    {
        groupSphere.transform.Rotate(rotBody);
        print("in rotate");
    } 
}
