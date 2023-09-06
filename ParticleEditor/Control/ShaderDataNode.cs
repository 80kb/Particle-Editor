using ParticleEditor.Serial;

namespace ParticleEditor.Control
{
    internal class ShaderStageDataNode : DataNode
    {
        Emitter._ShaderStage ShaderStage;

        public ShaderStageDataNode(Emitter._ShaderStage shaderStage, int index) : base("Shader " + index)
        {
            this.ShaderStage = shaderStage;
        }
    }
}
