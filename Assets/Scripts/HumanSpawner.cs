using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Human> humans;
    private int spawner;
    public int counter;
    private void Start()
    {
        for (int i = 0; i < humans.Count; ++i)
        {
            //Fill list with random generated human types
            humans[i].humanType = GetRandomHumanType();
        }
    }

    private void Update()
    {
        if (40 <= Time.timeSinceLevelLoad)
        {
            if (!(gameObject.GetComponent<CoolDown>().isCooldown))
            {
                try
                {
                    Human human = humans[counter];
                    if (human.isSpawned == false)
                    {
                        //Random spawner
                        spawner = Random.Range(0, 5);
                        //Instantiate
                        GameObject humanInstance = Instantiate(prefabs[(int)human.humanType], transform.GetChild(spawner).transform);
                        //Add to spawner
                        transform.GetChild(spawner).GetComponent<SpawnPoint>().humans.Add(humanInstance);
                        human.isSpawned = true;
                        gameObject.GetComponent<CoolDown>().setCoolDown(Random.Range(5, 20));
                        counter++;
                    }
                }
                catch (System.Exception)
                {
                }
                
            }
        }
    }
    private HumanType GetRandomHumanType()
    {
        //Random enum get
        HumanType type = (HumanType)Random.Range(0, System.Enum.GetNames(typeof(HumanType)).Length);
        return type;
    }
}
