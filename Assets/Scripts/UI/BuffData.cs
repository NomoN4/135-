using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Game/Buff")]
public class BuffData : ScriptableObject
{
    public string buffName;

    public Sprite icon;

    public BuffType buffType;
    public float value;
}

public enum BuffType
{
    AddJump,
    Attackup,
    Barrier,
    MoveSpeed,
    MaxHP,
    AttackRange1
}