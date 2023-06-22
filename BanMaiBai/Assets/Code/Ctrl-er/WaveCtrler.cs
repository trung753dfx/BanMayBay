using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCtrler : MonoBehaviour
{
    public List<EnemyCtrler> _tankEnemy = new List<EnemyCtrler>();
    public EnemyCtrler enemySample;
    [SerializeField] private Transform[] _gate;
    private int _enemyInWave = 0;
    //public GameObject heal;
    //public GameObject boostDamage;
    float timer;

    // Start is called before the first frame update
    private void Start()
    {
        this.RegisterListener(EventID.EnemyDestroy, (sender, param) =>
        {
            CalculateWave();
        });
        _tankEnemy.Add(enemySample);
        CreateWave();
    }

    public void CreateWave()
    {
        for (int i = 0; i < _tankEnemy.Count; i++)
        {
            var enemy = _tankEnemy[i];
            var gate = Random.Range(0, _gate.Length - 1);
            //Instantiate(enemy, _gate[gate].position, _gate[gate].rotation);
            Instantiate(enemySample.gameObject, _gate[gate].position, _gate[gate].rotation);
        }
    }


    public void CalculateWave()
    {

        _enemyInWave += 1;
        if (_enemyInWave == _tankEnemy.Count)
        {
            if (_tankEnemy.Count <= 10)
            {
                _tankEnemy.Add(enemySample);

                CreateWave();
                var gateOdd = Random.Range(1, _gate.Length);
                var gateEven = Random.Range(0, _gate.Length / 2);
                //Instantiate(heal, _gate[gateOdd].position, _gate[gateOdd].rotation);
                //Instantiate(boostDamage, _gate[gateEven].position, _gate[gateEven].rotation);
            }
            else
            {
                CreateWave();
                _enemyInWave = 0;
            }
        }
    }
    void Update()
    {
        
    }
}
