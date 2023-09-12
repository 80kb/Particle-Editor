using System.Collections.Generic;
using System.Text;

namespace System.IO;

public sealed class EndianReader : IDisposable
{
    private byte[] Buffer;

    private Stream m;

    private Endianness _Endian;

    private int _Position;

    private Stack<int> PositionStack = new Stack<int>();

    public bool Disposed { get; private set; }

    public Stream Stream
    {
        get
        {
            if (this.m == null)
            {
                throw new NullReferenceException();
            }
            return this.m;
        }
    }

    public Endianness Endian
    {
        get
        {
            return this._Endian;
        }
        set
        {
            this._Endian = value;
        }
    }

    public int Position
    {
        get
        {
            if (this.m == null)
            {
                throw new NullReferenceException();
            }
            return this._Position;
        }
        set
        {
            if (this.m == null)
            {
                throw new NullReferenceException();
            }
            if (value < 0)
            {
                throw new ArgumentException("The position can't be negative");
            }
            this.m.Position = value;
            this._Position = value;
        }
    }

    public long StreamLength
    {
        get
        {
            if (this.m == null)
            {
                throw new NullReferenceException();
            }
            return this.m.Length;
        }
    }

    public EndianReader(Stream Stream, Endianness Endian)
    {
        if (Stream == null)
        {
            throw new NullReferenceException();
        }
        this.Disposed = false;
        this._Position = 0;
        this._Endian = Endian;
        this.m = Stream;
    }

    public EndianReader(byte[] Data, Endianness Endian)
    {
        if (Data.Length < 0)
        {
            throw new Exception("Array size cannot be less than or equal to 0");
        }
        this.Disposed = false;
        this._Position = 0;
        this._Endian = Endian;
        this.m = new MemoryStream(Data);
    }

    public void Close()
    {
        this.Dispose();
    }

    public void Dispose()
    {
        if (!this.Disposed)
        {
            GC.SuppressFinalize(this);
            if (this.m != null)
            {
                this.m.Close();
                this.m = null;
            }
            this._Position = 0;
            this.Disposed = true;
        }
    }

    private void Try(int Length)
    {
        if (this.m == null)
        {
            throw new NullReferenceException();
        }
        if (this._Position + Length > this.m.Length)
        {
            throw new EndOfStreamException();
        }
    }

    private void FillBuffer(int Count, int Stride)
    {
        this.Buffer = new byte[Count];
        this.m.Read(this.Buffer, 0, Count);
        this._Position += Count;
        if (this.Endian == Endianness.LittleEndian)
        {
            for (int i = 0; i < Count; i += Stride)
            {
                Array.Reverse(this.Buffer, i, Stride);
            }
        }
    }

    private static int GetEncodingSize(Encoding En)
    {
        if (En == Encoding.Unicode || En == Encoding.BigEndianUnicode)
        {
            return 2;
        }
        if (En == Encoding.UTF32)
        {
            return 4;
        }
        return 1;
    }

    public void PushPosition()
    {
        this.PositionStack.Push(this.Position);
    }

    public int PeekPosition()
    {
        return this.PositionStack.Peek();
    }

    public int PopPosition()
    {
        return this.PositionStack.Pop();
    }

    public void Align(int Alignment)
    {
        while (this.Position % Alignment != 0)
        {
            this.Position++;
        }
    }

    public byte ReadByte()
    {
        this.Try(1);
        this.FillBuffer(1, 1);
        return this.Buffer[0];
    }

    public byte[] ReadBytes(int Count)
    {
        this.Try(Count);
        this.FillBuffer(Count, 1);
        return this.Buffer;
    }

    public sbyte ReadSByte()
    {
        this.Try(1);
        this.FillBuffer(1, 1);
        return (sbyte)this.Buffer[0];
    }

    public sbyte[] ReadSBytes(int Count)
    {
        this.Try(Count);
        this.FillBuffer(Count, 1);
        sbyte[] array = new sbyte[Count];
        for (int i = 0; i < Count; i++)
        {
            array[i] = (sbyte)this.Buffer[i];
        }
        return array;
    }

    public ushort ReadUInt16()
    {
        this.Try(2);
        this.FillBuffer(2, 2);
        Array.Reverse(this.Buffer);
        return BitConverter.ToUInt16(this.Buffer, 0);
    }

    public ushort[] ReadUInt16s(int Count)
    {
        this.Try(2 * Count);
        this.FillBuffer(2 * Count, 2);
        ushort[] array = new ushort[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[2];
            Array.Copy(this.Buffer, i * 2, array2, 0, 2);
            Array.Reverse(array2);
            array[i] = BitConverter.ToUInt16(array2, 0);
        }
        return array;
    }

