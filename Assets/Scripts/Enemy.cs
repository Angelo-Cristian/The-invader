using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int healthPoints;
    public GameObject explosion, damage;
    GameObject parentGameObject;
    ScoreBoard scoreBoard;
    int points;
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("Parent");

        if(gameObject.tag == "Bridge")
            healthPoints = 3; 
        else
        if(gameObject.tag == "Enemy")
            healthPoints = 2;
    }
    void OnParticleCollision(GameObject other)
    {
        EnemyHealth();
    }

    void EnemyHealth()
    {
        --healthPoints;
        GameObject VFX;
        if(healthPoints == 0)
        {
            VFX = Instantiate(explosion, transform.position, Quaternion.identity);
            VFX.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
            ScoreSystem();
        }
        else
        {
            VFX = Instantiate(damage, transform.position, Quaternion.identity);
            VFX.transform.parent = parentGameObject.transform;
        }
        
    }

    void PointSystem()
    {
        switch(gameObject.tag)
        {
            case "Bridge":
                points = 3;
                break;
            case "Enemy":
                points = 5;
                break;
        }
    }
    void ScoreSystem()
    {
        PointSystem();
        scoreBoard.ScoreKeeper(points);
    }
}
