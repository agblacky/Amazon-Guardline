using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counterscript : MonoBehaviour
{
    public GameObject counterPrefab;
    private GameObject Text;
    private void Awake()
    {
        Instantiate(counterPrefab, transform);
    }
    public void Add()
    {
        
    }
    public void Remove(int food)
    {
        
    }

}
