namespace ParticleEditor.Serial
{
    public class BREFF
    {
        public class _Header
        {
            public uint Magic;
            public ushort ByteOrder;
            public ushort Version;
            public uint FileLength;
            public ushort HeaderLength;
            public ushort BlocksAmount;

            public _Header()
            {
                Magic = 0x52454646;
                ByteOrder = 0xFEFF;
                Version = 9;
                FileLength = 0;
                HeaderLength = 0x10;
                BlocksAmount = 1;
            }

            public _Header(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
                if (Magic != 0x52454646)
                    throw new InvalidDataException();

                ByteOrder       = reader.ReadUInt16();
                Version         = reader.ReadUInt16();
                FileLength      = reader.ReadUInt32();
                HeaderLength    = reader.ReadUInt16();
                BlocksAmount    = reader.ReadUInt16();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Magic);
                writer.WriteUInt16(ByteOrder);
                writer.WriteUInt16(Version);
                writer.WriteUInt32(FileLength);
                writer.WriteUInt16(HeaderLength);
                writer.WriteUInt16(BlocksAmount);
            }

            public int SectionSize()
            {
                return 0x10;
            }
        }

        public class _BlockHeader
        {
            public uint Magic;
            public uint SectionLength;

            public _BlockHeader()
            {
                Magic = 0x52454646;
                SectionLength = 0;
            }

            public _BlockHeader(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
                if (Magic != 0x52454646)
                    throw new InvalidDataException();

                SectionLength = reader.ReadUInt32();
            }

