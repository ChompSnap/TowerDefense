using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System;
public class Enemy : MonoBehaviour
{
    public Transform target;
    public int health = 3;
    public int coinReward = 2;
    public TMP_Text purse;
    public TMP_Text tower;
    public Camera view;
    public AudioClip explosion;
    public GameObject manager;

    private int bankInt;
    private int towerHealth;


    //public delegate void EnemyDied(EnemyComplete deadEnemy);
    //public event EnemyDied OnEnemyDied;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Debug.Log("Test!!!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f) && Input.GetMouseButtonDown(0))
            {
                if (hitInfo.collider.tag == "Enemy")
                {
                    Debug.Log("HIT!!!");
                    health -= 1;

                    if (health <= 0)
                    {
                        bankInt = coinReward + Int32.Parse(purse.text);
                        purse.text = bankInt.ToString();
                        Destroy(hitInfo.transform.gameObject);
                    }
                }
            }
        }

        if(Vector3.Distance(this.gameObject.transform.position, target.position) < 10f)
        {
            towerAttack();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            towerAttack();
        }
    }

    public void lowerHealth()
    {
        health -= 1;

        if(health == 0)
        {
            manager.GetComponent<GameManager>().playSound();
            bankInt = coinReward + Int32.Parse(purse.text);
            purse.text = bankInt.ToString();
            Destroy(this.gameObject);
        }
    }
    void towerAttack()
    {
        towerHealth = Int32.Parse(tower.text) - 1;
        tower.text = towerHealth.ToString();
        Destroy(this.gameObject);
        if(towerHealth == 0)
        {
            Destroy(target.gameObject);
        }
    }
}
