In computer science, an AVL tree (named after inventors Adelson-Velsky and Landis) is a self-balancing binary search tree. In an AVL tree, the heights of the two child subtrees of any node differ by at most one; if at any time they differ by more than one, rebalancing is done to restore this property. Lookup, insertion, and deletion all take O(log n) time in both the average and worst cases, where 
�
n is the number of nodes in the tree prior to the operation. Insertions and deletions may require the tree to be rebalanced by one or more tree rotations.

The AVL tree is named after its two Soviet inventors, Georgy Adelson-Velsky and Evgenii Landis, who published it in their 1962 paper "An algorithm for the organization of information".[2] It is the oldest self-balancing binary search tree data structure to be invented.[3]

AVL trees are often compared with red–black trees because both support the same set of operations and take 
O
(
log
⁡
�
)
{\displaystyle {\text{O}}(\log n)} time for the basic operations. For lookup-intensive applications, AVL trees are faster than red–black trees because they are more strictly balanced.[4] Similar to red–black trees, AVL trees are height-balanced. Both are, in general, neither weight-balanced nor 
�\mu -balanced for any 
�
≤
1
2
{\displaystyle \mu \leq {\tfrac {1}{2}}};[5] that is, sibling nodes can have hugely differing numbers of descendants.

more https://en.wikipedia.org/wiki/AVL_tree
