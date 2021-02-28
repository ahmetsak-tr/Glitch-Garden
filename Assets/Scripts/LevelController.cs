using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinContition());
        }
    }

    IEnumerator HandleWinContition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
   


    // Update is called once per frame
    void Update()
    {
        /*if (CheckTimer())
        {
            if(TrackNumberOfAttackers())
            {
                Debug.Log("End Level Now");
            }
        }*/
    }






















   /* private bool TrackNumberOfAttackers()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        
        foreach(AttackerSpawner spawner in spawners)
        {
            totalAttacker += spawner.transform.childCount;
        }

        return (totalAttacker <= 0);
    }

    private bool CheckTimer()
    {
        return FindObjectOfType<GameTimer>().CheckTimer();
    }*/
}
