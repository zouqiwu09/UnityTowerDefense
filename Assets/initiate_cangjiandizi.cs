using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiate_cangjiandizi : MonoBehaviour {
    public GameObject cangjian;
    private GameObject minion;
    public GameObject manager;
    public int price;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (manager.GetComponent<level1>().gold_amount >= price)
        {
            
            minion = Instantiate(cangjian);
        }

    }
    private void OnMouseDrag()
    {
        minion.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 5);

    }
    private void OnMouseUp()
    {
        if (!manager.GetComponent<level1>().can_spawn)
        {
            Destroy(minion);
        }
        else
        {
            manager.GetComponent<level1>().gold_amount -= price;
        }
    }
}
