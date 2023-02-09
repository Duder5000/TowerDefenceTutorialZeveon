using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float enemyHealth;
    [SerializeField] private float movementspeed;

    private int killReward; //need to change to how much comps the enemy drops when killed later
    private int damage; //damage to rocket
    private GameObject targetTile;

    private void Awake() {
        Enemies.enemies.Add(gameObject);
    }

    private void Start() {
        initializeEnemey();
    }

    private void initializeEnemey() {
        targetTile = MapGenerator.startTile;
    }

    public void takeDamage(float amount) {
    
        enemyHealth -= amount;

        if (enemyHealth <= 0) {
            die();
        }
    
    }

    private void die() {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);    
    }

    private void moveEnemey() {        
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementspeed * Time.deltaTime);
    }

    private void checkPosition() {

        if (targetTile != null && targetTile != MapGenerator.endTile) { 
        
            float distance = (transform.position - targetTile.transform.position).magnitude;
            if (distance < 0.001f) {

                int currentIndex = MapGenerator.pathTiles.IndexOf(targetTile);
                targetTile = MapGenerator.pathTiles[currentIndex + 1];

            }
        
        }

    }

    private void Update() {

        checkPosition();
        moveEnemey();

        takeDamage(0);

    }
}
