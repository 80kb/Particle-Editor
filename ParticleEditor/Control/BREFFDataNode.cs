using ParticleEditor.Serial;
using System.ComponentModel;

namespace ParticleEditor.Control
{
    public class BREFFDataNode : DataNode
    {
        private BREFF Breff;

        [Category("Misc"), Description("Internal file name")]
        public string Name
        {
            get { return Breff.ProjectHeader.Name; }
            private set { }
        }

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
