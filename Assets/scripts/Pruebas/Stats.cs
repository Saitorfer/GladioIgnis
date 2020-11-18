using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField]
    //usaré esta classe si meto daño despues
    public int baseValue;
    private List<int> modifiers = new List<int>();
    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return baseValue;
    }

    //de momento no lo utilizo, pero igual despues le doy utilidad
    public void AddModifiers(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifiers(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}
