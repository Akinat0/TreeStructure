using System;
using System.Collections.Generic;

namespace TreeTest
{
    public class TreeNode<T>
    {
        private const string LEVEL_PREFIX = "  ";
        
        private TreeNode<T> m_Parent;
        private LinkedList<TreeNode<T>> m_Children;
        private T m_Content;

        public TreeNode<T> Parent
        {
            get
            {
                return m_Parent;
            }
        }
        public T Content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }
        public TreeNode(T _Content)
        {
            m_Children = new LinkedList<TreeNode<T>>();
            m_Content = _Content;
            m_Parent = null;
        }
        public int Deep
        {
            get
            {
                TreeNode<T> parent = m_Parent;
                int deep = 0;
            
                while (parent != null)
                {
                    parent = parent.m_Parent;
                    deep++;
                }

                return deep;
            }
        }
        public int Length
        {
            get { return m_Children.Count; }
        }

        public TreeNode<T> Root
        {
            get
            {
                TreeNode<T> root = this;
                for (int i = 0; i < Deep; i++)
                {
                    root = root.Parent;
                }

                return root;
            }
        }

        public TreeNode<T> AddChild(T _NewChild)
        {
            TreeNode<T> newNode = new TreeNode<T>(_NewChild);
            
            newNode.m_Parent = this;
            
            m_Children.AddLast(newNode);
            return newNode;
        }

        public TreeNode<T> AddChild(TreeNode<T> node)
        {
            SetParent(this);
            m_Children.AddLast(node);
            return node;
        }

        public override string ToString()
        {
            string result = m_Content.ToString() + Environment.NewLine;

            string prefix = "";
            
            for (int i = 0; i < Deep + 1; i++)
                prefix += LEVEL_PREFIX;

            foreach (var child in m_Children)
                result += prefix + " - " +child.ToString();

            return result;
        }

        public void Clear()
        {
            if (m_Children == null || m_Children.Count == 0)
                return;
            
            foreach (TreeNode<T> child in m_Children)
                child.SetParent(null);

            m_Children.Clear();
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
        
        public void SetParent(TreeNode<T> _Parent)
        {
            m_Parent = _Parent;
        }
        
    }
}