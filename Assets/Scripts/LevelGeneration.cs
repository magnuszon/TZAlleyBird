using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGeneration : MonoBehaviour
{
   //generation pattern
   [SerializeField] private int maximumPlatforms;
   [SerializeField] private float platformsDistance;
   [SerializeField] private float minimumPlatformY;
   private List<Transform> platforms = new List<Transform>();
   [SerializeField] private float platformDownMove=0.5f;
   
   private GameObject platform;
   private float spawnTimer;
   private StatistcSave _save;

   private void Start()
   {
     StartGeneration();
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.W))
       {
           Regenerate();
       }
   }

   private void StartGeneration()
   {
    
       Vector3 rootPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, -Camera.main.transform.position.z));
       rootPoint.z = 0;
       for (int i = 0; i < maximumPlatforms; i++)
       {
           GameObject newplatform = Instantiate(platform, rootPoint + (Vector3.down * platformsDistance*i),Quaternion.identity);
           newplatform.GetComponent<PlarformMutate>().DI(_save,this);
           newplatform.GetComponent<PlatformMove>().DI(platformDownMove);
           platforms.Add(newplatform.transform);
       }
   }
   private void Regenerate()
   {
       platforms[platforms.Count - 1].position = platforms[0].position + Vector3.up * platformsDistance;
       platforms[platforms.Count - 1].GetComponent<PlarformMutate>().Reload();
       platforms.Insert(0,platforms[platforms.Count - 1]);
       platforms.RemoveAt(platforms.Count - 1);
   }

   private void Test()
   {
       Debug.Log("test");
   }

   public void DI(GameObject platform, StatistcSave _save)
   {
      this.platform = platform;
      this._save = _save;
   }
}
