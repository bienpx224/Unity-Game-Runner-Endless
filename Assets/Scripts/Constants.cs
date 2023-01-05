using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public enum GameState
    {
        IS_READY, IS_PLAYING, IS_STOPPED, IS_ENDED
    };
    public enum PlayerState
    {
        IS_IDLE, IS_PLAYING, IS_DEAD, IS_COLLISION, IS_JUMPING, IS_JOKING
    }
}