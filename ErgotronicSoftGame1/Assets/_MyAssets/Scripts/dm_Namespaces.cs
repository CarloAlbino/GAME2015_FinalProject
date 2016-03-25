using UnityEngine;
using System.Collections;

namespace Player
{
    // get the current status of the player
    public static class Get
    {
        public static bool Hiding()
        {
            return GameObject.FindGameObjectWithTag("Player").GetComponent<dm_SafeZone>().Hiding;
        }
    }
}