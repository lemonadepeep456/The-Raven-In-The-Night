using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;

    public void UseItem()
    {
        if(statToChange == StatToChange.health)
        {
            GameObject.Find("Player").GetComponent<HealthManager>().ChangeHealth(amountToChangeStat);
            Debug.Log("Health updated!");
           



        }
    }
    

    public enum StatToChange
    {
        none,
        hunger,
        health,
        thirst,
    };

    public enum AttributeToChange
    {
        none,
        strength,
        speed,
        defense,
    };

}
