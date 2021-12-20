﻿// -------------------------------------------------------------------------------------------
// The MIT License
// Singleton for Unity https://github.com/MeeXaSiK/NightSingleton
// Copyright (c) 2021 Night Train Code
// -------------------------------------------------------------------------------------------

using UnityEngine;

namespace NTC.Global.System
{
    public class Singleton<TSingleton> : MonoBehaviour where TSingleton : MonoBehaviour
    {
        public static TSingleton Instance
        {
            get
            {
                if (cachedInstance == null)
                {
                    if (isQuitting) return null;

                    var instances = FindObjectsOfType<TSingleton>();
                    var instance = instances.Length > 0 
                        ? instances[0] 
                        : new GameObject($"[Singleton] {typeof(TSingleton).Name}").AddComponent<TSingleton>();

                    for (var i = 1; i < instances.Length; i++)
                    {
                        Destroy(instances[i]);
                    }

                    return cachedInstance = instance;
                }

                return cachedInstance;
            }
        }
        
        private static TSingleton cachedInstance;
        private static bool isQuitting;

        private void OnApplicationQuit()
        {
            isQuitting = true;
            OnApplicationExit();
        }
        
        protected virtual void OnApplicationExit() { }
    }
}