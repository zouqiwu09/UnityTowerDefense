using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
    public GameObject enemy;
    public GameObject[] waypoints;
    public GameObject healthbar;
    private float count;
    public float interval;
    public int maxium;
    private int number_of_enemy = 0;
	// Use this for initialization
	void Start () {
        GameObject es = Instantiate(enemy);
        es.GetComponent<move>().waypoints = waypoints;
      //  Instantiate(healthbar).GetComponent<health>().enemy = es; 
        
        number_of_enemy++;
        count = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        float count_time = Time.time;
        if (count_time - count > interval && number_of_enemy < maxium)
        {
            GameObject es = Instantiate(enemy);
            es.GetComponent<move>().waypoints = waypoints;
            //Instantiate(healthbar).GetComponent<health>().enemy = es;
            number_of_enemy++;
            count = Time.time;
        }
    
    }
}
