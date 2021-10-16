using System.Collections;
using Main.Scripts.Enemy.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Main.Scripts.Core
{
    public class SpawnerManager : MonoBehaviour
    {
        [FoldoutGroup("Scriptable Object"), InlineEditor(), SerializeField]
        private BaseEnemySO _baseEnemySO;

        private Transform _target;

        [SerializeField] private bool _repeatingSpawn = true;
        [FoldoutGroup("Settings"), ShowIf(nameof(_repeatingSpawn)), SerializeField]
        private float _delaySpawnTime = 3;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag(TagConstants.Player).transform;

            if (_repeatingSpawn)
            {
                StartCoroutine(SpawnRoutine());
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

        private IEnumerator SpawnRoutine()
        {
            while (_repeatingSpawn)
            {
                Spawn();
                yield return new WaitForSeconds(_delaySpawnTime);
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}