using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_place : MonoBehaviour {
    public GameObject prefab;
    public GameObject manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseOver()
    {
        manager.GetComponent<level1>().can_spawn = true;

    }
    /*private void OnMouseEnter()
    {
        manager.GetComponent<level1>().can_spawn = true;
    }*/
    private void OnMouseExit()
    {
        manager.GetComponent<level1>().can_spawn = false;
    }
}
