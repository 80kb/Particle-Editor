using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleEditor.Serial
{
    public class Particle
    {
        public class _Header
        {
            public uint Size;

            public _Header(EndianReader reader)
            {
                Size = reader.ReadUInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Size);
            }
        }

        public class _ParticleData
        {
            public byte[] Color1A;
            public byte[] Color1B;
            public byte[] Color2A;
            public byte[] Color2B;
            public float[] Size;
            public float[] Scale;
            public float[] Rotation;
            public float[] TextureScale1;
            public float[] TextureScale2;
            public float[] TextureScale3;
            public float[] TextureRotation;
            public float[] TextureTranslate1;
            public float[] TextureTranslate2;
            public float[] TextureTranslate3;
            public uint mTexture1;
            public uint mTexture2;
            public uint mTexture3;
            public ushort TextureWrap;
            public byte TextureReverse;
            public byte AlphaCompareRef0;
            public byte AlphaCompareRef1;
            public byte RotateOffsetRandom1;
            public byte RotateOffsetRandom2;
            public byte RotateOffsetRandom3;
            public float[] RotateOffset;
            public ushort TexRef1Length;
            public string TexRef1;
            public ushort TexRef2Length;
            public string TexRef2;
            public ushort TexRef3Length;
            public string TexRef3;

            public _ParticleData(EndianReader reader)
            {
                Color1A = reader.ReadBytes(4);
                Color1B = reader.ReadBytes(4);
                Color2A = reader.ReadBytes(4);
                Color2B = reader.ReadBytes(4);
                Size = reader.ReadSingles(2);
                Scale = reader.ReadSingles(2);
                Rotation = reader.ReadSingles(3);
                TextureScale1 = reader.ReadSingles(2);
                TextureScale2 = reader.ReadSingles(2);
                TextureScale3 = reader.ReadSingles(2);
                TextureRotation = reader.ReadSingles(3);
                TextureTranslate1 = reader.ReadSingles(2);
                TextureTranslate2 = reader.ReadSingles(2);
                TextureTranslate3 = reader.ReadSingles(2);
                mTexture1 = reader.ReadUInt32();
                mTexture2 = reader.ReadUInt32();
                mTexture3 = reader.ReadUInt32();
                TextureWrap = reader.ReadUInt16();
                TextureReverse = reader.ReadByte();
                AlphaCompareRef0 = reader.ReadByte();
                AlphaCompareRef1 = reader.ReadByte();
                RotateOffsetRandom1 = reader.ReadByte();
                RotateOffsetRandom2 = reader.ReadByte();
                RotateOffsetRandom3 = reader.ReadByte();
                RotateOffset = reader.ReadSingles(3);
                TexRef1Length = reader.ReadUInt16();
                TexRef1 = reader.ReadStringNT();
                TexRef2Length = reader.ReadUInt16();
                TexRef2 = reader.ReadStringNT();
                TexRef3Length = reader.ReadUInt16();
                TexRef3 = reader.ReadStringNT();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteBytes(Color1A);
                writer.WriteBytes(Color1B);
                writer.WriteBytes(Color2A);
                writer.WriteBytes(Color2B);
                writer.WriteSingles(Size);
                writer.WriteSingles(Scale);
                writer.WriteSingles(Rotation);
                writer.WriteSingles(TextureScale1);
                writer.WriteSingles(TextureScale2);
                writer.WriteSingles(TextureScale3);
                writer.WriteSingles(TextureRotation);
                writer.WriteSingles(TextureTranslate1);
                writer.WriteSingles(TextureTranslate2);
                writer.WriteSingles(TextureTranslate3);
                writer.WriteUInt32(mTexture1);
                writer.WriteUInt32(mTexture2);
                writer.WriteUInt32(mTexture3);
                writer.WriteUInt16(TextureWrap);
                writer.WriteByte(TextureReverse);
                writer.WriteByte(AlphaCompareRef0);
                writer.WriteByte(AlphaCompareRef1);
                writer.WriteByte(RotateOffsetRandom1);
                writer.WriteByte(RotateOffsetRandom2);
                writer.WriteByte(RotateOffsetRandom3);
                writer.WriteSingles(RotateOffset);
                writer.WriteUInt16(TexRef1Length);
                writer.WriteStringNT(TexRef1);
                writer.WriteUInt16(TexRef2Length);
                writer.WriteStringNT(TexRef2);
                writer.WriteUInt16(TexRef3Length);
                writer.WriteStringNT(TexRef3);
            }
        }

        /////////////////////
        /////////////////////

        public _Header Header;
        public _ParticleData ParticleData;

        public Particle(EndianReader reader)
        {
            Header = new _Header(reader);
            ParticleData = new _ParticleData(reader);
        }

        public void Write(EndianWriter writer)
        {
            Header.Write(writer);
            ParticleData.Write(writer);
        }
    }
}
