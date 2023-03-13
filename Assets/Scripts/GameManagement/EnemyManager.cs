using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public class EnemyManager : MonoBehaviour
    {
        #region Properties
        public static EnemyManager Instance;

        #region Public
        public int killCounter { get; private set; }
        public bool GameOver { get; private set; }
        #endregion

        #region Private
        private List<Enemy> _activeEnemies = new List<Enemy>();
        #endregion

        #region Editor

        [SerializeField]
        [Tooltip("Enemies prefab list")]
        private Enemy[] _enemies;

        /// <summary>
        /// Simultaneously active enemies on stage
        /// </summary>
        [SerializeField]
        [Range(0f, 150f)]
        [Tooltip("Simultaneously active enemies on stage")]
        private int _maxActiveEnemies;
        #endregion

        #region Events
        public delegate void OnValueChanged(int value);
        public OnValueChanged onKillChanged;
        #endregion

        #endregion

        #region Methods

        #region Unity
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameManager.Instance.OnGameStarted += InitEnemies;
        }

        #endregion

        #region Public
        public void Spawn()
        {
            Enemy e = Instantiate(_enemies[Random.Range(0, _enemies.Length)], 
                GetRandomPoint(), Quaternion.identity, transform);
            _activeEnemies.Add(e);
        }

        public void PlusKill()
        {
            killCounter++;
            onKillChanged?.Invoke(killCounter);
        }

        public void DeInit(Enemy e)
        {
            _activeEnemies.Remove(e);
            GameOver = _activeEnemies.Count <= 0;
        }
        #endregion

        #region Private
        private void InitEnemies()
        {
            killCounter = 0;
            for(int i = 0; i < _maxActiveEnemies; i++)
            {
                Spawn();
            }
        }
        private Vector3 GetRandomPoint()
        {
            return Random.onUnitSphere * 4;
        }
        #endregion

        #endregion
    }
}