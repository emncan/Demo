using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreObject : MonoBehaviour, ICollisionObject, IQuadtreeObject
{
    public int life = 5;
    public static int numberofhide= 0;
    private ICollisionShape _shape;
    private Color _gizmoColor = Color.green;
    
    private void Awake()
    {
        var collider = GetComponent<BoxCollider>();
        _shape = new BoxShape(collider.bounds, false);
        _shape.Center = transform.position;
        
    }

    private void Update()
    {
        _shape.Center = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 1.25f);
    }
   

    #region ICollisionBody

    public int RefId { get; set; }

    public bool Sleeping { get { return false; } }

    public ICollisionShape CollisionShape { get { return _shape; } }

    public void OnCollision(CollisionResult result, ICollisionObject other)
    {
        _gizmoColor = result.Type == CollisionType.Exit ? Color.green : Color.red;
        
        if(result.Type == CollisionType.Enter)
        { 
            life--;
            if (life == 0)
            {
                gameObject.SetActive(false);
                numberofhide++;
            }
        }
      
    }

    #endregion

    #region IQuadTreeBody

    public Vector2 Position { get { return new Vector2(transform.position.x, transform.position.z); } }
    public bool QuadTreeIgnore { get { return false; } }

    #endregion

}
