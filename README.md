Basic Implementation of QuadTree in .NET

This code is inspired from a Youtube Series

[Coding Challenge #98.1: Quadtree - Part 1](https://www.youtube.com/watch?v=OJxEcs0w_kE&t=0s)

[Coding Challenge #98.2: Quadtree - Part 2](https://www.youtube.com/watch?v=QQx_NmCIuCY&t=0s)

[Coding Challenge #98.3: Quadtree Collisions - Part 3](https://www.youtube.com/watch?v=z0YFFg_nBjw&t=0s)

Every node in a quad tree contains a boundary. It can be a rectangle, circle etc. Here the implementation is with a rectangle.

A rectangle boundary can be created with left top coordinate and right bottom coordinate. Another way is with a center coordinate and half width dimension and half length dimension.

A quad tree can store at max a capacity set of points. (capacity initialized before creating the quad tree). If we get more points than capacity, that means we have to divide the quad tree into 4 sections and the new points go there. If not, that quad tree node is called a leaf node and we don't have to search for points below it.

This helps a lot in search, and let's say if we want to search for a point in the tree. Every time we go down, we divide the problem by 4. (If the points are evenly splattered across the boundary). We can do the search in logn.

We can also query for a boundary in a quadtree. 

The algo is something like this:

	1. Check if the boundary intersects the quadtree boundary
	2. If not, get back.
	3. If intersects, check if the points in the current quadtree boundary are part of the boundary that we need to search for.
	4. Add those points to array, and search recursively for each of the 4 sub quadtrees from step 1.
	5. Return the whole array.


This eliminates a lot of points from the search which are part of the sub quadtrees which do not intersect with the boundary to search for.

