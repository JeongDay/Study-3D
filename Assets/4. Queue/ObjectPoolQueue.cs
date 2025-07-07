using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    private Queue<GameObject> objQueue = new Queue<GameObject>();

    [SerializeField] private GameObject objPrefab;
    [SerializeField] private Transform parent;

    void Start()
    {
        CreateObj();
    }

    private void CreateObj()
    {
        for (int i = 0; i < 10; i++)
        {
            var obj = Instantiate(objPrefab, parent);
            obj.transform.SetParent(parent);
            
            EnQueueObject(obj);
        }
    }

    public void EnQueueObject(GameObject newObj)
    {
        objQueue.Enqueue(newObj);
        newObj.transform.SetParent(parent);
        newObj.SetActive(false);
    }

    public GameObject DequeueObject(Vector3 respawnPos)
    {
        if (objQueue.Count <= 3)
            CreateObj();
        
        var obj = objQueue.Dequeue();
        obj.transform.position = respawnPos;
        obj.SetActive(true);
        
        return obj;
    }
}