using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    #region constants

    const string LEVEL_PREFIX = "  ";

    #endregion

    #region factory methods

    public TreeNode(T _Content)
    {
        m_Children = new List<TreeNode<T>>();
        m_Content  = _Content;
        m_Parent   = null;
    }

    public List<TreeNode<T>> Children
    {
        get { return m_Children; }
    }

    #endregion

    #region attributes

    TreeNode<T>                m_Parent;
    readonly List<TreeNode<T>> m_Children;
    T                          m_Content;

    #endregion

    #region properties

    public TreeNode<T> this[int _I]
    {
        get { return m_Children[_I]; }
    }

    public TreeNode<T> Parent
    {
        get { return m_Parent; }
        set { m_Parent = value; }
    }

    public T Content
    {
        get { return m_Content; }
        set { m_Content = value; }
    }


    public int Length
    {
        get { return m_Children.Count; }
    }


    public int Depth
    {
        get
        {
            TreeNode<T> parent = m_Parent;
            int         depth  = 0;

            while (parent != null)
            {
                parent = parent.m_Parent;
                depth++;
            }

            return depth;
        }
    }

    public TreeNode<T> Root
    {
        get
        {
            TreeNode<T> root = this;
            for (int i = 0; i < Depth; i++)
            {
                root = root.Parent;
            }

            return root;
        }
    }

    #endregion

    #region public methods

    public TreeNode<T> AddChild(T _NewChild)
    {
        TreeNode<T> newNode = new TreeNode<T>(_NewChild);

        newNode.m_Parent = this;
        m_Children.Add(newNode);
        return newNode;
    }

    public TreeNode<T> AddChild(TreeNode<T> _Node)
    {
        _Node.Parent = this;
        m_Children.Add(_Node);
        return _Node;
    }

    public override string ToString()
    {
        string result = m_Content.ToString() + Environment.NewLine;

        string prefix = "";

        for (int i = 0; i < Depth + 1; i++)
            prefix += LEVEL_PREFIX;

        foreach (var child in m_Children)
            result += prefix + " - " + child.ToString();

        return result;
    }

    public List<T> ExpandAsList()
    {
        List<T> result = new List<T>();

        if (m_Children.Count == 0)
        {
            result.Add(Content);
            return result;
        }

        foreach (var child in m_Children)
        {
            result.AddRange(child.ExpandAsList());
        }

        return result;
    }

    public void Clear()
    {
        if (m_Children == null || m_Children.Count == 0)
            return;

        foreach (TreeNode<T> child in m_Children)
            child.Parent = null;

        m_Children.Clear();
    }

    #endregion
}