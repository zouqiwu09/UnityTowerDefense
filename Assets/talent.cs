using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class talent : MonoBehaviour {
    private GameObject[] talents;
    // Use this for initialization
    void Start() {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(change);
    }
    private void change()
    {
        if (GetComponent<Image>().color == new Color(1f, 1f, 1f)) {
        Debug.Log(this.gameObject.name.ToString());
        talents = GameObject.FindGameObjectsWithTag(this.tag.ToString());
        for (int i = 0; i < talents.Length; i++)
        {
            talents[i].GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f);
        }
        GetComponent<Image>().color = new Color(1f, 1f, 1f);
        PlayerPrefs.SetInt(gameObject.name, 1);
        PlayerPrefs.SetInt(gameObject.tag, 1);
        GetComponent<Image>().color = new Color(1f, 1f, 1f); }
    }
	// Update is called once per frame
	void Update () {

	}
    
}
