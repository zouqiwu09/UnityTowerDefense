using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour {
    public Vector3 startposition;
    public Vector3 endposition;
    public int damage;
    public GameObject target;
    float start_time;
    public float speed;
    float distance;
	// Use this for initialization
	void Start () {
        start_time = Time.time;
        distance = Vector3.Distance(startposition, endposition);
	}
	
	// Update is called once per frame
	void Update () {
        float interval = Time.time - start_time;
        transform.position = Vector3.Lerp(startposition, endposition, interval * speed / distance);
        if (transform.position.Equals(endposition))
        {
            Destroy(gameObject);
            if (target != null)
            {
                if (target.GetComponent<move>().HP <= damage)
                {
                    Destroy(target.gameObject);
                }

                else
                {
                    target.GetComponent<move>().HP -= damage;
                }
            }
        }
	}
}
