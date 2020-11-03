using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject draggingObject;
    [SerializeField] public GameObject currentContainer;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaceObject()
    {
        if(draggingObject != null && currentContainer != null)
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.objectGame, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;
        }
    }
}
