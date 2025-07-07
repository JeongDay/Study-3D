using UnityEngine;

// 이진 탐색 트리 노드
public class BSTNode
{
    public int Value;
    public BSTNode Left;
    public BSTNode Right;

    public BSTNode(int value)
    {
        Value = value;
    }
}

// 이진 탐색 트리 구현
public class BinarySearchTree
{
    public BSTNode Root;

    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private BSTNode InsertRecursive(BSTNode node, int value)
    {
        if (node == null)
            return new BSTNode(value);

        if (value < node.Value)
            node.Left = InsertRecursive(node.Left, value);
        else
            node.Right = InsertRecursive(node.Right, value);

        return node;
    }

    public bool Search(int value)
    {
        return SearchRecursive(Root, value);
    }

    private bool SearchRecursive(BSTNode node, int value)
    {
        if (node == null) return false;
        if (node.Value == value) return true;
        return value < node.Value
            ? SearchRecursive(node.Left, value)
            : SearchRecursive(node.Right, value);
    }

    public void InOrder(BSTNode node, System.Action<int> visit)
    {
        if (node == null) return;
        InOrder(node.Left, visit);
        visit(node.Value);
        InOrder(node.Right, visit);
    }
}

// 사용 예시
public class StudyAlgorithm : MonoBehaviour
{
    void Start()
    {
        var bst = new BinarySearchTree();
        int[] values = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
        foreach (var v in values)
            bst.Insert(v);

        Debug.Log("Search 7: " + bst.Search(7));
        Debug.Log("Search 5: " + bst.Search(5));

        Debug.Log("InOrder Traversal:");
        bst.InOrder(bst.Root, v => Debug.Log(v));
    }
}