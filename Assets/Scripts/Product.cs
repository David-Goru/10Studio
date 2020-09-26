using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Product", order = 3)]
public class Product : ScriptableObject
{
    public GameObject Model;
    public Sprite Sprite;
}