    public short ReadInt16()
    {
        this.Try(2);
        this.FillBuffer(2, 2);
        Array.Reverse(this.Buffer);
        return BitConverter.ToInt16(this.Buffer, 0);
    }

    public short[] ReadInt16s(int Count)
    {
        this.Try(2 * Count);
        this.FillBuffer(2 * Count, 2);
        short[] array = new short[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[2];
            Array.Copy(this.Buffer, i * 2, array2, 0, 2);
            Array.Reverse(array2);
            array[i] = BitConverter.ToInt16(array2, 0);
        }
        return array;
    }

    public uint ReadUInt24()
    {
        this.Try(3);
        this.FillBuffer(3, 3);
        return (uint)((this.Buffer[0] << 16) | (this.Buffer[1] << 8) | this.Buffer[2]);
    }

    public int ReadInt24()
    {
        this.Try(3);
        this.FillBuffer(3, 3);
        return (this.Buffer[0] << 16) | (this.Buffer[1] << 8) | this.Buffer[2];
    }

    public uint ReadUInt32()
    {
        this.Try(4);
        this.FillBuffer(4, 4);
        Array.Reverse(this.Buffer);
        return BitConverter.ToUInt32(this.Buffer, 0);
    }

    public uint[] ReadUInt32s(int Count)
    {
        this.Try(4 * Count);
        this.FillBuffer(4 * Count, 4);
        uint[] array = new uint[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[4];
            Array.Copy(this.Buffer, i * 4, array2, 0, 4);
            Array.Reverse(array2);
            array[i] = BitConverter.ToUInt32(array2, 0);
        }
        return array;
    }

    public int ReadInt32()
    {
        this.Try(4);
        this.FillBuffer(4, 4);
        Array.Reverse(this.Buffer);
        return BitConverter.ToInt32(this.Buffer, 0);
    }

    public int[] ReadInt32s(int Count)
    {
        this.Try(4 * Count);
        this.FillBuffer(4 * Count, 4);
        int[] array = new int[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[4];
            Array.Copy(this.Buffer, i * 4, array2, 0, 4);
            Array.Reverse(array2);
            array[i] = BitConverter.ToInt32(array2, 0);
        }
        return array;
    }

    public ulong ReadUInt64()
    {
        this.Try(8);
        this.FillBuffer(8, 8);
        Array.Reverse(this.Buffer);
        return BitConverter.ToUInt64(this.Buffer, 0);
    }

    public ulong[] ReadUInt64s(int Count)
    {
        this.Try(8 * Count);
        this.FillBuffer(8 * Count, 8);
        ulong[] array = new ulong[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[8];
            Array.Copy(this.Buffer, i * 8, array2, 0, 8);
            Array.Reverse(array2);
            array[i] = BitConverter.ToUInt64(array2, 0);
        }
        return array;
    }

    public long ReadInt64()
    {
        this.Try(8);
        this.FillBuffer(8, 8);
        Array.Reverse(this.Buffer);
        return BitConverter.ToInt64(this.Buffer, 0);
    }

    public long[] ReadInt64s(int Count)
    {
        this.Try(8 * Count);
        this.FillBuffer(8 * Count, 8);
        long[] array = new long[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[8];
            Array.Copy(this.Buffer, i * 8, array2, 0, 8);
            Array.Reverse(array2);
            array[i] = BitConverter.ToInt64(array2, 0);
        }
        return array;
    }

    public float ReadSingle()
    {
        this.Try(4);
        this.FillBuffer(4, 4);
        Array.Reverse(this.Buffer);
        return BitConverter.ToSingle(this.Buffer, 0);
    }

    public float ReadFloat()
    {
        return this.ReadSingle();
    }

    public float[] ReadSingles(int Count)
    {
        this.Try(4 * Count);
        this.FillBuffer(4 * Count, 4);
        float[] array = new float[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[4];
            Array.Copy(this.Buffer, i * 4, array2, 0, 4);
            Array.Reverse(array2);
            array[i] = BitConverter.ToSingle(array2, 0);
        }
        return array;
    }

    public float[] ReadFloats(int Count)
    {
        return this.ReadSingles(Count);
    }

    public double ReadDouble()
    {
        this.Try(8);
        this.FillBuffer(8, 8);
        Array.Reverse(this.Buffer);
        return BitConverter.ToDouble(this.Buffer, 0);
    }

    public double[] ReadDouble(int Count)
    {
        this.Try(8);
        this.FillBuffer(8 * Count, 8);
        double[] array = new double[Count];
        for (int i = 0; i < Count; i++)
        {
            byte[] array2 = new byte[8];
            Array.Copy(this.Buffer, i * 8, array2, 0, 8);
            array[i] = BitConverter.ToSingle(array2, 0);
        }
        return array;
    }

