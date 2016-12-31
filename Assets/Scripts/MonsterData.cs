using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [System.Serializable]
 public class MonsterLevel
{
    public int cost;
    public GameObject bullet;
    public GameObject visualization;
}

public class MonsterData : MonoBehaviour {
    public List<MonsterLevel> levels;
    private MonsterLevel currentLevel;
    public MonsterLevel CurrentLevel { 
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);
            GameObject levelvisual = levels[currentLevelIndex].visualization;
            for (int i = 0; i<levels.Count; i++)
            {
                if(levelvisual != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }
	// Use this for initialization
	void Start () {
        
    }
    private void OnEnable()
    {
        CurrentLevel = levels[0];
    }
    // Update is called once per frame
    void Update () {
		
	}

}
