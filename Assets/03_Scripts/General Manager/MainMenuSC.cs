using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSC : MonoBehaviour
{
    [SerializeField] GameObject creditPnl;
    [SerializeField] GameObject leaderPnl;
    [SerializeField] GameObject inforPnl;
    [SerializeField] GameObject marketPnl;
    [SerializeField] GameObject optionPnl;
    [SerializeField] GameObject groupSphere;
    [SerializeField] StudioTipsSC stutips;

    [SerializeField] Text tipsText;

    [SerializeField] Vector3 rotBody = new Vector3(0,0,0.25f);

    public bool isPanelActive;
    private void Start()
    {
        StartCoroutine(WaitToShowTips());
    }
    private void Update()
    {
        SelfRotMenu();
    }

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
    private void SelfRotMenu() 
    {
        groupSphere.transform.Rotate(rotBody);
    } 
    private IEnumerator WaitToShowTips()
    {
        yield return new WaitForSeconds(5);
        ShowStudioTips();
        StartCoroutine(WaitToShowTips());
    }
    private void ShowStudioTips()
    {
        int rand = Random.Range(0, 10);
    }
}