    public string ReadString(int Count)
    {
        this.Try(Count);
        this.FillBuffer(Count, 1);
        return Encoding.Default.GetString(this.Buffer);
    }

    public string ReadString(int Count, Encoding En)
    {
        this.Try(Count * EndianReader.GetEncodingSize(En));
        this.FillBuffer(Count * EndianReader.GetEncodingSize(En), EndianReader.GetEncodingSize(En));
        return En.GetString(this.Buffer);
    }

    public string ReadStringNT()
    {
        List<byte> list = new List<byte>();
        do
        {
            this.FillBuffer(1, 1);
            list.Add(this.Buffer[0]);
        }
        while (this.Buffer[0] != 0);
        list.RemoveAt(list.Count - 1);
        return Encoding.Default.GetString(list.ToArray());
    }

    public string ReadStringNT(Encoding En)
    {
        int encodingSize = EndianReader.GetEncodingSize(En);
        List<byte> list = new List<byte>();
        while (true)
        {
            this.FillBuffer(encodingSize, encodingSize);
            bool flag = true;
            for (int i = 0; i < encodingSize; i++)
            {
                if (this.Buffer[i] != 0)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                break;
            }
            list.AddRange(this.Buffer);
        }
        return En.GetString(list.ToArray());
    }

    public char ReadChar()
    {
        this.Try(1);
        this.FillBuffer(1, 1);
        return Encoding.Default.GetChars(this.Buffer)[0];
    }

    public char ReadChar(Encoding En)
    {
        this.Try(EndianReader.GetEncodingSize(En));
        this.FillBuffer(EndianReader.GetEncodingSize(En), EndianReader.GetEncodingSize(En));
        return En.GetString(this.Buffer)[0];
    }

    public char[] ReadChars(int Count)
    {
        this.Try(Count);
        this.FillBuffer(Count, 1);
        return Encoding.Default.GetChars(this.Buffer);
    }

    public char[] ReadChars(int Count, Encoding En)
    {
        this.Try(Count * EndianReader.GetEncodingSize(En));
        this.FillBuffer(Count * EndianReader.GetEncodingSize(En), EndianReader.GetEncodingSize(En));
        return En.GetChars(this.Buffer);
    }

    public string ReadName(int TotalLength)
    {
        this.Try(TotalLength);
        this.FillBuffer(TotalLength, 1);
        return Encoding.Default.GetString(this.Buffer).Replace("\0", "");
    }

    public string ReadName(int TotalLength, Encoding En)
    {
        this.Try(TotalLength);
        this.FillBuffer(TotalLength, 1);
        return En.GetString(this.Buffer).Replace("\0", "");
    }

    public int ReadVLQ()
    {
        try
        {
            this.FillBuffer(1, 1);
            byte b = this.Buffer[0];
            if (((b >> 7) & 1) == 0)
            {
                return b & 0x7F;
            }
            this.FillBuffer(1, 1);
            byte b2 = this.Buffer[0];
            if (((b2 >> 7) & 1) == 0)
            {
                return ((b & 0x7F) << 7) | (b2 & 0x7F);
            }
            this.FillBuffer(1, 1);
            byte b3 = this.Buffer[0];
            if (((b3 >> 7) & 1) == 0)
            {
                return ((b & 0x7F) << 14) | ((b2 & 0x7F) << 7) | (b3 & 0x7F);
            }
            this.FillBuffer(1, 1);
            byte b4 = this.Buffer[0];
            if (((b4 >> 7) & 1) == 0)
            {
                return ((b & 0x7F) << 21) | ((b2 & 0x7F) << 14) | ((b3 & 0x7F) << 7) | (b4 & 0x7F);
            }
        }
        catch (IndexOutOfRangeException)
        {
            throw new EndOfStreamException();
        }
        throw new Exception("Error at " + this.Position.ToString("X4") + ". Invalid VLQ.");
    }

    public int ReadSROffset()
    {
        int num = this.ReadInt32();
        if (num != 0)
        {
            num += this.Position - 4;
        }
        return num;
    }

    public ushort ReadBOM()
    {
        switch (this.ReadUInt16())
        {
            case 65279:
                return 65279;
            case 65534:
                this.Endian = ((this.Endian == Endianness.BigEndian) ? Endianness.LittleEndian : Endianness.BigEndian);
                return 65279;
            default:
                throw new BOMException();
        }
    }

    public float ReadFx16()
    {
        return (float)this.ReadInt16() / 4096f;
    }

    public float ReadFx32()
    {
        return (float)this.ReadInt32() / 4096f;
    }
}
