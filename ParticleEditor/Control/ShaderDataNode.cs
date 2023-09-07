using ParticleEditor.Serial;

namespace ParticleEditor.Control
{
    internal class ShaderStageDataNode : DataNode
    {
        Emitter._ShaderStage ShaderStage;

        public ShaderStageDataNode(Emitter._ShaderStage shaderStage, int index) : base("TEV Stage " + index)
        {
            this.ShaderStage = shaderStage;
        }
    }
}
