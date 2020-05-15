using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRefugee : MonoBehaviour
{
    public enum Phase { Spawning, Waiting, Countdown}

    public float timeBetweenWaves = 10f;
    float remainingTime;

    public Transform[] spawns;

    int spawnRate = 4;

    public GameObject terrorist;
    public GameObject refugee;
    public GameObject specialDude;

    public int characterCount = 10;
    public int TChance = 10;
    public int SChance = 10;

    Phase phase = Phase.Countdown;

    bool CharacterRemaining()
    {
        if (GameObject.FindGameObjectWithTag("Refugee") == null && GameObject.FindGameObjectWithTag("Terrorist") == null)
        {
            return false;
        }
        return true;
    }

    void Start()
    {
        remainingTime = timeBetweenWaves;
        phase = Phase.Countdown;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Spawning Wave");

        for (int i = 0; i < characterCount; i++)
        {
            SpawnCharacter();
            yield return new WaitForSeconds(1f/ spawnRate);
        }
        yield break;
    }

    void SpawnCharacter()
    {
        float chance = Random.Range(0.0f, 100.0f);
        // Spawn
        if(chance < TChance)
        {
            // Spawn terrorist
            Instantiate(terrorist, spawns[Random.Range(0, spawns.Length)].position, transform.rotation);
            Debug.Log("Spawned the bad dude");
        }
        else if(chance < SChance + TChance)
        {
            // Spawn the special one with the upgrades and self esteem
            Instantiate(specialDude, spawns[Random.Range(0, spawns.Length)].position, transform.rotation);
            Debug.Log("Spawned the good dude");
        }
        else
        {
            // Spawn the filthy refugee that is not special
            Instantiate(refugee, spawns[Random.Range(0, spawns.Length)].position, transform.rotation);
            Debug.Log("Spawned the normal dude");
        }
    }

    void Update()
    {
        if(phase == Phase.Countdown)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(phase == Phase.Spawning)
        {
            phase = Phase.Waiting;
            remainingTime = timeBetweenWaves;
            Debug.Log("Spawning");
            // Spawn the wave
            StartCoroutine(SpawnWave());
        }
        if (phase == Phase.Waiting)
        {
            Debug.Log("Waiting");
            if(!CharacterRemaining())
            {
                phase = Phase.Countdown;
                remainingTime = timeBetweenWaves;
            }
        }
        
        if(remainingTime < 0f)
        {
            phase = Phase.Spawning;           
        }
    }
}
