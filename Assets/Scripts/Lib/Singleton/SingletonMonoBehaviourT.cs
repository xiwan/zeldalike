
using Rui.Core.Lib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    private static T m_instance;
    private static readonly object m_lock = new object();
    public static bool m_appExit;

    virtual protected void Awake()
    {
        if (m_instance != null)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        m_instance = (T)this;
        GameObject.DontDestroyOnLoad(gameObject);
        Debug.Assert(m_instance == this, string.Format("{0} is duplicated! It is a singleton!", typeof(T).Name));
    }


    public static T Instance
    {
        get
        {
            //if (m_appExit)
            //    return null;

            if (m_instance != null)
                return m_instance;

            lock (m_lock)
            {
                if (m_instance != null)
                    return m_instance;

                m_instance = SingletonGameobject.Instance.GetComponent<T>();
                if (m_instance == null)
                {
                    m_instance = SingletonGameobject.Instance.AddComponent<T>();
                }
            }

            return m_instance;
        }
    }

    private void OnDestroy()
    {
        m_appExit = true;

#if UNITY_EDITOR
        Debug.LogWarning(string.Format("SingletonMonobehaviour destroyed, {0}", typeof(T).Name));
#endif
    }
}
