using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;
    public GameManager gameManager;


    [SerializeField] private float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        distanceBetweenObjects = prevObject.localScale.z;
    }

    public void Stack_forward(Transform pickedObject)
    {
        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;

        desPos.z -= distanceBetweenObjects;
        pickedObject.transform.localPosition = desPos;
        prevObject = pickedObject.transform;
        gameManager.bulletSpawnPoint = pickedObject;
    }
}
