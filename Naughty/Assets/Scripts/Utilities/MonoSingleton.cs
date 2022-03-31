using UnityEngine;

namespace Utilities
{
    // this code originate from https://wiki.unity3d.com/index.php/Singleton

    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool isShuttingDown = false;
        private static object lookObject = new object();
        private static T instance;

        public static T Instance
        {
            get
            {
                if (isShuttingDown)
                {
                    return null;
                }

                lock (lookObject)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();

                        if (instance == null)
                        {
                            var singleton = new GameObject();
                            instance = singleton.AddComponent<T>();
                            singleton.name = instance.GetType().Name;
                        }
                    }

                    return instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void OnApplicationQuit()
        {
            isShuttingDown = true;
        }

        private void OnDestroy()
        {
            isShuttingDown = true;
        }
    }
}