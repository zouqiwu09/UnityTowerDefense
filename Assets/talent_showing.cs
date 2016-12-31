using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talent_showing : MonoBehaviour {
    public GameObject[] talents;
    // Use this for initialization
    void Start()
    {
        talents = GameObject.FindGameObjectsWithTag("talent_" + "1");
        if (PlayerPrefs.HasKey("talent_" + "1"))
        {
            for (int i = 0; i < talents.Length; i++)
            {
                if (PlayerPrefs.GetInt(talents[i].name) == 1)
                {
                    talents[i].GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                else
                {
                    talents[i].GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f);
                }
            }
        }
    }
        
        
	
	// Update is called once per frame
	void Update () {
		
	}
}
