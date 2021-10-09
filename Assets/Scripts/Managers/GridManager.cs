using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int m_width, m_height;
    [SerializeField] private Tile m_grassTile, m_trainTile;
    [SerializeField] private Transform m_cam;

    private Dictionary<Vector2, Tile> m_tiles;


    private void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        m_tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < m_width; x++)
            for (int y = 0; y < m_height; y++)
            {
                var randomTile = m_grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(x, y);

                m_tiles[new Vector2(x, y)] = spawnedTile;
            }


        var spawnedTrain = Instantiate(m_trainTile, new Vector3(m_width / 2, m_height / 2), Quaternion.identity);
        spawnedTrain.Init(m_width / 2, m_height / 2);
        m_tiles[new Vector2(m_width / 2, m_height / 2)] = spawnedTrain;

        m_cam.transform.position = new Vector3((float)m_width / 2 - 0.5f, (float)m_height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public Tile GetHeroSpawnTile()
    {
        return m_tiles.Where(t => t.Key.x < m_width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetEnemySpawnTile()
    {
        return m_tiles.Where(t => t.Key.x > m_width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    private void SpawnTrain()
    {

    }


    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(m_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}
