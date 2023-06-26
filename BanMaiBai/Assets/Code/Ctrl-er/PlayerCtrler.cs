using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;
public class PlayerCtrler : PlaneCtrler
{
    public float deltaX, deltaY = 0;
    public Vector3 pos;
    Touch touch;
    public float DelayBetweenShoot;
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

    private void awake()
    {
        //slider_hp.maxvalue = hp;
        //slider_exp.maxvalue = exptolevelup;
    }
    private float time = 0;
    void Start()
    {

    }
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        touch1();
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
        time++;
        if (time % DelayBetweenShoot == 0)
        {
            Shoot();
        }
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
    public void move(Vector3 pos)
    {
        this.transform.position = Vector3.Lerp(transform.position, pos, 5);
    }
    public void touch1()
    {
        //hàm chạm di chuyển
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchpos.x - transform.position.x;
                    deltaY = touchpos.y - transform.position.y;
                    break;
                case TouchPhase.Moved:
                    this.transform.position = new Vector2(touchpos.x - deltaX, touchpos.y - deltaY);
                    //rigidbody.MovePosition(new Vector2(touchpos.x - deltaX, touchpos.y - deltaY));
                    break;
                case TouchPhase.Ended:
                    transform.position = transform.position;
                    //rigidbody.velocity = Vector2.zero;
                    break;
            }
        }
    }
    IEnumerator aha()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("enemy"))
        {
            hp = bullet.CalculateHP(hp, level);
            Destroy(this.bullet);
            Instantiate(bullet.explosion, gameObject.transform.position, gameObject.transform.rotation);
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