using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : Singleton<TestScript>
{
    [SerializeField]
    private CoreObject coreObject;

   [SerializeField]
    private int MaxBodies = 100;
    
    private Vector2 WorldSize = new Vector2(100, 100);
    private int BodiesPerNode = 2;
    private int MaxSplits = 12;

    public QuadTree _quadTree;
    private List<IQuadtreeObject> _quadTreeBodies = new List<IQuadtreeObject>();
    private CollisionSystemQuadTree _csQuad;
   

    private void Start()
    {
        _quadTree = new QuadTree(new Rect(0, 0, WorldSize.x, WorldSize.y), BodiesPerNode, MaxSplits);
        _csQuad = new CollisionSystemQuadTree(_quadTree);
        AddObject();
    }
    public void AddObject()
    {        
             
        for (int i = 0; i < MaxBodies; i++)
        {
            var body = GameObject.Instantiate<CoreObject>(coreObject);
            body.transform.position = new Vector3(Random.Range(0, WorldSize.x), 0, Random.Range(0, WorldSize.y));
            body.life = 5;
            body.gameObject.tag = "clone";
            _csQuad.AddBody(body);
            _quadTree.AddBody(body); // add body to QuadTree
            _quadTreeBodies.Add(body); // cache bodies so we can refresh the tree in update
        }
    }
    private void Update()
    {
        _csQuad.Step();
        _quadTree.Clear();
        foreach (var b in _quadTreeBodies)
        {
            _quadTree.AddBody(b);
        }
    }

    public void CreateNewObject(int value)
    {
        if (coreObject == null)
        {
            coreObject = Resources.Load<CoreObject>("Prefabs/CoreObject");
        }
        for (int i = 0; i < value; i++)
        {
            var body = GameObject.Instantiate<CoreObject>(coreObject);
            body.transform.position = new Vector3(Random.Range(0, WorldSize.x), 0, Random.Range(0, WorldSize.y));
            body.life = 5;
            body.gameObject.tag = "clone";
            _csQuad.AddBody(body);
            _quadTree.AddBody(body); // add body to QuadTree
            _quadTreeBodies.Add(body); // cache bodies so we can refresh the tree in update
        }
    }
    private void OnDrawGizmos()
    {
        if (_quadTree == null) return;
        _quadTree.DrawGizmos();
    }
}
