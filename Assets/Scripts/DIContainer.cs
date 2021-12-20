using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DIContainer : MonoBehaviour
{
   private PlayerMovement _playerMovement;
   private LevelGeneration _generation;
   private StatistcSave _saves;
   private EnemyMove _enemyMove;
   private PlayerDeath _playerDeath;
   private UiHub _uiHub;
   [SerializeField] private PlayerIdentity _playerIdentity;
   [SerializeField] private PlatrformMutate platform;
   [SerializeField] private Button respawnButton;
   [SerializeField] private GameObject deadPopup;
   [SerializeField] private TextMeshProUGUI currentScoreText;
   [SerializeField] private TextMeshProUGUI deadScoreText;
   [SerializeField] private TextMeshProUGUI recordScoreText;

   private void Start()
   {
      SelfInitialise();
      SetDependences();
   }

   private void SetDependences()
   {
      _playerMovement.DI(_playerIdentity);
      _playerDeath.DI(_playerIdentity,deadPopup);
      respawnButton.onClick.AddListener(_uiHub.RespawnButton);
      _uiHub.DI(deadPopup);
      _saves.DI(currentScoreText,deadScoreText, recordScoreText);
      
      _generation.DI(platform,_saves,_playerIdentity);
      _saves.deadAction += _saves.DeadAction;
      _playerDeath.deadEvent.AddListener( _saves.deadAction);
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
