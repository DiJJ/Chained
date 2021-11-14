using System.Collections;
using Main.ScriptablesObjects;
using Main.Scripts.Core;
using Main.Scripts.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [FoldoutGroup("Scriptable Object")][SerializeField] private BaseEnemySO _baseEnemySO;
    private Transform _target;
    
    [SerializeField] private bool _repeatSpawn = false;
    [FoldoutGroup("Settings")] [ShowIf(nameof(_repeatSpawn))] [SerializeField] private float _delayTime = 1;
    [FoldoutGroup("Settings")] [SerializeField] private float _rangeMin = 1;
    [FoldoutGroup("Settings")] [SerializeField] private float _rangeMax = 10;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(TagConstants.Player).transform;
        
        if (_repeatSpawn)
        {
            StartCoroutine(SpawnRoutine());
            return;
        }
        
        Spawn();
    }

    private IEnumerator SpawnRoutine()
    {
        while (_repeatSpawn)
        {
            Spawn();

            yield return new WaitForSeconds(_delayTime);
        }
    }

    private void Spawn()
    {
        var randomPosition = new Vector2(Random.Range(_rangeMin, _rangeMax), Random.Range(_rangeMin, _rangeMax));
        var enemy = Instantiate(_baseEnemySO.EnemyPrefab, randomPosition, Quaternion.identity);
        enemy.Setup(new EnemyData
        {
            BaseEnemySO = _baseEnemySO, Target = _target
        });
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}