using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameplaySC : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] SunSC sun;
    [SerializeField] Transform parent;
    [SerializeField] GameObject stakes;
    [SerializeField] BasketSC basket;
    [SerializeField] PlayerSettingSC soundHandler;
    [SerializeField] GameObject loosePanel;

    [Header("UIs")]
    [SerializeField] Text curLvlTxt;
    [SerializeField] Text curScoreTxt;
    [SerializeField] Text targetScoreTxt;

    [Header("Variables")]
    private int baseLvl = 1;

    private int curLvl;
    private int curScore;
    private int targetScore;
    private int stakeCount;

    private int comboCount;
    public int missCount;

    #region Managing Section
    void Start() => SettingStart();
    public void OnSpawnBall() 
    {
        sun.SpawnPlanet();
        soundHandler.PlayDropSound();
    }
    private void SettingStart()
    {
        comboCount = 0; //Reset every reach 5
        curScore = 0; //Reset every start of game or level increase
        curLvl = baseLvl; //Change this after setting PlayerPrefs
        soundHandler = GameObject.Find("PlayerSetting").GetComponent<PlayerSettingSC>();

        GenerateLevel();
        ResetUIs();
    }
    void ResetUIs()
    {
        //Expect: Refresh Level text, Target score text
        //Handle all change of UI sections
        UpdateLvlText(curLvl);
        UpdateCurrentScoreText(curScore);
        UpdateTargetScoreText(targetScore);
        ShowLoosePanel(false);
    }
    void GenerateLevel()
    {
        //Expect: Refresh next level
        //Handle all change of gameplay by each level
        CaculatingTargetScore(curLvl);
        Decidegameplay(curLvl);
    }
    #endregion

    #region Handle Gameplay
    private void CaculatingTargetScore(int curLvl)
    {
        if(curLvl != baseLvl) { targetScore += (curLvl * 10) + curLvl; }
        else { targetScore = 10; }
    }
    public void SettingStakeMap(int lvl)
    {
        if(lvl != baseLvl) { stakeCount = lvl++; }
        else { stakeCount = 1; }
        for (int i = 0; i <= stakeCount - 1; i++)
        {
            Instantiate(stakes, new Vector3(Random.Range(-2.75f, 2.75f), Random.Range(-3, 3), 0), Quaternion.identity, parent.transform);
        }
    }
    private void Decidegameplay(int lvl)
    {
        if (lvl == baseLvl) 
        {
            sun.CaculatingMoveSpeed(lvl);
            SettingStakeMap(lvl);
        } 
        else 
        {
            int randGameplay = Random.Range(0, 2);
            switch (randGameplay)
            {
                case 0: //Increase Sun speed
                    sun.CaculatingMoveSpeed(lvl);
                    break;
                case 1: //Add stakes
                    SettingStakeMap(lvl);
                    break;
                case 2: //Increase baseket speed
                    if(curLvl < 3)
                    {
                        basket.CaculatingMoveSpeed(0);
                    }
                    else
                    {
                        basket.CaculatingMoveSpeed(curLvl);
                    }
                    break;
            }
        }  
    }
    public void CaculatingMissDrop()
    {
        missCount++;
        if(missCount >= 10)
        {
            ShowLoosePanel(true);
            IEnumerator BackMenu()
            {
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("MenuScene");
                StartCoroutine(BackMenu());
            }
        }
    }
    #endregion

    #region Handel UIs
    private void ShowLoosePanel(bool show) => loosePanel.gameObject.SetActive(show);
    private void UpdateLvlText(int lvl) => curLvlTxt.text = lvl.ToString(); //Update level text
    private void UpdateCurrentScoreText(int currentScore) => curScoreTxt.text = currentScore.ToString(); //Update current score text
    private void UpdateTargetScoreText(int target) => targetScoreTxt.text = target.ToString(); //Update target score text
    #endregion

    #region Callback function
    public void IncreaseScore()
    {
        curScore++;
        if (curScore == targetScore)
        {
            curLvl++;
            GenerateLevel();
        }
        ResetUIs();
    }
    #endregion
}
