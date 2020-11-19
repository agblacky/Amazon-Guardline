using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Human> humans;
    private int spawner;

    private void Update()
    {
        foreach(Human human in humans)
        {
            if (human.isSpawned == false && human.spawnTime < Time.time)
            {
                spawner = Random.Range(1, 5);
                GameObject humanInstance = Instantiate(prefabs[(int)human.humanType],transform.GetChild(spawner).transform);
                transform.GetChild(spawner).GetComponent<SpawnPoint>().humans.Add(humanInstance);
                human.isSpawned = true; 
            }
        }
    }
}