            //////////////////////////////////////
            //////////////////////////////////////

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Magic);
                writer.WriteUInt32(SectionLength);
            }

            public int SectionSize()
            {
                return 0x04 + 0x04;
            }
        }

        public class _ProjectHeader
        {
            public uint Length;
            public uint PreviousProject;
            public uint NextProject;
            public ushort NameLength;
            public ushort Padding;
            public string Name;

            public _ProjectHeader()
            {
                PreviousProject = 0;
                NextProject = 0;
                Padding = 0;
                Name = "Untitled.breff";
                NameLength = (ushort)(Name.Length + 1);
                Length = (uint)SectionSize();
            }

            public _ProjectHeader(EndianReader reader)
            {
                reader.PushPosition();

                Length = reader.ReadUInt32();
                PreviousProject = reader.ReadUInt32();
                NextProject = reader.ReadUInt32();
                NameLength = reader.ReadUInt16();
                Padding = reader.ReadUInt16();
                Name = reader.ReadStringNT();

                reader.Position = reader.PopPosition() + (int)Length;
            }

            /////////////////////////////
            /////////////////////////////

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Length);
                writer.WriteUInt32(PreviousProject);
                writer.WriteUInt32(NextProject);
                writer.WriteUInt16(NameLength);
                writer.WriteUInt16(Padding);
                writer.WriteStringNT(Name);
            }

            public int SectionSize()
            {
                return 0x04 + 0x04 + 0x04 + 0x02 + 0x02 + NameLength;
            }
        }

        public class _Table
        {
            public uint Length;
            public ushort EntryAmount;
            public ushort Padding;
            public List<_TableItem> Entries;

            public _Table()
            {
                Length = 0x04 + 0x02 + 0x02;
                EntryAmount = 0;
                Padding = 0;
                Entries = new List<_TableItem>();
            }

            public _Table(EndianReader reader)
            {
                reader.PushPosition();
                Length = reader.ReadUInt32();
                EntryAmount = reader.ReadUInt16();
                Padding = reader.ReadUInt16();
                Entries = new List<_TableItem>();

                for (int i = 0; i < EntryAmount; i++)
                    Entries.Add(new _TableItem(reader));
            }

            //////////////////////////////////////
            //////////////////////////////////////

            public void Write(EndianWriter writer)
            {
                int tableStart = writer.Position;

                writer.WriteUInt32(Length);
                writer.WriteUInt16(EntryAmount);
                writer.WriteUInt16(Padding);
                foreach (_TableItem item in Entries)
                    item.Write(writer, tableStart);
            }

            public int SectionSize() 
            {
                int size = 0x04 + 0x02 + 0x02;
                foreach(_TableItem item in this.Entries)
                    size += item.SectionSize();

                return size;
            }
        }

        public class _TableItem
        {
            public ushort NameLength;
            public string Name;
            public uint DataOffset;
            public uint DataSize;
            public Emitter Emitter;
            public Particle Particle;

            public _TableItem(EndianReader reader)
            {
                NameLength = reader.ReadUInt16();
                Name = reader.ReadStringNT();
                DataOffset = reader.ReadUInt32();
                DataSize = reader.ReadUInt32();

                int tableStartPos = reader.PeekPosition();
                reader.PushPosition();
                reader.Position = tableStartPos + (int)DataOffset;

                Emitter = new Emitter(reader);
                Particle = new Particle(reader);

                reader.Position = reader.PopPosition();
            }

            //////////////////////////////////////
            //////////////////////////////////////

            public void Write(EndianWriter writer, int tableStart)
            {
                writer.WriteUInt16(NameLength);
                writer.WriteStringNT(Name);
                writer.WriteUInt32(DataOffset);
                writer.WriteUInt32(DataSize);

                // Jump to DataOffset, write subfile bytes, jump back to previous position
                writer.PushPosition();
                writer.Position = (int)DataOffset + tableStart;

                Emitter.Write(writer);
                Particle.Write(writer);

                writer.Position = writer.PopPosition();
            }

            public int SectionSize()
            {
                return 0x02 + NameLength + 0x04 + 0x04;
            }
        }

        /////////////////////////////
        /////////////////////////////

        public _Header Header { get; set; }
        public _BlockHeader BlockHeader { get; set; }
        public _ProjectHeader ProjectHeader { get; set; }
        public _Table Table { get; set; }

        /// <summary>
        /// Create new empty BREFF
        /// </summary>
        public BREFF()
        {
            Header = new _Header();
            BlockHeader = new _BlockHeader();
            ProjectHeader = new _ProjectHeader();
            Table = new _Table();
        }

        /// <summary>
        /// Create new BREFF from byte array and filename
        /// </summary>
        /// <param name="buffer">File bytes</param>
        /// <param name="filename">File path or name</param>
        public BREFF(byte[] buffer)
        {   
            EndianReader reader = new EndianReader(buffer, Endianness.BigEndian);
            try
            {
                Header = new _Header(reader);
                BlockHeader = new _BlockHeader(reader);
                ProjectHeader = new _ProjectHeader(reader);
                Table = new _Table(reader);
            }
            finally
            {
                reader.Close();
            }
        }

        /////////////////////////////
        /////////////////////////////

        /// <summary>
        /// Calculates the internal file data (e.g. subfile offsets)
        /// </summary>
        private void CalculateVariables()
        {
            // Header Vars
            int size = Header.SectionSize() + BlockHeader.SectionSize() + ProjectHeader.SectionSize() + Table.SectionSize();
            foreach (_TableItem item in Table.Entries)
                size += (int)item.DataSize;

            Header.FileLength = (uint)size;

            // BlockHeader Vars
            size = ProjectHeader.SectionSize() + Table.SectionSize();
            foreach (_TableItem item in Table.Entries)
                size += (int)item.DataSize;

            BlockHeader.SectionLength = (uint)size;

            // ProjectHeader Vars
            ProjectHeader.Length = (uint)ProjectHeader.SectionSize();

            // Table Vars
            Table.Length = (uint)Table.SectionSize();
            Table.EntryAmount = (ushort)Table.Entries.Count;

            // Table Items
            size = Table.SectionSize() + 1;
            foreach (_TableItem item in Table.Entries)
            {
                item.DataOffset = (ushort)size;
                size += (int)item.DataSize;
            }
        }

        /////////////////////////////
        /////////////////////////////

        /// <summary>
        /// Serializes BREFF instance to a new byte array
        /// </summary>
        /// <returns>BREFF file bytes</returns>
        public byte[] Write()
        {
            MemoryStream stream = new MemoryStream();
            EndianWriter writer = new EndianWriter(stream, Endianness.BigEndian);
            try
            {
                CalculateVariables();
                Header.Write(writer);
                BlockHeader.Write(writer);
                ProjectHeader.Write(writer);
                Table.Write(writer);
            }
            finally
            {
                stream.Close();
                writer.Close();
            }

            return stream.ToArray();
        }
    }
}
