using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Endless Runner Level Data", menuName = "Endless Runner/Level Data")]

public class LevelData : ScriptableObject
{
    public List<Level> Levels = new List<Level>();
}
