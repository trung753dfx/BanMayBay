using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class BulletCtrler : MoveCtrl
{
    public float time = 0;
    //public SmokeCtrler explosion;
    public BulletCtrler bullet;
    public float damage;

    public void Update()
    {
        if (time == 750)
        {
            //SmartPool.Instance.Despawn(bullet.gameObject);
            Destroy(this.gameObject);
        }
        time++;
        Move(transform.up);
    }
    public virtual float CalculateHP(float hp, float level)
    {
        var hpLeft = hp - (level + damage);
        return hpLeft;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag != this.gameObject.tag)
        {
            SmartPool.Instance.Despawn(this.gameObject);
        }
    }
    public void CreateSmoke()
    {

        //var smokeclone = SmartPool.Instance.Spawn(explosion.gameObject, this.transform.position, this.transform.rotation);
    }

    protected virtual void BulletEx()
    {
        if (time == 30)
        {
            SmartPool.Instance.Despawn(this.gameObject);
            Instantiate(this.gameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        time++;
    }
}
