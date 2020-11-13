using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void PlaceObject()
    {
        if (draggingObject != null && currentContainer != null)
        {
            GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            if(!objectGame.GetComponent<FrogController>()&&!objectGame.GetComponent<PlantController>())
            {
                objectGame.GetComponent<AnimalController>().humans = currentContainer.GetComponent<ObjectContainer>().spawnPoint.humans;
            }
            currentContainer.GetComponent<ObjectContainer>().isfull = true;
        }
    }
}
