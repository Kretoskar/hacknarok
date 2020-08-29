﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class Timer : MonoBehaviour
    {
        #region Singleton
        
        
        private static Timer _instance;

        public static Timer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Timer>();
                    if (_instance == null)
                    {
                        GameObject container = new GameObject("Timer");
                        _instance = container.AddComponent<Timer>();
                    }
                }

                return _instance;
            }
        }
        
        #endregion
        
        [SerializeField] private float _maxTime = 120;
        [SerializeField] private Image _fillImage;

        private PlayerAnimations _playerAnimations;
        private float _currTime;

        void Start()
        {
            _currTime = _maxTime;

            _playerAnimations = FindObjectOfType<PlayerAnimations>();
        }
        
        void Update()
        {
            _currTime -= Time.deltaTime;

            UpdateUI();
        }

        public void GetDamage(int damage)
        {
            _currTime -= damage;
            
            _playerAnimations.HurtAnim();
        }
        
        void UpdateUI()
        {
            _fillImage.fillAmount = _currTime / _maxTime;
        }
    }
}