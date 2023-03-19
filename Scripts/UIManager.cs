using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabPoints;
    private DB db;
    private void Start()
    {
        db = FindObjectOfType<DB>();
        PointsCreate();
    }
    private void PointsCreate()
    {
        for(int i=0; i < db.distance.Count; i++)
        {
            Instantiate(prefabPoints,new Vector3(db.distance[i] / 70, db.distance[i] / 70), transform.rotation);
        }
    }

}
