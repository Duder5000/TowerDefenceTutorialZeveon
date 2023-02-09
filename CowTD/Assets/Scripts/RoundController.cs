using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public GameObject basicEnemy;
    
    public float timeBetweenWaves;
    public float timeBeforeRoundStarts;
    public float timeVariable;
   
    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;

    public int round;
    public int enemiesInRoundToSpawn; //tring to fix 

    private void Start() {

        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStarts;

        round = 1;
        enemiesInRoundToSpawn = round; //tring to fix 

    }

    private void spawnEnemies() {
        StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISpawnEnemies() {
        for (int i = 0; i < round; i++)
        {

            if (Enemies.enemies.Count <= round) //not part of tutorail, guess for fixing the infinate spawning enemies, that the fix in the tutorial didnt work for me
            {
                if (enemiesInRoundToSpawn > 0) {
                    GameObject newEnemy = Instantiate(basicEnemy, MapGenerator.startTile.transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                    enemiesInRoundToSpawn--; //tring to fix 
                }
            }
        }
    }

    public void Update()
    {

        if (isStartOfRound)
        {

            if (Time.time >= timeVariable)
            {
                isStartOfRound = false;
                isIntermission = false; //tring to fix 
                isRoundGoing = true;

                spawnEnemies();
                return;
            }

        }
        else if (isIntermission)
        {

            if (Time.time >= timeVariable)
            {

                isStartOfRound = false;
                isIntermission = false; //tring to fix 
                isRoundGoing = true;

                spawnEnemies();
                return;
            }

        }
        else if (isRoundGoing)
        {

            if (Enemies.enemies.Count > 0)
            {
                //do nothing
            }
            else {
                isStartOfRound = false;
                isIntermission = true;
                isRoundGoing = false;

                timeVariable = Time.time + timeBetweenWaves;
                round++;
                enemiesInRoundToSpawn = round; //tring to fix 
                return;
            }
        
        }

    }
}
