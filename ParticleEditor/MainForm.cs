using ParticleEditor.Control;
using ParticleEditor.Serial;

namespace ParticleEditor
{
    public sealed partial class MainForm : Form
    {
        BREFF? Breff;

        public MainForm()
        {
            InitializeComponent();
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
                fileTreeView.Nodes.Clear();
                byte[] buffer = File.ReadAllBytes(ofd.FileName);
                Breff = new BREFF(buffer);
                BREFFDataNode breffNode = new BREFFDataNode(Breff);
                fileTreeView.Nodes.Add(breffNode.GetTreeNode());
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Breff == null)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Breff.ProjectHeader.Name;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                byte[] buffer = Breff.Write();
                File.WriteAllBytes(sfd.FileName, buffer);
            }
        }

        private void fileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (fileTreeView.SelectedNode != null)
                propertyGrid.SelectedObject = fileTreeView.SelectedNode.Tag;
        }
    }
}