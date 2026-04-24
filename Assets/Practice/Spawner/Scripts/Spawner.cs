using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
        [SerializeField] private Enemy _enemyPrefab;
        
        private readonly float _spawnCooldownInSeconds = 2f;
        private readonly float _spawnRadius = 2f;

        private void OnEnable()
        {
                StartCoroutine(SpawnCoroutine());
        }
        
        private IEnumerator SpawnCoroutine()
        {
                SpawnEnemy();
                yield return new WaitForSeconds(_spawnCooldownInSeconds);
                StartCoroutine(SpawnCoroutine());
        }
        
        private void SpawnEnemy()
        {
                var spawnPoint = GetRandomPointInSpawnArea();
                
                var enemy = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity, transform);
                
                enemy.SetDirection(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        }

        private Vector3 GetRandomPointInSpawnArea()
        {
                float radius = Random.Range(0f, _spawnRadius);
                float angle =  Random.Range(0f, Mathf.PI * 2f);
                
                Vector3 spawnPoint = transform.position + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
                return spawnPoint;
        }
        
        
}
