// ----------------------------------------------------------------
// The MIT License
// Singleton for Unity https://github.com/MeeXaSiK/NightSingleton
// Copyright (c) 2021-2023 Night Train Code
// ----------------------------------------------------------------

using UnityEngine;

namespace NTC.Singleton
{
    public abstract class Singleton<TSingleton> : MonoBehaviour where TSingleton : Singleton<TSingleton>
    {
        [Header("Singleton")]
        [SerializeField] private bool _dontDestroyOnLoad;
        
        private static readonly object s_securityLock = new object();
        private static TSingleton s_cachedInstance;
        
        /// <summary>
        /// Returns a singleton instance.
        /// </summary>
        public static TSingleton Instance
        {
            get
            {
                if (Application.isPlaying == false)
                {
#if DEBUG
                    Debug.LogError($"[Singleton] <{typeof(TSingleton)}> - " +
                                   "instance will not be returned because the application is not playing!");
#endif
                    return null;
                }

                if (s_cachedInstance != null)
                {
                    return s_cachedInstance;
                }
                
                lock (s_securityLock)
                {
                    if (s_cachedInstance == null)
                    {
                        s_cachedInstance = FindInstance();
                    }
                }

                return s_cachedInstance;
            }
        }

        private static TSingleton FindInstance()
        {
            var allInstances = FindObjectsOfType<TSingleton>();
            var className = typeof(TSingleton).Name;
            var count = allInstances.Length;
            var instance = count > 0
                ? allInstances[0]
                : new GameObject($"[Singleton] {className}").AddComponent<TSingleton>();
            
            if (count > 1)
            {
                for (var i = 1; i < count; i++)
                {
                    Destroy(allInstances[i]);
                }
#if DEBUG
                Debug.LogError($"The number of <{className}> on the scene is greater than one!");
#endif
            }

            return instance;
        }

        private void Awake()
        {
            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            
            OnAwake();
        }

        protected virtual void OnAwake() { }
    }
}