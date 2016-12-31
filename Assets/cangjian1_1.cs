using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cangjian1_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(change);
    }
	void change()
    {
        PlayerPrefs.SetInt("cangjian_fengche", 100);
    }
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<Image>().color == new Color(0.3f, 0.3f, 0.3f))
        {
            PlayerPrefs.DeleteKey("cangjian_fengche");
            
        }
	}
}
