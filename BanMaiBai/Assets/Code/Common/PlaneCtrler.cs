using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class PlaneCtrler : MoveCtrl
{


    public Transform plane;
    public BulletCtrler bullet;
    public Transform transhoot,ts2,ts3;
    public float hp;
    public float level;


    // Update is called once per frame
    void Update()
    {
    }
    protected override void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            plane.up = direction;
        }
        base.Move(direction);
    }
    //protected void RotationGun(Vector3 direction)
    //{
    //    gun.up = direction;
    //}
    public void Shoot()
    {
        CreateBullet();
    }

    public void DestroyWhenOutOfHP()
    {
        if (hp <= 0)
        {
            //Destroy(this.gameObject);
            //gameManager.Instance.genEnemyTank();
            //gameManager.Instance.addScore();
        }
    }
    public void CreateBullet()
    {
        //var bulletclone = SmartPool.Instance.Spawn(bullet.gameObject, transhoot.transform.position, transhoot.transform.rotation);
        //bulletclone.GetComponent<BulletCtrler>().damage += level;
        //bulletclone.GetComponent<BulletCtrler>().tag = this.tag;
        Instantiate(bullet.gameObject, transhoot.transform.position, transhoot.transform.rotation);
        //Instantiate(bullet.gameObject, ts2.transform.position,  Quaternion.Euler(Vector3.forward * 65));
        //Instantiate(bullet.gameObject, ts3.transform.position,  Quaternion.Euler(Vector3.forward * -65));
    }
    public void CreateBulletEnemy()
    {
        Instantiate(bullet.gameObject, transhoot.transform.position, transhoot.transform.rotation);
    }
}
