using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    public int health = 3;
    public float speed = 3f;
    public int coins = 3;
    private int waypointindex;
    public TMP_Text bank;
    public List<Transform> waypointsList;
    public int bankInt;
    public GameManager manager;

    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death

    public delegate void EnemyDied(EnemyDemo deadEnemy);

    // NOTE! This code should work for any speed value (large or small)
    public event EnemyDied OnEnemyDead;
    private void Awake()
    {
        manager = GameObject.Find("TowerDefenseMap").GetComponent<GameManager>();
        health = 3;
        bankInt = 3;
    }
    //-----------------------------------------------------------------------------
    void Start()
    {
        transform.position = Waypoints.points[0].position;
        waypointindex = 1;
        health = 3;
        bankInt = 3;
        // todo #2
        //   Place our enemy at the starting waypoint
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = Waypoints.points[waypointindex].position;
        Vector3 movementDirection = (targetPosition - transform.position).normalized;

        Vector3 newPos = transform.position;
        newPos += movementDirection * speed * Time.deltaTime;

        transform.position = newPos;
        bool enemyded = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 17f) && Input.GetMouseButtonDown(0))
        {
            health -= 1;

            if(health <= 0)
            {
                Debug.Log(manager.getBankInt());
                Debug.Log(coins);
                bankInt = coins + manager.getBankInt();
                bank.text = bankInt.ToString();
                manager.setBankInt(bankInt);
                Destroy(hitInfo.transform.gameObject);
            }
        }

        if(Vector3.Distance(transform.position, targetPosition) <= 0.2f && waypointindex != waypointsList.Count - 1)
        {
            waypointindex++;
        }

        if(enemyded)
        {

        }
        // todo #4 Check if destination reaches or passed and change target
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
    }
}
