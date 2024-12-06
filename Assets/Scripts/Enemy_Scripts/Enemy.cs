using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Create New Enemy")]
public class Enemy : ScriptableObject
{
    public int maxHp;
    public int baseATK;
    public int Score;
}
