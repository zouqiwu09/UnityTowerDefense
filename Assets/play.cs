using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour {
    //public Button button;
	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Task);
	}
    void Task()
    {
       SceneManager.LoadScene("GameScene2");
        
    }
    // Update is called once per frame
    void Update () {
	
	}
}
