using UnityEngine;

public class TreeNode
{
    public int value;
    public TreeNode left, right;
    public TreeNode(int val) { value = val; }
}

public class StudyBST : MonoBehaviour
{
    private TreeNode root;
    private string result;

    void Start()
    {
        int[] values = { 12, 8, 17, 4, 9, 13, 21, 2 };
        foreach (int val in values)
        {
            Insert(val);
        }
        
        InOrderPrint(root);
        Debug.Log(result);
        result = string.Empty;
        
        Insert(10);
        InOrderPrint(root);
        Debug.Log(result);
        result = string.Empty;
    }

    // 값 삽입 함수
    void Insert(int val)
    {
        root = InsertRecursive(root, val);
    }

    TreeNode InsertRecursive(TreeNode node, int val)
    {
        if (node == null)
        {
            return new TreeNode(val);
        }

        if (val < node.value)
        {
            Debug.Log($"  {val} < {node.value} : {node.value}의 왼쪽으로 이동");
            node.left = InsertRecursive(node.left, val);
        }
        else
        {
            Debug.Log($"  {val} > {node.value} : {node.value}의 오른쪽으로 이동");
            node.right = InsertRecursive(node.right, val);
        }
        return node;
    }

    // 중위(In-order) 순회(트리 구조 확인용)
    void InOrderPrint(TreeNode node)
    {
        if (node == null)
            return;
        
        InOrderPrint(node.left);
        result += $"{node.value} ";
        InOrderPrint(node.right);
    }
}