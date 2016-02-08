using UnityEngine;
using System.Collections.Generic;

public class Enemy_script : MonoBehaviour
    
{
    public Vector2 speed = new Vector2(0.5f, 0.5f);
    public Vector2 direction = new Vector2(-1, 0);



    void Update()
    {
    transform.Translate(new Vector3(
            speed.x * direction.x,
            speed.y * direction.y,
            0));
    }

   

}
