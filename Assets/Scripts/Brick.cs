using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Brick : MonoBehaviour
{
    private SpriteRenderer sr;

    public int Hitpoints = 1;
    public ParticleSystem DestroyEffect;

    public static event Action<Brick> OnBrickDestruction;

    private void Awake()
    {
       this.sr = this.GetComponent<SpriteRenderer>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        AppplyCollisionLogic(ball);
    }

    private void AppplyCollisionLogic(Ball ball)
    {
        this.Hitpoints--;

        if (this.Hitpoints <= 0)
        {
            BrickManager.Instance.RemainingBricks.Remove(this);
            OnBrickDestruction?.Invoke(this);
            OnBrickDestroy();
            SpawnDestroyEffect();
            Destroy(this.gameObject);
        }
        else
        {
            this.sr.sprite = BrickManager.Instance.Sprites[this.Hitpoints - 1];
        }

    }

    private void OnBrickDestroy()
    {
        float buffSpawnChanse = UnityEngine.Random.Range(0, 100f);
        float deBuffSpawnChanse = UnityEngine.Random.Range(0, 100f);
        bool alreadySpawned = false;

        if (buffSpawnChanse <= CollectManager.Instance.BuffChance)
        {
            alreadySpawned = true;
            Collect newBuff = this.SpawnCollectiable(true);
        }
        if (deBuffSpawnChanse <= CollectManager.Instance.DeBuffChance && !alreadySpawned)
        {
            Collect newDeBuff = this.SpawnCollectiable(false);
        }
    }

    private Collect SpawnCollectiable(bool Buff)
    {
        List<Collect> collection;

        if (Buff)
        {
            collection = CollectManager.Instance.AvaliableBuffs;
        }
        else
        {
            collection = CollectManager.Instance.AvaliableDeBuffs;
        }

        int buffIndex = UnityEngine.Random.Range(0, collection.Count);
        Collect prefab = collection[buffIndex];
        Collect newCollectable = Instantiate(prefab, this.transform.position, Quaternion.identity) as Collect;

        return newCollectable;
    }

    private void SpawnDestroyEffect()
    {
        Vector3 brickPos = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(brickPos.x, brickPos.y, brickPos.z - 0.2f);
        GameObject effect = Instantiate(DestroyEffect.gameObject, spawnPosition, Quaternion.identity);

        MainModule mm = effect.GetComponent<ParticleSystem>().main;
        mm.startColor = this.sr.color;
        Destroy(effect, DestroyEffect.main.startLifetime.constant);
    }

    public void Init(Transform containerTransform, Sprite sprite, Color color, int hitpoints)
    {
        this.transform.SetParent(containerTransform);
        this.sr.sprite = sprite;
        this.sr.color = color;
        this.Hitpoints = hitpoints;

    }
}
