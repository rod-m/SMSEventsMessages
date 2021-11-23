using UnityEngine;

namespace Singletons
{
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {
        private static bool applicationIsQuitting = false;
        private static T instance;

        public static T Instance
        {
            get
            {
                
                if (applicationIsQuitting)
                {
                    return null;
                }

                if (instance == null)
                {
                    Debug.Log($"Singleton Init One OFF!");
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public virtual void OnDestroy()
        {
            Debug.Log("Gets destroyed");
           applicationIsQuitting = true;
           // do some save state to file or player prefs?
        }
    }
}