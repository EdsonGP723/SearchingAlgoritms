using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour
{
    public Grid grid;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = grid.WorldToCell(worldPoint);
            Debug.Log(position);
        }
    }
}
