using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus : Collect
{
    public float NewWidth = 15;

    protected override void ApplyEffect()
    {
        if (Platform.Instance != null && !Platform.Instance.IsTransforming)
        {
            Platform.Instance.StartWidthAnimation(NewWidth);
        }
    }
}
