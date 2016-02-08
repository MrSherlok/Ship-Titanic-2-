using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	public Vector2 speed = new Vector2(2, 2);
	public Vector2 direction = new Vector2(-1, 0);
    float speedByTime;
   

	void FixedUpdate() {
        //speedByTime = Time.deltaTime/5;
        //if   (speedByTime == 5)   {
        //    speed.x += 5;
        //}
        //if (speedByTime == 10)
        //{
        //    speed.x += 5;
        //}
        //if (speedByTime == 15)
        //{
        //    speed.x += 5;
        //}
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        movement *= Time.deltaTime;
        transform.Translate (movement);

        //transform.position += movement;

	}
}
