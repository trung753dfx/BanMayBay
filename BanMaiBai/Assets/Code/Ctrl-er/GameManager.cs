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

    //public int pointExp;
    private float time=0;
    public Transform[] _gate;
    private void Awake()
    {
        //this.RegisterListener(EventID.EnemyDestroy, (sender, param) =>
        //{
        //    addScore();
        //});
    }

    private void Update()
    {
        //scoreTxt.text = "Score : " + scorePlayer.ToString();
        //levelTxt.text = "Level: " + Player.Instance.level.ToString();
        time++;
        if (time % 1000 == 0)
        {
            genEnemyTank();
        }
    }
    //public void addScore()
    //{
    //    scorePlayer += 10;
    //    Player.Instance.currentExp += 1;
    //}
    public void genEnemyTank()
    {
        var gate = Random.Range(0, _gate.Length - 2);
        Instantiate(planeEnemy.gameObject, _gate[gate].position, _gate[gate].rotation);
        //Instantiate(tankEnemy, gameManager.Instance.transform.position + Vector3.up, gameManager.Instance.transform.rotation);
    }
}
public class gameManager : SingletonMonoBehaviour<GameManager>
{

}
