using ParticleEditor.Serial;

namespace ParticleEditor
{
    public sealed partial class MainForm : Form
    {
        private BREFF? BREFF;

        public MainForm()
        {
            InitializeComponent();
        }

        ///////////////////////////////////
        ///////////////////////////////////

        private void Populate()
        {
            if (BREFF == null)
                throw new Exception("File is not loaded");

            fileTreeView.Nodes.Clear();
            TreeNode root = new TreeNode(BREFF.ProjectHeader.Name);
            foreach (BREFF._TableItem item in BREFF.Table.Entries)
            {
                TreeNode itemNode = new TreeNode(item.Name);
                itemNode.Tag = item;
                root.Nodes.Add(itemNode);
            }

            fileTreeView.Nodes.Add(root);
        }

        ///////////////////////////////////
        ///////////////////////////////////

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BREFF Files (*.breff)|*.breff|BREFT Files (*.breft)|*.breft";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] buffer = File.ReadAllBytes(ofd.FileName);
                BREFF = new BREFF(buffer, ofd.FileName);
                Populate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BREFF = new BREFF();
            Populate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BREFF == null)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = BREFF.FileName;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, BREFF.Write());
            }
        }
    }
}