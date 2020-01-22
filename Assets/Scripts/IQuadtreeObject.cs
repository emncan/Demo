using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuadtreeObject 
{
    Vector2 Position { get; }
    bool QuadTreeIgnore { get; }
}
