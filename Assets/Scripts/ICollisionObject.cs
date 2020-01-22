﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionObject 
{
    int RefId { get; set; }

    /// <summary>
    /// Skip this body when testing for collisions
    /// </summary>
    bool Sleeping { get; }

    /// <summary>
    /// The body's collision shape
    /// </summary>
    ICollisionShape CollisionShape { get; }

    /// <summary>
    /// Called each frame of collision
    /// </summary>
    /// <param name="result"></param>
    /// <param name="other"></param>
    void OnCollision(CollisionResult result, ICollisionObject other);
}
