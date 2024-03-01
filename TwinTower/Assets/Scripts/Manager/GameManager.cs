using System;
using System.Collections.Generic;
using UnityEngine;

namespace TwinTower
{
    /// <summary>
    /// GameManager 클래스입니다. 게임의 전반적인 진행을 관리합니다.
    /// </summary>
    public class GameManager : Manager<GameManager>
    {
        private TileFindManager _tileFindManager;
        public Player _player;
        protected override void Awake()
        {
            _tileFindManager = TileFindManager.Instance;
            _player = GameObject.Find("PlayerControl").GetComponent<Player>();
        }

        public void Start()
        {
            
        }

        protected void FixedUpdate()
        {
            
        }
    }
}