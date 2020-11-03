using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public GameObject objectDrag;
    [SerializeField] public GameObject objectGame;
    [SerializeField] public Canvas canvas;
    private GameObject _objectDragInstance;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        _objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        _objectDragInstance = Instantiate(objectDrag, canvas.transform);
        _objectDragInstance.transform.position = Input.mousePosition;
        _objectDragInstance.GetComponent<ObjectDragging>().card = this;

       _gameManager.draggingObject = _objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _gameManager.PlaceObject();
        _gameManager.draggingObject = null;
        Destroy(_objectDragInstance);      
    }
}
