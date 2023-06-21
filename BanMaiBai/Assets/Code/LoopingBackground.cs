using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float BGspeed;
    public Renderer BGRenderer;
    // Update is called once per frame
    void Update()
    {
        BGRenderer.material.mainTextureOffset += new Vector2(0f, BGspeed * Time.deltaTime); 
    }
}
