using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DIContainer : MonoBehaviour
{
   private PlayerMovement _playerMovement;
   private LevelGeneration _generation;
   private StatistcSave _saves;
   private EnemyMove _enemyMove;
   private PlayerDeath _playerDeath;
   private UiHub _uiHub;
   [SerializeField] private GameObject player;
   [SerializeField] private GameObject platform;
   [SerializeField] private Button respawnButton;
   [SerializeField] private GameObject deadPopup;
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI maxScoreDeadText;
   [SerializeField] private TextMeshProUGUI recordScoreText;
   
   private void Awake()
   {
      SelfInitialise();
   }

   private void Start()
   {
      SetDependences();
   }

   private void SetDependences()
   {
      _playerMovement.DI(player);
      _generation.DI(platform,_saves);
      _playerDeath.DI(player.transform);
      respawnButton.onClick.AddListener(_uiHub.RespawnButton);
      _playerDeath.onDead.AddListener(_uiHub.ShowDeadPopup);
      _uiHub.DI(deadPopup);
      _saves.DI(scoreText,maxScoreDeadText, recordScoreText);
   }

   private void SelfInitialise()
   {
      _playerMovement = GetComponent<PlayerMovement>();
      _generation = GetComponent<LevelGeneration>();
      _saves = GetComponent<StatistcSave>();
      _enemyMove = GetComponent<EnemyMove>();
      _playerDeath = GetComponent<PlayerDeath>();
      _uiHub = GetComponent<UiHub>();
   }

}
