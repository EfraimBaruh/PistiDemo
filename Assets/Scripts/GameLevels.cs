using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/GameLevels")]
public class GameLevels : ScriptableObject
{
    public List<GameLevel> levels;
}
