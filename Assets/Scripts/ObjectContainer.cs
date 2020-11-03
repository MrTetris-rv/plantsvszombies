using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] public bool isFull;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public Image background; 

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameManager.draggingObject != null && isFull == false)
        {
            gameManager.currentContainer = this.gameObject;
            background.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.currentContainer = null;
        background.enabled = false;
    }
}
