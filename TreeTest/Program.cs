using System.Globalization;

namespace TreeTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            TreeNode<string> tree= new TreeNode<string>("root");
            
//            tree.AddChild(new TreeNode<string>("root/man")).AddChild("root/man/gay");
            TreeNode<string> child = tree.AddChild("root/woman");

            child.AddChild("penid");
            child.AddChild("penisis");
            child.AddChild("hui");
            var lastChild = child.AddChild("root/woman/sex").AddChild("root/woman/sex/dirty");
            
            lastChild.AddChild("root/woman");
            lastChild.AddChild("root/woman");
            lastChild.AddChild("root/woman");
            lastChild.AddChild("root/woman");
            lastChild.AddChild("root/woman");
            
            System.Console.WriteLine(tree.ToString());

           
           foreach (var content in tree.ExpandAsList())
           {
               System.Console.WriteLine(content);
           } 
        }
    }
}