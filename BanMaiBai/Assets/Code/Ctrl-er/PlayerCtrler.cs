using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;
public class PlayerCtrler : PlaneCtrler
{
    //public Slider slider_hp;
    //public Text levelTxt;
    //public GameObject hpPoint;

    //public Slider slider_exp;
    //public Text expText;
    //public GameObject expPoint;

    //public int currentExp;
    //public int expToLevelUp;

    //public float damageBonus;

    //public HoiMauController hoiMau;
    //public TangDamage tangDamage;
    //public TangSpd tangSpd;

    //private void Awake()
    //{
    //    //slider_hp.maxValue = hp;
    //   // slider_exp.maxValue = expToLevelUp;
    //}

    void Update()
    {
        //
        //slider_hp.value = hp;
        //if (hp <= 0)
        //{
        //    Destroy(this.gameObject);
        //    hpPoint.gameObject.SetActive(false);
        //}
        ////

        //slider_exp.value = currentExp;
        //expCalculate();

        //
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical,0f);
        Move(direction);

        //DestroyWhenOutOfHP();
    }
    //public void expCalculate()
    //{
    //    if (currentExp >= expToLevelUp)
    //    {
    //        currentExp = currentExp - expToLevelUp;
    //        level++;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("enemyBullet"))
        {
            hp = bullet.CalculateHP(hp, level);
            //Destroy(this.bullet);
            //Instantiate(bullet.explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
        //if (collision.transform.gameObject.CompareTag("health"))
        //{
        //    hp = hoiMau.CalculateHP(hp);
        //    Destroy(collision.transform.gameObject);
        //}
        //if (collision.transform.gameObject.CompareTag("tangDamage"))
        //{
        //    hp = tangDamage.CalculateHP(hp);
        //    damageBonus = tangDamage.CalculateDamage(damageBonus);
        //    Destroy(collision.transform.gameObject);
        //}
    }
}
public class Player : SingletonMonoBehaviour<PlayerCtrler>
{

}