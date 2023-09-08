using ParticleEditor.Serial;
using System.ComponentModel;

namespace ParticleEditor.Control
{
    internal class SubfileDataNode : DataNode
    {
        BREFF._TableItem Item;

        [Category("Info")]
        public string Name
        {
            get { return Item.Name; }
        }

        [Category("Info")]
        public uint DataOffset
        {
            get { return Item.DataOffset; }
        }

        [Category("Info")]
        public uint DataLength
        {
            get { return Item.DataSize;}
        }

        public SubfileDataNode(BREFF._TableItem item) : base(item.Name)
        {
            this.Item = item;

            // Add Emitter
            AddChild(new EmitterDataNode(item.Emitter));

            // Add Particle
            AddChild(new ParticleDataNode(item.Particle));
        }
    }
}
