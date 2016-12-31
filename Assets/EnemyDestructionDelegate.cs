using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructionDelegate : MonoBehaviour {
    public GameObject Gamemanager;
    public delegate void EnemyDelegate(GameObject enemy);
    public EnemyDelegate enemyDelegate;
	// Use this for initialization
	void Start () {
        Gamemanager = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        Gamemanager.GetComponent<level1>().Change_gold(50);
        if (enemyDelegate != null)
        {
            enemyDelegate(gameObject);
        }
       
    }
}
