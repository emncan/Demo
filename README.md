# Collision Detection With Quadtree Demo
# Describtion
A quadtree is a tree data structure in which each internal node has exactly four children. Quadtrees are the two-dimensional analog of octrees and are most often used to partition a two-dimensional space by recursively subdividing it into four quadrants or regions. The data associated with a leaf cell varies by application, but the leaf cell represents a "unit of interesting spatial information". 
# Requirements
Spawn lots of entities in the world with varying sizes. When an entity bump into another, takes 1 damage. Each entity has 5 health, when they die, spawn another entity in a random position within the tree.
# Design Patterns
Singleton design pattern used to access easily.

![demo](https://user-images.githubusercontent.com/30287266/72872091-85f46400-3cfd-11ea-8063-be00109a6dff.png)
