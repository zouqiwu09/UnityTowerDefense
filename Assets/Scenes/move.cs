using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;
    public Texture2D blood_green;
    public Texture2D blood_black;
    public Vector2 bloodSize;
    public int HP = 100;
    private Camera camera2;
    // Use this for initialization
    void Start () {
        lastWaypointSwitchTime = Time.time;
        camera2 = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint+1].transform.position;
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        if (gameObject.transform.position != endPosition)
            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        else
        {
            if (currentWaypoint == waypoints.Length-2)
                Destroy(gameObject);
            
            else
            {
                lastWaypointSwitchTime = Time.time;
                currentWaypoint++;
                RotateIntoDirection();
            }
        }
    }

    private void OnGUI()
    {
        Vector3 worldPosition = transform.position;
        Vector2 position = Camera.main.WorldToScreenPoint(worldPosition);
        //Debug.Log(position);
        //position = -position;
        position = new Vector2(position.x, Screen.height - position.y);
        //Debug.Log(position);

        //position = position + new Vector2(0, 1);
        float blood_width = bloodSize.x* HP / 100;
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y-15, bloodSize.x, bloodSize.y), blood_green);
        //在绘制红色血条
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y-15, blood_width, bloodSize.y), blood_black);
    }
    private void RotateIntoDirection()
    {
        Vector3 newstartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newendPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newendPosition - newstartPosition);

        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;

        //GameObject sprite = (GameObject)gameObject.transform.FindChild("Sprite").gameObject;
        gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle,Vector3.forward);
    }
}
