using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level1 : MonoBehaviour {
    public GameObject wave_num;
    public GameObject Gold;
    public GameObject price;
    public string gold = "gold";
    public int gold_amount = 0;
    public GameObject selected;
    public bool can_spawn = true;
	// Use this for initialization
	void Start () {
        wave_num.GetComponent<Text>().text = "wave : 1";
        price.GetComponent<Text>().text=GameObject.Find("藏剑").GetComponent<initiate_cangjiandizi>().price.ToString();
        price.transform.position = Camera.main.WorldToScreenPoint(GameObject.Find("藏剑").transform.position) + new Vector3(0,-30,0);

    }
	
	// Update is called once per frame
	void Update () {
        Gold.GetComponent<Text>().text = gold + " : " + gold_amount.ToString();
    }
    public void Change_gold(int num)
    {
        gold_amount += num;
        
    }
}
