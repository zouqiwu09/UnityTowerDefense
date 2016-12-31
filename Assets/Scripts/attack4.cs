using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack4 : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    private MonsterData monsterdata;
    public float shoot_interval;
    float lastshoot;
    // Use this for initialization
    void Start()
    {
        lastshoot = Time.time;
        monsterdata = gameObject.GetComponentInChildren<MonsterData>();
        enemiesInRange = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemiesInRange.Count);
        if (enemiesInRange.Count>0)
        {
            Shoot(enemiesInRange[0].GetComponent<Collider2D>());
        }
    }

    void Shoot(Collider2D target)
    {
        GameObject newbullet = monsterdata.CurrentLevel.bullet;
        if (Time.time - lastshoot > shoot_interval)
        {
            GameObject bullet = Instantiate(newbullet);
            lastshoot = Time.time;

            bullet.transform.position = transform.position;
            bullet.gameObject.GetComponent<bulletBehavior>().startposition = transform.position;
            bullet.gameObject.GetComponent<bulletBehavior>().endposition = target.transform.position;
            bullet.gameObject.GetComponent<bulletBehavior>().target = target.gameObject;
        }
    }
    void OnEnemyDestroy (GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(collision.gameObject);
            EnemyDestructionDelegate del = collision.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
            EnemyDestructionDelegate del = collision.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }
}
