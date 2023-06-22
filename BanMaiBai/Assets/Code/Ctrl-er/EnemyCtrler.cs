using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrler : PlaneCtrler
{
    private float time = 0;
    void Update()
    {
        this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * speed;

        time++;
        if (time % 500 == 0)
        {
            Shoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("DieWhenImpact"))
        {
            Destroy(this.gameObject);
        }
    }
}
