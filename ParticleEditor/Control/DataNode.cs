namespace ParticleEditor.Control
{
    public class DataNode
    {
        protected TreeNode Node;
        protected List<DataNode> Children;

        public DataNode(string name)
        {
            Node = new TreeNode(name);
            Node.Tag = this;
            Children = new List<DataNode>();
        }

        public virtual TreeNode GetTreeNode() { return this.Node; }

        public virtual void AddChild(DataNode child)
        {
            Children.Add(child);
            Node.Nodes.Add(child.GetTreeNode());
        }

        public virtual void RemoveChild(DataNode child)
        {
            Children.Remove(child);
            Node.Nodes.Remove(child.GetTreeNode());
        }
    }
}
