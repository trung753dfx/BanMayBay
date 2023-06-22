using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class PlaneCtrler : MoveCtrl
{
    public float deltaX, deltaY = 0;
    public Vector3 pos;
    Touch touch;
    public Transform plane;
    public BulletCtrler bullet;
    public Transform transhoot;
    public float hp;
    public float level;

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        touch1();
    }
    protected override void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            plane.up = direction;
        }
        base.Move(direction);
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
        var bulletclone = SmartPool.Instance.Spawn(bullet.gameObject, transhoot.transform.position, transhoot.transform.rotation);
        bulletclone.GetComponent<BulletCtrler>().damage += level;
        bulletclone.GetComponent<BulletCtrler>().tag = this.tag;
    }
}
