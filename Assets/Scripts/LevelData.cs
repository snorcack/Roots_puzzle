using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public int[,] tileSet = new int [18,11];
    public int LevelNumber;

}
