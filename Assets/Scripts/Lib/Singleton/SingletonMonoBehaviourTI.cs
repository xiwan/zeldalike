using Rui.Core.Lib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T, I> : MonoBehaviour where T : SingletonMonoBehaviour<T, I>, I
{

    private static I m_instance;
    private static readonly object m_lock = new object();
    public static bool m_appExit;


    virtual protected void Awake()
    {
        if (m_instance == null)
            m_instance = (I)((T)this);

        GameObject.DontDestroyOnLoad(gameObject);

        Debug.Assert((T)m_instance == ((T)this), string.Format("{0} is duplicated! It is a singleton!", typeof(T).Name));
    }


    public static I Instance
    {
        get
        {
            if (m_appExit)
                return default(I);

            if (m_instance != null)
                return m_instance;

            lock (m_lock)
            {
                if (m_instance != null)
                    return m_instance;

                m_instance = (I)(SingletonGameobject.Instance.GetComponent<T>());
                if (m_instance == null)
                {
                    m_instance = SingletonGameobject.Instance.AddComponent<T>();
                }
            }

            return m_instance;
        }
    }

    private static void GetSingletonGO()
    {

    }

    private void OnDestroy()
    {
        m_appExit = true;

#if UNITY_EDITOR
        Debug.LogWarning(string.Format("SingletonMonobehaviour destroyed, {0}", typeof(T).Name));
#endif
    }

}