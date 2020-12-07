using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Human> humans;
    private int spawner;
    private int counter;
    private void Start()
    {
        for (int i = 0; i < humans.Count; ++i)
        {
            humans[i].humanType = GetRandomHumanType();
        }
    }

    private void Update()
    {
        if (5 <= Time.timeSinceLevelLoad)
        {
            if (!(gameObject.GetComponent<CoolDown>().isCooldown))
            {
                Human human = humans[counter];
                if (human.isSpawned == false)
                {
                    spawner = Random.Range(0, 5);
                    GameObject humanInstance = Instantiate(prefabs[(int)human.humanType], transform.GetChild(spawner).transform);
                    transform.GetChild(spawner).GetComponent<SpawnPoint>().humans.Add(humanInstance);
                    human.isSpawned = true;
                    gameObject.GetComponent<CoolDown>().setCoolDown(Random.Range(3, 10));
                    counter++;
                }
            }
        }
        
    }
    private HumanType GetRandomHumanType()
    {
        HumanType type = (HumanType)Random.Range(0, System.Enum.GetNames(typeof(HumanType)).Length);
        return type;
    }
}
