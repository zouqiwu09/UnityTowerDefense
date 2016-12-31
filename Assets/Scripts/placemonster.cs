using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placemonster : MonoBehaviour {
    public GameObject monsterPrefab;
    private GameObject monster;
	// Use this for initialization
	void Start () {
		
	}
	private bool canPlaceMonster()
    {
        return monster == null;
    }
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseUp()
    {
        if (canPlaceMonster())
        {
            monster = (GameObject)Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
