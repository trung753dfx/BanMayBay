using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public float speed;
    protected virtual void Move(Vector3 direction)
    {
        this.transform.position += direction * Time.deltaTime * speed;
    }
}
