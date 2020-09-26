using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "Resource", order = 1)]
public class Resource : ScriptableObject
{
    public int Amount;
    public Text Counter;
    public Sprite Sprite;
}