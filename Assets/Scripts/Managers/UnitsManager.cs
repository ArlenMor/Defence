using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public static UnitsManager Instance;

    private List<ScriptableUnit> m_units;

    private void Awake()
    {
        Instance = this;

        m_units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnHeroes()
    {
        var heroCount = 1;

        for(int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetHeroSpawnTile();

            randomSpawnTile.SetUnit(spawnedHero);
        }

        GameManager.Instance.ChangeState(GameState.Fight);
    }

    public void SpawnEnemies()
    {
        var enemyCount = 1;

        for (int i = 0; i < enemyCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
            var spawnedEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

            randomSpawnTile.SetUnit(spawnedEnemy);
        }
        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)m_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }
}
