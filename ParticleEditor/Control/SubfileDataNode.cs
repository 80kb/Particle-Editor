using ParticleEditor.Serial;

namespace ParticleEditor.Control
{
    internal class SubfileDataNode : DataNode
    {
        BREFF._TableItem Item;

        public SubfileDataNode(BREFF._TableItem item) : base(item.Name)
        {
            Item = item;

            // Add Emitter
            Emitter emitter = new Emitter(item.Data);
            EmitterDataNode emitterNode = new EmitterDataNode(emitter);
            AddChild(emitterNode);
        }
    }
}
