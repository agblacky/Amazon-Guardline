using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Human> humans;

    private void Update()
    {
        foreach(Human human in humans)
        {
            if (human.isSpawned == false && human.spawnTime < Time.time)
            {
                GameObject humanInstance = Instantiate(prefabs[(int)human.humanType],transform.GetChild(human.spawner).transform);
                transform.GetChild(human.spawner).GetComponent<SpawnPoint>().humans.Add(humanInstance);
                human.isSpawned = true; 
            }
        }
    }
}
