using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    #region Singleton
    private static CollectManager _instance;

    public static CollectManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public List<Collect> AvaliableBuffs;
    public List<Collect> AvaliableDeBuffs;

    [Range(0,100)]
    public float BuffChance;

    [Range(0, 100)]
    public float DeBuffChance;
}
