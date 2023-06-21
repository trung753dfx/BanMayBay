using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnemyCtrler planeEnemy;
    public int scorePlayer;
    public Text scoreTxt;
    public Text levelTxt;

    public int pointExp;

    private void Awake()
    {
        this.RegisterListener(EventID.EnemyDestroy, (sender, param) =>
        {
            addScore();
        });
    }

    private void Update()
    {
        scoreTxt.text = "Score : " + scorePlayer.ToString();
        levelTxt.text = "Level: " + Player.Instance.level.ToString();
    }
    public void addScore()
    {
        scorePlayer += 10;
        Player.Instance.currentExp += 1;
    }
    public void genEnemyTank()
    {
        Instantiate(planeEnemy, gameManager.Instance.transform.position, gameManager.Instance.transform.rotation);
        //Instantiate(tankEnemy, gameManager.Instance.transform.position + Vector3.up, gameManager.Instance.transform.rotation);
    }
}
public class gameManager : SingletonMonoBehaviour<GameManager>
{

}
