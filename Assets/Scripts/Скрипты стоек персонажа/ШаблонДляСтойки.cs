using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ШаблонДляСтойки : MonoBehaviour
{
    SpriteRenderer MyCat;
    public Шаблонвойна воин;

    protected void StoikaNumber(int Stoika)
    {
        MyCat = GetComponent<SpriteRenderer>();
        if (воин.Stoika == Stoika)
        {
            MyCat.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            MyCat.color = new Color(1f, 1f, 1f, 0f);

        }
    }
    protected void StoikaNumberNotActive(int Stoika)
    {
        MyCat = GetComponent<SpriteRenderer>();
        if (воин.Stoika == Stoika)
        {
            MyCat.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            MyCat.color = new Color(1f, 1f, 1f, 1f);

        }
    }
}
