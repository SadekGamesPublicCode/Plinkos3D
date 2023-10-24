using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameplaySC : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] SunSC sun;
    [SerializeField] Transform parent;
    [SerializeField] GameObject stakes;

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

    #region Managing Section
    void Start() => SettingStart();
    public void OnSpawnBall() => sun.SpawnPlanet();
    private void SettingStart()
    {
        curScore = 0; //Reset every start of game or level increase
        curLvl = baseLvl; //Change this after setting PlayerPrefs

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
                    print("increase basket speed");
                    break;
            }
        }  
    }
    #endregion

    #region Handel UIs
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
