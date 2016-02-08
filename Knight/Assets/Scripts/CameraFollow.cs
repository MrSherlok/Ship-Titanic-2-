using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

/*	[SerializeField]
	private float xMax;

	[SerializeField]
	private float yMax;

	[SerializeField]
	private float xMin;

	[SerializeField]
	private float yMin;
*/
	private Transform target;

    int distanse = -10;
	float lift = 1.5f;
    Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, lift, distanse);
        target = GameObject.Find("CameraPoint").transform;
    }

    void FixedUpdate()
    {
        transform.position = offset + target.position;
        transform.LookAt(target);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
