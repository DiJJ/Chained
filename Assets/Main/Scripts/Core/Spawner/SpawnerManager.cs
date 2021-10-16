using Main.Scripts.Core;
using Main.Scripts.Enemy.Data;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [FoldoutGroup("Scriptable Object"), SerializeField] private BaseEnemySO _baseEnemySO;
    private Transform _target;
    [SerializeField] private bool _repeatingSpawn = false;
    [FoldoutGroup("Settings"), HideIf(nameof(_repeatingSpawn)), SerializeField] private float _startTime = 1;
    [FoldoutGroup("Settings"), HideIf(nameof(_repeatingSpawn)), SerializeField] private float _repeatTime = 3;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(TagConstants.Player).transform;
        
        if (_repeatingSpawn == false)
        {
            InvokeRepeating(nameof(Spawn), _startTime, _repeatTime);
            return;
        }

        Spawn();
    }

    private void Spawn()
    {
        var enemy = Instantiate(_baseEnemySO.EnemyPrefab, transform.position, Quaternion.identity);
        enemy.Setup(new EnemyData
        {
            BaseEnemySO = _baseEnemySO, 
            Target = _target
        });
    }
}