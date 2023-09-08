using ParticleEditor.Serial;
using System.ComponentModel;

namespace ParticleEditor.Control
{
    internal class ParticleDataNode : DataNode
    {
        public Particle Particle;

        [Category("Color")]
        public Color Color1A
        {
            get 
            {
                return Color.FromArgb(
                255,
                Particle.ParticleData.Color1A[0],
                Particle.ParticleData.Color1A[1],
                Particle.ParticleData.Color1A[2]);
            }
            set
            {
                Particle.ParticleData.Color1A[0] = value.R;
                Particle.ParticleData.Color1A[1] = value.G;
                Particle.ParticleData.Color1A[2] = value.B;
                Particle.ParticleData.Color1A[3] = value.A;
            }
        }

        [Category("Color")]
        public Color Color1B
        {
            get
            {
                return Color.FromArgb(
                255,
                Particle.ParticleData.Color1B[0],
                Particle.ParticleData.Color1B[1],
                Particle.ParticleData.Color1B[2]);
            }
            set
            {
                Particle.ParticleData.Color1B[0] = value.R;
                Particle.ParticleData.Color1B[1] = value.G;
                Particle.ParticleData.Color1B[2] = value.B;
                Particle.ParticleData.Color1B[3] = value.A;
            }
        }

        [Category("Color")]
        public Color Color2A
        {
            get
            {
                return Color.FromArgb(
                    255,
                    Particle.ParticleData.Color2A[0],
                    Particle.ParticleData.Color2A[1],
                    Particle.ParticleData.Color2A[2]
                );
            }
            set
            {
                Particle.ParticleData.Color2A[0] = value.R;
                Particle.ParticleData.Color2A[1] = value.G;
                Particle.ParticleData.Color2A[2] = value.B;
                Particle.ParticleData.Color2A[3] = value.A;
            }
        }

        [Category("Color")]
        public Color Color2B
        {
            get
            {
                return Color.FromArgb(
                255,
                Particle.ParticleData.Color2B[0],
                Particle.ParticleData.Color2B[1],
                Particle.ParticleData.Color2B[2]);
            }
            set
            {
                Particle.ParticleData.Color2B[0] = value.R;
                Particle.ParticleData.Color2B[1] = value.G;
                Particle.ParticleData.Color2B[2] = value.B;
                Particle.ParticleData.Color2B[3] = value.A;
            }
        }

        [Category("Transform")]
        public float[] Size
        {
            get { return Particle.ParticleData.Size; }
            set { Particle.ParticleData.Size = value; }
        }

        [Category("Transform")]
        public float[] Scale
        {
            get { return Particle.ParticleData.Scale; }
            set { Particle.ParticleData.Scale = value; }
        }

        [Category("Transform")]
        public float[] Rotation
        {
            get { return Particle.ParticleData.Rotation; }
            set { Particle.ParticleData.Rotation = value; }
        }

        [Category("Texture Transform")]
        public float[] TextureScale1
        {
            get { return Particle.ParticleData.TextureScale1; }
            set { Particle.ParticleData.TextureScale1 = value; }
        }

        [Category("Texture Transform")]
        public float[] TextureScale2
        {
            get { return Particle.ParticleData.TextureScale2; }
            set { Particle.ParticleData.TextureScale2 = value; }
        }

        [Category("Texture Transform")]
        public float[] TextureScale3
        {
            get { return Particle.ParticleData.TextureScale3; }
            set { Particle.ParticleData.TextureScale3 = value; }
        }

        [Category("Texture Transform")]
        public float[] TextureRotation
        {
            get { return Particle.ParticleData.TextureRotation; }
            set { Particle.ParticleData.TextureRotation = value; }
        }

        [Category("Texture Transform")]
        public float[] TextureTranslate1
        {
            get { return Particle.ParticleData.TextureTranslate1; }
            set { Particle.ParticleData.TextureTranslate1 = value; }
        }

        [Category("Texture Transform")]
        public float[] TextureTranslate2
        {
            get { return Particle.ParticleData.TextureTranslate2; }
            set { Particle.ParticleData.TextureTranslate2 = value; }
        }

        [Category("Texture Transform")]
        public float[] TextureTranslate3
        {
            get { return Particle.ParticleData.TextureTranslate3; }
            set { Particle.ParticleData.TextureTranslate3 = value; }
        }

        [Category("Texture Transform")]
        public ushort TextureWrap
        {
            get { return Particle.ParticleData.TextureWrap; }
            set { Particle.ParticleData.TextureWrap = value; }
        }

        [Category("Texture Transform")]
        public byte TextureReverse
        {
            get { return Particle.ParticleData.TextureReverse; }
            set { Particle.ParticleData.TextureReverse = value; }
        }

        [Category("Misc")]
        public uint mTexture1
        {
            get { return Particle.ParticleData.mTexture1; }
        }

        [Category("Misc")]
        public uint mTexture2
        {
            get { return Particle.ParticleData.mTexture2; }
        }

        [Category("Misc")]
        public uint mTexture3
        {
            get { return Particle.ParticleData.mTexture3; }
        }

        [Category("Misc")]
        public byte RotateOffsetRandom1
        {
            get { return Particle.ParticleData.RotateOffsetRandom1; }
            set { Particle.ParticleData.RotateOffsetRandom1 = value; }
        }

        [Category("Misc")]
        public byte RotateOffsetRandom2
        {
            get { return Particle.ParticleData.RotateOffsetRandom2; }
            set { Particle.ParticleData.RotateOffsetRandom2 = value; }
        }

        [Category("Misc")]
        public byte RotateOffsetRandom3
        {
            get { return Particle.ParticleData.RotateOffsetRandom3; }
            set { Particle.ParticleData.RotateOffsetRandom3 = value; }
        }

        [Category("Misc")]
        public float[] RotateOffset
        {
            get { return Particle.ParticleData.RotateOffset; }
            set { Particle.ParticleData.RotateOffset = value; }
        }

        [Category("References")]
        public byte AlphaCompareRef0
        {
            get { return Particle.ParticleData.AlphaCompareRef0; }
            set { Particle.ParticleData.AlphaCompareRef0 = value; }
        }

        [Category("References")]
        public byte AlphaCompareRef1
        {
            get { return Particle.ParticleData.AlphaCompareRef1; }
            set { Particle.ParticleData.AlphaCompareRef1 = value; }
        }

        [Category("References")]
        public string TexRef1
        {
            get { return Particle.ParticleData.TexRef1; }
            set 
            { 
                Particle.ParticleData.TexRef1 = value;
                Particle.ParticleData.TexRef1Length = (ushort)(value.Length + 1);
            }
        }

        [Category("References")]
        public string TexRef2
        {
            get { return Particle.ParticleData.TexRef2; }
            set
            {
                Particle.ParticleData.TexRef2 = value;
                Particle.ParticleData.TexRef2Length = (ushort)(value.Length + 1);
            }
        }

        [Category("References")]
        public string TexRef3
        {
            get { return Particle.ParticleData.TexRef3; }
            set
            {
                Particle.ParticleData.TexRef3 = value;
                Particle.ParticleData.TexRef3Length = (ushort)(value.Length + 1);
            }
        }

        public ParticleDataNode(Particle particle) : base("Particle")
        {
            this.Particle = particle;
            SetImage("bolt");
        }
    }
}
