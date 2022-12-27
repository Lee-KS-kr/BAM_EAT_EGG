using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mizu;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Inst => instance;
    private GameManager() { }

    public BamManager BamMng { get; private set; }
    public UIManager UIMng { get; private set; }
    public ObjectPool ObjectPool { get; private set; }
    public ObjectPool ScoreUIPool { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        BamMng = FindObjectOfType<BamManager>();
        UIMng = FindObjectOfType<UIManager>();
        ObjectPool = GameObject.Find("BAMPool").GetComponent<ObjectPool>();
        ScoreUIPool = GameObject.Find("ScroePool").GetComponent<ObjectPool>();
    }
}
