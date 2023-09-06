using ParticleEditor.Serial;

namespace ParticleEditor.Control
{
    public class BREFFDataNode : DataNode
    {
        private BREFF Breff;

        public BREFFDataNode(BREFF breff) : base(Path.GetFileName(breff.ProjectHeader.Name))
        {
            this.Breff = breff;

            // Add subfile nodes
            foreach(BREFF._TableItem item in Breff.Table.Entries)
            {
                SubfileDataNode subfileNode = new SubfileDataNode(item);
                AddChild(subfileNode);
            }
        }
    }
}
