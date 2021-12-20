using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelGeneration : MonoBehaviour
{
   [SerializeField] private int maximumPlatforms;
   [SerializeField] private float platformsDistance;
   [SerializeField] private float baseLevelDownSpeed;
   [SerializeField] private float secondAdditionalSpeed;
   private List<Transform> platforms = new List<Transform>();
   [SerializeField] private float totalSpeed;
   [SerializeField] private Transform mapHub;
   [SerializeField] private float enemySpawnRate;
   [SerializeField] private List<EnemyParams> enemies;
   
   private GameObject platform;
   private float spawnTimer;
   private StatistcSave _save;
   private Transform _playerTransform;
   [SerializeField]private float timeToSpawn=10;

   private void AltStart()
   {
     StartGeneration();
     totalSpeed = baseLevelDownSpeed;
   }

   private void Update()
   {
       MovePlatforms();
       if (timeToSpawn > 0)
       {
           timeToSpawn -= Time.deltaTime;
       }

   }

   private void MovePlatforms()
   {
       totalSpeed +=  secondAdditionalSpeed*Time.deltaTime ;
       for (int i = 0; i < platforms.Count; i++)
       {
           platforms[i]. transform.position += Vector3.down* (totalSpeed* Time.deltaTime);
       }
      
   }

   private void StartGeneration()
   {
    
       Vector3 rootPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, -Camera.main.transform.position.z));
       rootPoint.z = 0;
       for (int i = 0; i < maximumPlatforms; i++)
       {
           GameObject newplatform = Instantiate(platform, rootPoint + (Vector3.down * platformsDistance*i),Quaternion.identity,mapHub);
           newplatform.GetComponent<PlatrformMutate>().DI(_save,this);
           newplatform.name = "platform" + i;
           platforms.Add(newplatform.transform);
          
       }
   }
   public void ResortPlatforms()
   {
       platforms[platforms.Count - 1].position = platforms[0].position + Vector3.up * platformsDistance;
       platforms.Insert(0,platforms[platforms.Count - 1]);
       platforms.RemoveAt(platforms.Count - 1);
       if (timeToSpawn <=0)
       {
           TrySpawnEnemy();
       }
   }

   private void TrySpawnEnemy()
   {
       if (enemySpawnRate > Random.Range(0, 100))
       {
           platforms[0].GetComponent<PlatrformMutate>().SpawnRandomEnemy(enemies[Random.Range(0,enemies.Count)].gameObject);
       }
   }

   public void DI(PlatrformMutate platform, StatistcSave _save, PlayerIdentity playerIdentity)
   { 
       this.platform = platform.gameObject;
      this._save = _save;
      this._playerTransform = playerIdentity.transform;
      AltStart();
      UpdatePlayerDependence();
   }

   private void UpdatePlayerDependence()
   {
       for (int i = 0; i < platforms.Count; i++)
       {
           if (platforms[i].transform.position.y > _playerTransform.position.y)
           {
               platforms[i].GetComponent<PlatrformMutate>().Reload(false);
           }
       }
   }
}
