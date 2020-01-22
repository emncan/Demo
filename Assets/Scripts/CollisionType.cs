using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionType 
{
    /// <summary>
    /// First frame of collision
    /// </summary>
    Enter,

        /// <summary>
        /// Collision occuring over multiple frames
        /// </summary>
        Stay,

        /// <summary>
        /// First frame collision is no longer occuring
        /// </summary>
        Exit
}
