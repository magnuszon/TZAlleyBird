using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGeneration : MonoBehaviour
{
   [SerializeField] private int maximumPlatforms;
   [SerializeField] private float platformsDistance;
   [SerializeField] private float baseLevelDownSpeed;
   [SerializeField] private float secondAdditionalSpeed;
   private List<Transform> platforms = new List<Transform>();
   [SerializeField] private float totalSpeed;
   [SerializeField] private Transform mapHub;
   
   private GameObject platform;
   private float spawnTimer;
   private StatistcSave _save;
   private Transform _playerTransform;

   private void AltStart()
   {
     StartGeneration();
     totalSpeed = baseLevelDownSpeed;
   }

   private void Update()
   {
       MovePlatforms();

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
