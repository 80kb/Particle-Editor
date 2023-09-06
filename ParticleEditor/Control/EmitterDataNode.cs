using ParticleEditor.Serial;
using System.ComponentModel;

namespace ParticleEditor.Control
{
    internal enum EmitShape : byte
    {
        Disc = 0x0,
        Line = 0x1,
        Cube = 0x5,
        Cylinder = 0x7,
        Sphere = 0x8,
        Point = 0x9,
        Torus = 0xA
    }

    internal class EmitterDataNode : DataNode
    {
        private Emitter Emitter;

        [Category("Emit Data")]
        public uint EmitFlags
        {
            get { return Emitter.EmitData.EmitFlags; }
            set { Emitter.EmitData.EmitFlags = value; }
        }

        [Category("Emit Data")]
        public EmitShape EmitShape
        {
            get { return (EmitShape)Emitter.EmitData.EmitShape; }
            set { Emitter.EmitData.EmitShape = (byte)value; }
        }

        public EmitterDataNode(Emitter emitter) : base("Emitter")
        {
            this.Emitter = emitter;

            for(int i = 0; i < emitter.Shader.ShaderStages.Count; i++)
            {
                Emitter._ShaderStage stage = emitter.Shader.ShaderStages[i];
                ShaderStageDataNode stageNode = new ShaderStageDataNode(stage, i);
                AddChild(stageNode);
            }
        }
    }
}
