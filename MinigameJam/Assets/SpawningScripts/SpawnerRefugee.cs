using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRefugee : MonoBehaviour
{
    public enum Phase { Spawning, Waiting, Countdown }

    public float timeBetweenWaves = 10f;
    float remainingTime;

    public Transform[] spawns;

    [SerializeField]
    private int spawnRate = 4;

    public GameObject terrorist;
    public GameObject[] refugees;
    public GameObject specialDude;

    public int characterCount = 10;
    public int TChance = 10;
    public int SChance = 10;

    Phase phase = Phase.Countdown;

    bool CharacterRemaining ()
    {
        if (GameObject.FindGameObjectWithTag ("Refugee") == null && GameObject.FindGameObjectWithTag ("Terrorist") == null)
        {
            return false;
        }
        return true;
    }

    void Start ()
    {
        remainingTime = 26;
        phase = Phase.Countdown;
    }

    IEnumerator SpawnWave ()
    {
        characterCount += Mathf.RoundToInt (Random.value);
        for (int i = 0; i < characterCount; i++)
        {
            SpawnCharacter ();
            yield return new WaitForSeconds (1f / spawnRate);
        }

        yield break;
    }
   public void StartWave ()
    {
        remainingTime = 0;
    }
    void SpawnCharacter ()
    {
        float chance = Random.Range (0.0f, 100.0f);
        bool rotate = false;
        int index = Random.Range (0, spawns.Length);
        if (index == 0)
            rotate = true;

        Vector2 pos = spawns[index].position;
        // Spawn
        if (chance < TChance)
        {
            // Spawn terrorist
            GameObject oj = Instantiate (terrorist, pos, transform.rotation,transform);
            if (rotate)
            {
                Vector3 rot = oj.transform.localScale;
                rot.x = -rot.x;
                oj.transform.localScale = rot;
            }


        }
        else if (chance < SChance + TChance)
        {
            // Spawn the special one with the upgrades and self esteem
            GameObject oj = Instantiate (specialDude, pos, transform.rotation, transform);
            if (rotate)
            {
                Vector3 rot = oj.transform.localScale;
                rot.x = -rot.x;
                oj.transform.localScale = rot;
            }
        }
        else
        {
            // Spawn the filthy refugee that is not special
            GameObject oj = Instantiate (refugees[Random.Range (0, refugees.Length)], pos, transform.rotation, transform);
            if (rotate)
            {
                Vector3 rot = oj.transform.localScale;
                rot.x = -rot.x;
                oj.transform.localScale = rot;
            }
        }
    }

    void Update ()
    {
        if (phase == Phase.Countdown)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (phase == Phase.Spawning)
        {
            phase = Phase.Waiting;
            remainingTime = timeBetweenWaves;

            // Spawn the wave
            StartCoroutine (SpawnWave ());
        }
        if (phase == Phase.Waiting)
        {
            Debug.Log ("Waiting");
            if (!CharacterRemaining ())
            {
                phase = Phase.Countdown;
                remainingTime = timeBetweenWaves;
            }
        }

        if (remainingTime < 0f)
        {
            phase = Phase.Spawning;
        }
    }
}
