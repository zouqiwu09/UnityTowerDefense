using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
    public GameObject enemy;
	// Use this for initialization
	void Start () {
        transform.position = enemy.transform.position+Vector3.forward+Vector3.up;
        
    }

    // Update is called once per frame
    void Update() {
        transform.position = enemy.transform.position + Vector3.forward + Vector3.up;
    }
}
