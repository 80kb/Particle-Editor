namespace ParticleEditor.Serial
{
    public class Emitter
    {
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

        public class _EmitData
        {
            public uint Unknown0;
            public uint EmitFlags;
            public byte EmitShape;
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

            public _EmitData(EndianReader reader)
            {
                Unknown0 = reader.ReadUInt32();
                EmitFlags = reader.ReadUInt32();
                EmitShape = reader.ReadByte();
                EmitterLife = reader.ReadUInt16();
                ParticleLife = reader.ReadUInt16();
                ParticleLifeRandom = reader.ReadByte();
                InheritChildParticleTranslation = reader.ReadByte() == 0;
                EmitIntervalRandom = reader.ReadByte();
                EmitRandom = reader.ReadByte();
                EmissionRate = reader.ReadSingle();
                EmitStart = reader.ReadUInt16();
                EmitEnd = reader.ReadUInt16();
                EmitInterval = reader.ReadUInt16();
                InheritParticleTranslation = reader.ReadByte() == 0;
                InheritChildEmitterTranslation = reader.ReadByte() == 0;
                EmitterDimensions = new float[6]
                {
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle()
                };
                EmitDiversion = reader.ReadUInt16();
                VelocityRandom = reader.ReadByte();
                MomentumRandom = reader.ReadByte();
                PowerRadiation = reader.ReadSingle();
                PowerYAxisValue = reader.ReadSingle();
                PowerRandom = reader.ReadSingle();
                PowerNormal = reader.ReadSingle();
                DiffusionEmitterNormal = reader.ReadSingle();
                PowerSpec = reader.ReadSingle();
                DiffusionSpec = reader.ReadSingle();
                EmissionAngle = new float[3]
                {
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle()
                };
                Scale = new float[3]
                {
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle()
                };
                Rotation = new float[3]
                {
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle()
                };
                Translation = new float[3]
                {
                    reader.ReadSingle(),
                    reader.ReadSingle(),
                    reader.ReadSingle()
                };
                LODNearestDistance = reader.ReadByte();
                LODFarthestDistance = reader.ReadByte();
                LODMinimalEmission = reader.ReadByte();
                LODAlpha = reader.ReadByte();
                RandomSeed = reader.ReadUInt32();
                Unknown1 = reader.ReadUInt64();
                DrawFlagsBitfield = reader.ReadUInt16();
                AlphaComparison0 = reader.ReadByte();
                AlphaComparison1 = reader.ReadByte();
                AlphaCompareOperation = reader.ReadByte();
                TEVStageAmount = reader.ReadByte();
                Unknown2 = reader.ReadByte();
                EnableIndirectTEV = reader.ReadByte();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Unknown0);
                writer.WriteUInt32(EmitFlags);
                writer.WriteByte(EmitShape);
                writer.WriteUInt16(EmitterLife);
                writer.WriteUInt16(ParticleLife);
                writer.WriteByte(ParticleLifeRandom);
                writer.WriteByte(Convert.ToByte(InheritChildParticleTranslation));
                writer.WriteByte(EmitIntervalRandom);
                writer.WriteByte(EmitRandom);
                writer.WriteSingle(EmissionRate);
                writer.WriteUInt16(EmitStart);
                writer.WriteUInt16(EmitEnd);
                writer.WriteUInt16(EmitInterval);
                writer.WriteByte(Convert.ToByte(InheritParticleTranslation));
                writer.WriteByte(Convert.ToByte(InheritChildEmitterTranslation));
                foreach (float f in EmitterDimensions)
                    writer.WriteSingle(f);
                writer.WriteUInt16(EmitDiversion);
                writer.WriteByte(VelocityRandom);
                writer.WriteByte(MomentumRandom);
                writer.WriteSingle(PowerRadiation);
                writer.WriteSingle(PowerYAxisValue);
                writer.WriteSingle(PowerRandom);
                writer.WriteSingle(PowerNormal);
                writer.WriteSingle(DiffusionEmitterNormal);
                writer.WriteSingle(PowerSpec);
                writer.WriteSingle(DiffusionSpec);
                foreach(float f in EmissionAngle)
                    writer.WriteSingle(f);
                foreach (float f in Scale)
                    writer.WriteSingle(f);
                foreach (float f in Rotation)
                    writer.WriteSingle(f);
                foreach (float f in Translation)
                    writer.WriteSingle(f);
                writer.WriteByte(LODNearestDistance);
                writer.WriteByte(LODFarthestDistance);
                writer.WriteByte(LODMinimalEmission);
                writer.WriteByte(LODAlpha);
                writer.WriteUInt32(RandomSeed);
                writer.WriteUInt64(Unknown1);
                writer.WriteUInt16(DrawFlagsBitfield);
                writer.WriteByte(AlphaComparison0);
                writer.WriteByte(AlphaComparison1);
                writer.WriteByte(AlphaCompareOperation);
                writer.WriteByte(TEVStageAmount);
                writer.WriteByte(Unknown2);
                writer.WriteByte(EnableIndirectTEV);
            }
        }

        public class _Shader
        {
            List<_ShaderStage> ShaderStages;

            public _Shader(EndianReader reader, int stageAmount)
            {
                byte[] textures = reader.ReadBytes(stageAmount);
                byte[][] colorInputs = new byte[stageAmount][];
                for (int i = 0; i < stageAmount; i++)
                    colorInputs[i] = reader.ReadBytes(4);

                byte[][] colorOperations = new byte[stageAmount][];
                for (int i = 0; i < stageAmount; i++)
                    colorOperations[i] = reader.ReadBytes(5);

                byte[][] alphaInputs = new byte[stageAmount][];
                for (int i = 0; i < stageAmount; i++)
                    alphaInputs[i] = reader.ReadBytes(4);

                byte[][] alphaOperations = new byte[stageAmount][];
                for (int i = 0; i < stageAmount; i++)
                    alphaOperations[i] = reader.ReadBytes(5);

                ShaderStages = new List<_ShaderStage>();
                for(int i = 0; i< stageAmount; i++)
                {
                    ShaderStages.Add(new _ShaderStage(
                        textures[i],
                        colorInputs[i],
                        colorOperations[i],
                        alphaInputs[i],
                        alphaOperations[i]
                    ));
                }
            }

            public void Write(EndianWriter writer)
            {
                foreach (_ShaderStage stage in ShaderStages)
                    stage.Write(writer);
            }
        }

        public class _ShaderStage
        {
            public byte Texture;
            public byte[] ColorInputs;
            public byte[] ColorOperations;
            public byte[] AlphaInputs;
            public byte[] AlphaOperations;

            public _ShaderStage()
            {
                ColorInputs = new byte[4];
                ColorOperations = new byte[5];
                AlphaInputs = new byte[4];
                AlphaOperations = new byte[5];
            }

            public _ShaderStage(
                byte texture, 
                byte[] colorInputs,
                byte[] colorOperations,
                byte[] alphaInputs,
                byte[] alphaOperations)
            {
                Texture = texture;
                ColorInputs = colorInputs;
                ColorOperations = colorOperations;
                AlphaInputs = alphaInputs;
                AlphaOperations = alphaOperations;
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteByte(Texture);
                writer.WriteBytes(ColorInputs);
                writer.WriteBytes(ColorOperations);
                writer.WriteBytes(AlphaInputs);
                writer.WriteBytes(AlphaOperations);
            }
        }

        /////////////////////////
        /////////////////////////

        public _Header Header;
        public _EmitData EmitData;
        public _Shader Shader;
        
        public Emitter(byte[] buffer)
        {
            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                Header = new _Header(reader);
                EmitData = new _EmitData(reader);
                Shader = new _Shader(reader, EmitData.TEVStageAmount);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
