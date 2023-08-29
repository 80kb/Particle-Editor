using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleEditor.Serial
{
    public class Emitter
    {
        public enum Shape : byte
        {
            Disc = 0x0,
            Line = 0x1,
            Cube = 0x5,
            Cylinder = 0x7,
            Sphere = 0x8,
            Point = 0x9,
            Torus = 0xA
        }

        public class _Header
        {
            public uint EffectNamePointer;
            public uint Size;

            public _Header()
            {
                EffectNamePointer = 0;
                Size = 0;
            }

            public _Header(EndianReader reader)
            {
                EffectNamePointer = reader.ReadUInt32();
                Size = reader.ReadUInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(EffectNamePointer);
                writer.WriteUInt32(Size);
            }
        }

        /////////////////////////
        /////////////////////////

        public _Header Header;
        public uint Unknown0;
        public uint EmitFlags;
        public Shape EmitShape;
        public ushort EmitterLife;
        public ushort ParticleLife;
        public byte ParticleLifeRandom;
        public bool InheritChildParticleTranslation;
        public byte EmitIntervalRandom;
        public byte EmitRandom;
        public float EmissionRate;
        public ushort EmitStart;
        public ushort EmitEnd;
        public ushort EmitInterval;
        public bool InheritParticleTranslation;
        public bool InheritChildEmitterTranslation;
        public float[] EmitterDimensions;
        public ushort EmitDiversion;
        public byte VelocityRandom;
        public byte MomentumRandom;
        public float PowerRadiation;
        public float PowerYAxisValue;
        public float PowerRandom;
        public float PowerNormal;
        public float DiffusionEmitterNormal;
        public float PowerSpec;
        public float DiffusionSpec;
        public float[] EmissionAngle;
        public float[] Scale;
        public float[] Rotation;
        public float[] Translation;
        public byte LODNearestDistance;
        public byte LODFarthestDistance;
        public byte LODMinimalEmission;
        public byte LODAlpha;
        public uint RandomSeed;
        public ulong Unknown1;
        public ushort DrawFlagsBitfield;
        public byte AlphaComparison0;
        public byte AlphaComparison1;
        public byte AlphaCompareOperation;
        public byte TEVStageAmount;
        public byte Unknown2;
        public byte EnableIndirectTEV;
        public byte[] TEVTextures;
        public byte[,] TEVColorSources;
    }
}
