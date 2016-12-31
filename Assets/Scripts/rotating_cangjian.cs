using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating_cangjian : MonoBehaviour {
    public int damage;
    public List<GameObject> enemiesInRange;
    private bool attack_permit;
    public float rotate_speed;
    private float time;
	// Use this for initialization
	void Start () {
        attack_permit = false;
        if (PlayerPrefs.HasKey("cangjian_fengche"))
        {
            damage = PlayerPrefs.GetInt("cangjian_fengche");
        }
           
        
	}
	
    void attack()
    {
        transform.Rotate(0, 0, -rotate_speed);
        if (Time.time - time >= (360 / rotate_speed)*Time.deltaTime)
        {
            time = Time.time;
            damage_computing();
           
        }
    }
    void  damage_computing()
    {
        for(int i = 0; i<enemiesInRange.Count; i++)
        {
            if (enemiesInRange[i] != null)
            {
                if (enemiesInRange[i].GetComponent<move>().HP <= damage)
                {
                    Destroy(enemiesInRange[i].gameObject);
                }

                else
                {
                    enemiesInRange[i].GetComponent<move>().HP -= damage;
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
        Debug.Log(enemiesInRange.Count);
        Debug.Log(time + "" + 360 / rotate_speed);
        if (attack_permit)
        {
            attack();
        }
        if (enemiesInRange.Count.Equals(0))
        {
            attack_permit = false;
        }
	}
    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        attack_permit = true;
        if (target.gameObject.tag.Equals("Enemy")){
            enemiesInRange.Add(target.gameObject);
            EnemyDestructionDelegate del = target.gameObject.GetComponent<EnemyDestructionDelegate>();
        del.enemyDelegate += OnEnemyDestroy;
        }
        
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        
        if (target.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(target.gameObject);
            EnemyDestructionDelegate del = target.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }


}
