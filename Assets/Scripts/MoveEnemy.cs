using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    [HideInInspector]
    public GameObject[] waypoints;
    private int currWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }
    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(gameObject.transform.position, waypoints[currWaypoint + 1].transform.position);
        for(int i=currWaypoint+1;i<waypoints.Length -1;i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }
    private void RotateIntoMoveDirection()
    {
        Vector3 newStartPosition = waypoints[currWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Size of Waypoints is : " + waypoints.Length);
        Vector3 startPosition = waypoints[currWaypoint].transform.position;
        Vector3 endPosition = waypoints[currWaypoint + 1].transform.position;

        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        RotateIntoMoveDirection();

       
        if (gameObject.transform.position.Equals(endPosition))
        {
            if(currWaypoint<waypoints.Length-2)
            {
                currWaypoint++;
                lastWaypointSwitchTime = Time.time;

            }
            else
            {
                GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                gameManager.Health -= 1;
                Destroy(gameObject);
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);


            }                
        }
    }
}
