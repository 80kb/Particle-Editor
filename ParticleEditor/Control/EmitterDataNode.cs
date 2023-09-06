using ParticleEditor.Serial;

namespace ParticleEditor.Control
{
    internal class EmitterDataNode : DataNode
    {
        private Emitter Emitter;

        public EmitterDataNode(Emitter emitter) : base("Emitter")
        {
            this.Emitter = emitter;
        }
    }
}
