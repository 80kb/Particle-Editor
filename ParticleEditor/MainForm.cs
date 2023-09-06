using ParticleEditor.Control;
using ParticleEditor.Serial;

namespace ParticleEditor
{
    public sealed partial class MainForm : Form
    {
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
                byte[] buffer = File.ReadAllBytes(ofd.FileName);
                BREFF breff = new BREFF(buffer);
                BREFFDataNode breffNode = new BREFFDataNode(breff);
                fileTreeView.Nodes.Add(breffNode.GetTreeNode());
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (fileTreeView.SelectedNode != null)
                propertyGrid.SelectedObject = fileTreeView.SelectedNode.Tag;
        }
    }
}