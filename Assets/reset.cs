using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class reset : MonoBehaviour {
    public GameObject[] talents;
	// Use this for initialization
	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(change);
    }

    private void change()
    {
        Debug.Log(talents.Length);
        talents = GameObject.FindGameObjectsWithTag("talent_" + "1");
        for (int i = 0; i < talents.Length; i++) { 
                talents[i].GetComponent<Image>().color = new Color(1f, 1f, 1f);
            PlayerPrefs.DeleteKey(talents[i].gameObject.name);
            }
        PlayerPrefs.DeleteKey("talent_" + "1");
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
