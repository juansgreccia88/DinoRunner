using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Avatar/Setting", fileName = "AvatarData")]
public class AvatarSetting : ScriptableObject
{
    [SerializeField] private float jumpVelocity;

    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;

    public float JumpVelocity { get { return jumpVelocity; } }
    public float FallMultiplier { get { return fallMultiplier; } }
    public float LowJumpMultiplier { get { return lowJumpMultiplier; } }

}
