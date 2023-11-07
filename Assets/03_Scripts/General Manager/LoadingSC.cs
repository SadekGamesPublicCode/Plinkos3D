using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSC : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject spinPlanet;

    [HideInInspector] int targetCountLoad = 0;
    [HideInInspector] int curCountLoad = 0;
    private void Awake()
    {
        RandTargetLoad();
    }
    void Start() => StartCoroutine(LoadingBar());

    void RandTargetLoad() => targetCountLoad = Random.Range(2, 5);
    IEnumerator LoadingBar()
    {
        yield return new WaitForSeconds(1f);
        curCountLoad++;
        if (curCountLoad == targetCountLoad) 
        {
            SceneManager.LoadScene("MenuScene");
        }
        else 
        {
            StartCoroutine(LoadingBar());
        }
    }
}
