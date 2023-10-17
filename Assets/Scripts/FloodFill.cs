using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloodFill : MonoBehaviour
{
    public Queue<Vector3Int> frontier = new();

    public Vector3Int startingPoint;

    public Set reached = new Set();

    public Tilemap tilemap;

    public TileBase tilePurple;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FloodFillStartCoroutine();
        }
    }
    public void FloodFillStartCoroutine()
    {

        frontier.Enqueue(startingPoint);

        StartCoroutine(FloodFillCoroutine());


    }

    IEnumerator FloodFillCoroutine()
    {
        while (frontier.Count > 0)
        {
            Vector3Int current = frontier.Dequeue();

            Debug.Log(frontier.Count);


            List<Vector3Int> neighbours = getNeighbours(current);

            foreach (Vector3Int next in neighbours)
            {

                if (!reached.set.Contains(next) && tilemap.GetSprite(next) != null)
                {
                    Debug.Log(tilemap.GetSprite(current));
                    Debug.Log(next);
                    tilemap.SetTile(next, tilePurple);
                    reached.Add(next);
                    frontier.Enqueue(next);


                }

            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private List<Vector3Int> getNeighbours(Vector3Int current)
    {
        List<Vector3Int> neighbours = new List<Vector3Int>();
        neighbours.Add(current + new Vector3Int(0, 1, 0));
        neighbours.Add(current + new Vector3Int(0, -1, 0));
        neighbours.Add(current + new Vector3Int(1, 0, 0));
        neighbours.Add(current + new Vector3Int(-1, 0, 0));

        return neighbours;
    }
}