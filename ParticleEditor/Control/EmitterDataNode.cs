using ParticleEditor.Serial;
using System.ComponentModel;
using System.Numerics;

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

    internal enum BlendFactor : byte
    {
        Zero = 0,
        One = 1,
        SourceColor = 2,
        InvertedSourceColor = 3,
        DestinationColor = 4,
        InvertedDestinationColor = 5,
        SourceAlpha = 6,
        InvertedSourceAlpha = 7
    }

    internal enum BlendOperation : byte
    {
        Clear = 0,
        And = 1,
        ReverseAnd = 2,
        Copy = 3,
        InvertedAnd = 4,
        Noop = 5,
        Xor = 6,
        Or = 7,
        Nor = 8,
        Equiv = 9,
        Invert = 10,
        ReverseOr = 11,
        InvertedCopy = 12,
        InvertedOr = 13,
        Nand = 14,
        Set = 15
    }

    internal enum AlphaFlickType : byte
    {
        None = 0,
        Triangle = 1,
        Sawtooth1 = 2,
        Sawtooth2 = 3,
        Square = 4,
        Sine = 5
    }

    internal enum LightingMode : byte
    {
        Off = 0,
        Simple = 1,
        Hardware = 2
    }

    internal enum LightingType : byte
    {
        None = 0,
        Ambient = 1,
        Point = 2
    }

    internal enum ParticleType : byte
    {
        Point = 0,
        Line = 1,
        Free = 2,
        Billboard = 3,
        Directional = 4,
        Stripe = 5,
        SmoothStripe = 6
    }

    internal enum ParticleOption : byte
    {
        Normal = 0,
        Setting2 = 1,
        Setting3 = 2,
        Setting4 = 3
    }

    internal enum MovementDirection : byte
    {
        VelocityVector = 0,
        RelativeToEmitter = 1,
        EmitterDirection = 2,
        RelativeToLastParticle = 3,
        RelativeToNeighborsBillboard = 4,
        RelativeToNeighborsOther = 6
    }

    internal enum RotationAxis : byte
    {
        X = 0,
        Y = 1,
        Z = 2,
        XYZ = 3
    }

    internal class EmitterDataNode : DataNode
    {
        private Emitter Emitter;

        [Category("Info")]
        public uint Length
        {
            get { return Emitter.Header.Size; }
        }

        [Category("Info")]
        public byte TEVStageAmount
        {
            get { return Emitter.EmitData.TEVStageAmount; }
        }

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

        [Category("Emit Data")]
        public ushort EmitterLife
        {
            get { return Emitter.EmitData.EmitterLife; }
            set { Emitter.EmitData.EmitterLife = value; }
        }

        [Category("Emit Data")]
        public ushort ParticleLife
        {
            get { return Emitter.EmitData.ParticleLife; }
            set { Emitter.EmitData.ParticleLife = value; }
        }

        [Category("Emit Data")]
        public byte ParticleLifeRandom
        {
            get { return Emitter.EmitData.ParticleLifeRandom; }
            set { Emitter.EmitData.ParticleLifeRandom = value; }
        }

        [Category("Emit Data")]
        public bool InheritChildParticleTranslation
        {
            get { return Emitter.EmitData.InheritChildParticleTranslation; }
            set { Emitter.EmitData.InheritChildParticleTranslation = value; }
        }

        [Category("Emit Data")]
        public byte EmitIntervalRandom
        {
            get { return Emitter.EmitData.EmitIntervalRandom; }
            set { Emitter.EmitData.EmitIntervalRandom = value; }
        }

        [Category("Emit Data")]
        public byte EmitRandom
        {
            get { return Emitter.EmitData.EmitRandom; }
            set { Emitter.EmitData.EmitRandom = value; }
        }

        [Category("Emit Data")]
        public float EmissionRate
        {
            get { return Emitter.EmitData.EmissionRate; }
            set { Emitter.EmitData.EmissionRate = value; }
        }

        [Category("Emit Time")]
        public ushort EmitStart
        {
            get { return Emitter.EmitData.EmitStart; }
            set { Emitter.EmitData.EmitStart = value; }
        }

        [Category("Emit Time")]
        public ushort EmitEnd
        {
            get { return Emitter.EmitData.EmitEnd; }
            set { Emitter.EmitData.EmitEnd = value; }
        }

        [Category("Emit Time")]
        public ushort EmitInterval
        {
            get { return Emitter.EmitData.EmitInterval; }
            set { Emitter.EmitData.EmitInterval = value; }
        }

        [Category("Emit Data")]
        public bool InheritParticleTranslation
        {
            get { return Emitter.EmitData.InheritParticleTranslation; }
            set { Emitter.EmitData.InheritParticleTranslation = value; }
        }

        [Category("Emit Data")]
        public bool InheritChildEmitterTranslation
        {
            get { return Emitter.EmitData.InheritChildEmitterTranslation; }
            set { Emitter.EmitData.InheritChildEmitterTranslation = value; }
        }

        [Category("Emit Data")]
        public float[] EmitterDimensions
        {
            get { return Emitter.EmitData.EmitterDimensions; }
            set { Emitter.EmitData.EmitterDimensions = value; }
        }

        [Category("Emit Data")]
        public ushort EmitDiversion
        {
            get { return Emitter.EmitData.EmitDiversion; }
            set { Emitter.EmitData.EmitDiversion = value; }
        }

        [Category("Emit Data")]
        public byte VelocityRandom
        {
            get { return Emitter.EmitData.VelocityRandom; }
            set { Emitter.EmitData.VelocityRandom = value; }
        }

        [Category("Emit Data")]
        public byte MomentumRandom
        {
            get { return Emitter.EmitData.MomentumRandom; }
            set { Emitter.EmitData.MomentumRandom = value; }
        }

        [Category("Emit Data")]
        public uint RandomSeed
        {
            get { return Emitter.EmitData.RandomSeed; }
            set { Emitter.EmitData.RandomSeed = value; }
        }

        [Category("Emit Data")]
        public ulong Unknown1
        {
            get { return Emitter.EmitData.Unknown1; }
            set { Emitter.EmitData.Unknown1 = value; }
        }

        [Category("Emit Data")]
        public byte Unknown2
        {
            get { return Emitter.EmitData.Unknown2; }
            set { Emitter.EmitData.Unknown2 = value; }
        }

        [Category("Color")]
        public byte AlphaComparison0
        {
            get { return Emitter.EmitData.AlphaComparison0; }
            set { Emitter.EmitData.AlphaComparison0 = value; }
        }

        [Category("Color")]
        public byte AlphaComparison1
        {
            get { return Emitter.EmitData.AlphaComparison1; }
            set { Emitter.EmitData.AlphaComparison1 = value; }
        }

        [Category("Color")]
        public byte AlphaCompareOperation
        {
            get { return Emitter.EmitData.AlphaCompareOperation; }
            set { Emitter.EmitData.AlphaCompareOperation = value; }
        }

        [Category("Emit Data")]
        public bool EnableIndirectTEV
        {
            get { return Emitter.EmitData.EnableIndirectTEV == 1; }
            set { Emitter.EmitData.EnableIndirectTEV = value ? (byte)1 : (byte)0; }
        }

        [Category("Draw Flags")]
        public bool EnableZCompare
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0001) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0001; }
        }

        [Category("Draw Flags")]
        public bool EnableZUpdate
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0002) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0002; }
        }

        [Category("Draw Flags")]
        public bool CompareAlphaBeforeTexture
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0004) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0004; }
        }

        [Category("Draw Flags")]
        public bool DisableAlphaClipping
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0008) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0008; }
        }

        [Category("Draw Flags")]
        public bool EnableTexture1
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0010) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0010; }
        }

        [Category("Draw Flags")]
        public bool EnableTexture2
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0020) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0020; }
        }

        [Category("Draw Flags")]
        public bool EnableIndirectTexture
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0040) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0040; }
        }

        [Category("Draw Flags")]
        public bool ProjectTexture1
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0080) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0080; }
        }

        [Category("Draw Flags")]
        public bool ProjectTexture2
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0100) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0100; }
        }

        [Category("Draw Flags")]
        public bool ProjectIndirectTexture
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0200) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0200; }
        }

        [Category("Draw Flags")]
        public bool MakeInvisible
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0400) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0400; }
        }

        [Category("Draw Flags")]
        public bool ReverseDrawOrder
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x0800) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x0800; }
        }

        [Category("Draw Flags")]
        public bool EnableFog
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x1000) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x1000; }
        }

        [Category("Draw Flags")]
        public bool XYLinkSize
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x2000) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x2000; }
        }

        [Category("Draw Flags")]
        public bool XYLinkScale
        {
            get { return (Emitter.EmitData.DrawFlagsBitfield & 0x4000) > 0; }
            set { Emitter.EmitData.DrawFlagsBitfield ^= 0x4000; }
        }

        [Category("Power")]
        public float PowerRadiation
        {
            get { return Emitter.EmitData.PowerRadiation; }
            set { Emitter.EmitData.PowerRadiation = value; }
        }

        [Category("Power")]
        public float PowerYAxisValue
        {
            get { return Emitter.EmitData.PowerYAxisValue; }
            set { Emitter.EmitData.PowerYAxisValue = value; }
        }

        [Category("Power")]
        public float PowerRandom
        {
            get { return Emitter.EmitData.PowerRandom; }
            set { Emitter.EmitData.PowerRandom = value; }
        }

        [Category("Power")]
        public float PowerNormal
        {
            get { return Emitter.EmitData.PowerNormal; }
            set { Emitter.EmitData.PowerNormal = value; }
        }

        [Category("Power")]
        public float DiffusionEmitterNormal
        {
            get { return Emitter.EmitData.DiffusionEmitterNormal; }
            set { Emitter.EmitData.DiffusionEmitterNormal = value; }
        }

        [Category("Power")]
        public float PowerSpec
        {
            get { return Emitter.EmitData.PowerSpec; }
            set { Emitter.EmitData.PowerSpec = value; }
        }

        [Category("Power")]
        public float DiffusionSpec
        {
            get { return Emitter.EmitData.DiffusionSpec; }
            set { Emitter.EmitData.DiffusionSpec = value; }
        }

        [Category("Transform")]
        public Vector3f EmissionAngle
        {
            get { return Emitter.EmitData.EmissionAngle; }
            set { Emitter.EmitData.EmissionAngle = value; }
        }

        [Category("Transform")]
        public Vector3f Scale
        {
            get { return Emitter.EmitData.Scale; }
            set { Emitter.EmitData.Scale = value; }
        }

        [Category("Transform")]
        public Vector3f Rotation
        {
            get { return Emitter.EmitData.Rotation; }
            set { Emitter.EmitData.Rotation = value; }
        }

        [Category("Transform")]
        public Vector3f Translation
        {
            get { return Emitter.EmitData.Translation; }
            set { Emitter.EmitData.Translation = value; }
        }

        [Category("LOD")]
        public byte LODNearestDistance
        {
            get { return Emitter.EmitData.LODNearestDistance; }
            set { Emitter.EmitData.LODNearestDistance = value; }
        }

        [Category("LOD")]
        public byte LODFarthestDistance
        {
            get { return Emitter.EmitData.LODFarthestDistance; }
            set { Emitter.EmitData.LODFarthestDistance = value; }
        }

        [Category("LOD")]
        public byte LODMinimalEmission
        {
            get { return Emitter.EmitData.LODMinimalEmission; }
            set { Emitter.EmitData.LODMinimalEmission = value; }
        }

        [Category("LOD")]
        public byte LODAlpha
        {
            get { return Emitter.EmitData.LODAlpha; }
            set { Emitter.EmitData.LODAlpha = value; }
        }

        [Category("Color")]
        public byte[] ConstColorSelectors
        {
            get { return Emitter.Color.ConstColor; }
            set { Emitter.Color.ConstColor = value; }
        }

        [Category("Color")]
        public byte[] ConstAlphaSelectors
        {
            get { return Emitter.Color.ConstAlpha; }
            set { Emitter.Color.ConstAlpha = value; }
        }

        [Category("Blending")]
        public bool EnableBlend
        {
            get { return Emitter.Color.BlendMode == 1; }
            set { Emitter.Color.BlendMode = value ? (byte)1 : (byte)0; }
        }

        [Category("Blending")]
        public BlendFactor BlendSourceFactor
        {
            get { return (BlendFactor)Emitter.Color.BlendSourceFactor; }
            set { Emitter.Color.BlendSourceFactor = (byte)value; }
        }

        [Category("Blending")]
        public BlendFactor BlendDestFactor
        {
            get { return (BlendFactor)Emitter.Color.BlendDestFactor; }
            set { Emitter.Color.BlendDestFactor = (byte)value; }
        }

        [Category("Blending")]
        public BlendOperation BlendOperation
        {
            get { return (BlendOperation)Emitter.Color.BlendOperation; }
            set { Emitter.Color.BlendOperation = (byte)value; }
        }

        [Category("Alpha Flick")]
        public AlphaFlickType AlphaFlickType
        {
            get { return (AlphaFlickType)Emitter.Color.AlphaFlickType; }
            set { Emitter.Color.AlphaFlickType = (byte)value; }
        }

        [Category("Alpha Flick")]
        public ushort AlphaFlickCycleLength
        {
            get { return Emitter.Color.AlphaFlickCycleLength; }
            set { Emitter.Color.AlphaFlickCycleLength = value; }
        }

        [Category("Alpha Flick")]
        public  byte AlphaFlickMax
        {
            get { return Emitter.Color.AlphaFlickMax; }
            set { Emitter.Color.AlphaFlickMax = value; }
        }

        [Category("Alpha Flick")]
        public byte AlphaFlickAmplitude
        {
            get { return Emitter.Color.AlphaFlickAmplitude; }
            set { Emitter.Color.AlphaFlickAmplitude = value; }
        }

        [Category("Lighting")]
        public LightingMode LightingMode
        {
            get { return (LightingMode)Emitter.Lighting.LightingMode; }
            set { Emitter.Lighting.LightingMode = (byte)value; }
        }

        [Category("Lighting")]
        public LightingType LightingType
        {
            get { return (LightingType)Emitter.Lighting.LightingType; }
            set { Emitter.Lighting.LightingType = (byte)value; }
        }

        [Category("Lighting")]
        public Color LightingAmbientColor
        {
            get 
            {
                return Color.FromArgb(
                    255,
                    Emitter.Lighting.LightingAmbientColor[0],
                    Emitter.Lighting.LightingAmbientColor[1],
                    Emitter.Lighting.LightingAmbientColor[2]
                );
            }
            set 
            {
                Emitter.Lighting.LightingAmbientColor[0] = value.R; 
                Emitter.Lighting.LightingAmbientColor[1] = value.G; 
                Emitter.Lighting.LightingAmbientColor[2] = value.B; 
            }
        }

        [Category("Lighting")]
        public Color LightingDiffuseColor
        {
            get
            {
                return Color.FromArgb(
                    255,
                    Emitter.Lighting.LightingDiffuseColor[0],
                    Emitter.Lighting.LightingDiffuseColor[1],
                    Emitter.Lighting.LightingDiffuseColor[2]
                );
            }
            set
            {
                Emitter.Lighting.LightingDiffuseColor[0] = value.R;
                Emitter.Lighting.LightingDiffuseColor[1] = value.G;
                Emitter.Lighting.LightingDiffuseColor[2] = value.B;
            }
        }

        [Category("Lighting")]
        public float LightingRadius
        {
            get { return Emitter.Lighting.LightingRadius; }
            set { Emitter.Lighting.LightingRadius = value; }
        }

        [Category("Lighting")]
        public Vector3f LightingPosition
        {
            get { return Emitter.Lighting.LightingPosition; }
            set { Emitter.Lighting.LightingPosition = value; }
        }

        [Category("Indirect Texture")]
        public float[,] IndirectTextureMatrix
        {
            get { return Emitter.Lighting.IndirectTextureMatrix; }
            set { Emitter.Lighting.IndirectTextureMatrix = value; }
        }

        [Category("Indirect Texture")]
        public sbyte IndirectTextureMatrixScale
        {
            get { return Emitter.Lighting.IndirectTextureMatrixScale; }
            set { Emitter.Lighting.IndirectTextureMatrixScale = value; }
        }

        [Category("Indirect Texture")]
        public sbyte PivotY
        {
            get { return Emitter.Lighting.PivotY; }
            set { Emitter.Lighting.PivotY = value; }
        }

        [Category("Indirect Texture")]
        public sbyte PivotX
        {
            get { return Emitter.Lighting.PivotX; }
            set { Emitter.Lighting.PivotX = value; }
        }

        [Category("Particle")]
        public ParticleType ParticleType
        {
            get { return (ParticleType)Emitter.Movement.ParticleType; }
            set { Emitter.Movement.ParticleType = (byte)value; }
        }

        [Category("Particle")]
        public ParticleOption ParticleVariant
        {
            get { return (ParticleOption)Emitter.Movement.ParticleVariant; }
            set { Emitter.Movement.ParticleVariant = (byte)value; }
        }

        [Category("Movement")]
        public MovementDirection MovementDirection
        {
            get { return (MovementDirection)Emitter.Movement.MovementDirection; }
            set { Emitter.Movement.MovementDirection = (byte)value; }
        }

        [Category("Movement")]
        public RotationAxis RotationAxis
        {
            get { return (RotationAxis)Emitter.Movement.RotationAxis; }
            set { Emitter.Movement.RotationAxis = (byte)value; }
        }

        [Category("Movement")]
        public byte Setting1
        {
            get { return Emitter.Movement.Setting1; }
            set { Emitter.Movement.Setting1 = value; }
        }

        [Category("Movement")]
        public byte Setting2
        {
            get { return Emitter.Movement.Setting2; }
            set { Emitter.Movement.Setting2 = value; }
        }

        [Category("Movement")]
        public byte Setting3
        {
            get { return Emitter.Movement.Setting3; }
            set { Emitter.Movement.Setting3 = value; }
        }

        [Category("Transform")]
        public float ZOffset
        {
            get { return Emitter.Movement.ZOffset; }
            set { Emitter.Movement.ZOffset = value; }
        }

        public EmitterDataNode(Emitter emitter) : base("Emitter")
        {
            this.Emitter = emitter;
            SetImage("light");

            for(int i = 0; i < emitter.Shader.ShaderStages.Count; i++)
            {
                Emitter._ShaderStage stage = emitter.Shader.ShaderStages[i];
                ShaderStageDataNode stageNode = new ShaderStageDataNode(stage, i);
                AddChild(stageNode);
            }
        }
    }
}
