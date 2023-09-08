using ParticleEditor.Serial;
using System.ComponentModel;

namespace ParticleEditor.Control
{
    enum TEVInputArg : byte
    {
        OutputColor = 0,
        OutputAlpha = 1,
        Color0 = 2,
        Alpha0 = 3,
        Color1 = 4,
        Alpha1 = 5,
        Color2 = 6,
        Alpha2 = 7,
        TextureColor = 8,
        TextureAlpha = 9,
        RasterColor = 10,
        RasterAlpha = 11,
        One = 12,
        Half = 13,
        ConstantColorSelection = 14,
        Zero = 15
    }

    enum TEVOperation : byte
    {
        Addition = 0,
        Subtraction = 1
    }

    enum TEVBias : byte
    {
        Zero = 0,
        AddHalf = 1,
        SubtractHalf = 2
    }

    enum TEVScale : byte
    {
        MultiplyBy1 = 0,
        MultiplyBy2 = 1,
        MultiplyBy4 = 2,
        DivideBy2 = 3
    }

    enum TEVBool : byte
    {
        False = 0,
        True = 1
    }

    enum TEVColorOutRegister : byte
    {
        OutputColor = 0,
        Color0 = 1,
        Color1 = 2,
        Color2 = 3
    }

    enum TEVAlphaOutRegister : byte
    {
        OutputAlpha = 0,
        Alpha0 = 1,
        Alpha1 = 2,
        Alpha2 = 3
    }

    internal class ShaderStageDataNode : DataNode
    {
        Emitter._ShaderStage ShaderStage;

        [Category("Misc")]
        public byte Texture
        {
            get { return ShaderStage.Texture; }
            set { ShaderStage.Texture = value; }
        }

        [Category("Color")]
        public TEVInputArg ColorInput0
        {
            get { return (TEVInputArg)ShaderStage.ColorInputs[0]; }
            set { ShaderStage.ColorInputs[0] = (byte)value; }
        }

        [Category("Color")]
        public TEVInputArg ColorInput1
        {
            get { return (TEVInputArg)ShaderStage.ColorInputs[1]; }
            set { ShaderStage.ColorInputs[1] = (byte)value; }
        }

        [Category("Color")]
        public TEVInputArg ColorInput2
        {
            get { return (TEVInputArg)ShaderStage.ColorInputs[2]; }
            set { ShaderStage.ColorInputs[2] = (byte)value; }
        }

        [Category("Color")]
        public TEVInputArg ColorInput3
        {
            get { return (TEVInputArg)ShaderStage.ColorInputs[3]; }
            set { ShaderStage.ColorInputs[3] = (byte)value; }
        }

        [Category("Color")]
        public TEVOperation ColorOperation
        {
            get { return (TEVOperation)ShaderStage.ColorOperations[0]; }
            set { ShaderStage.ColorOperations[0] = (byte)value; }
        }

        [Category("Color")]
        public TEVBias ColorBias
        {
            get { return (TEVBias)ShaderStage.ColorOperations[1]; }
            set { ShaderStage.ColorOperations[1] = (byte)value; }
        }

        [Category("Color")]
        public TEVScale ColorScale
        {
            get { return (TEVScale)ShaderStage.ColorOperations[2]; }
            set { ShaderStage.ColorOperations[2] = (byte)value; }
        }

        [Category("Color")]
        public TEVBool ColorClamp
        {
            get { return (TEVBool)ShaderStage.ColorOperations[3]; }
            set { ShaderStage.ColorOperations[3] = (byte)value; }
        }

        [Category("Color")]
        public TEVColorOutRegister ColorOutRegister
        {
            get { return (TEVColorOutRegister)ShaderStage.ColorOperations[4]; }
            set { ShaderStage.ColorOperations[4] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVInputArg AlphaInput0
        {
            get { return (TEVInputArg)ShaderStage.AlphaInputs[0]; }
            set { ShaderStage.AlphaInputs[0] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVInputArg AlphaInput1
        {
            get { return (TEVInputArg)ShaderStage.AlphaInputs[1]; }
            set { ShaderStage.AlphaInputs[1] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVInputArg AlphaInput2
        {
            get { return (TEVInputArg)ShaderStage.AlphaInputs[2]; }
            set { ShaderStage.AlphaInputs[2] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVInputArg AlphaInput3
        {
            get { return (TEVInputArg)ShaderStage.AlphaInputs[3]; }
            set { ShaderStage.AlphaInputs[3] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVOperation AlphaOperation
        {
            get { return (TEVOperation)ShaderStage.AlphaOperations[0]; }
            set { ShaderStage.AlphaOperations[0] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVBias AlphaBias
        {
            get { return (TEVBias)ShaderStage.AlphaOperations[1]; }
            set { ShaderStage.AlphaOperations[1] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVScale AlphaScale
        {
            get { return (TEVScale)ShaderStage.AlphaOperations[2]; }
            set { ShaderStage.AlphaOperations[2] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVBool AlphaClamp
        {
            get { return (TEVBool)ShaderStage.AlphaOperations[3]; }
            set { ShaderStage.AlphaOperations[3] = (byte)value; }
        }

        [Category("Alpha")]
        public TEVAlphaOutRegister AlphaOutRegister
        {
            get { return (TEVAlphaOutRegister)ShaderStage.AlphaOperations[4]; }
            set { ShaderStage.AlphaOperations[4] = (byte)value; }
        }

        public ShaderStageDataNode(Emitter._ShaderStage shaderStage, int index) : base("TEV Stage " + index)
        {
            this.ShaderStage = shaderStage;
            SetImage("page");
        }
    }
}
