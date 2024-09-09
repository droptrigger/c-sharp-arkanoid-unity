using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            this.ApplyEffect();
        }
        if (collision.tag == "Platform" || collision.tag == "Death")
        {
            Destroy(this.gameObject);
        }
    }

    protected abstract void ApplyEffect();
}
