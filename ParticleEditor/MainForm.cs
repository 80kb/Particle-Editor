using ParticleEditor.Control;
using ParticleEditor.Serial;

namespace ParticleEditor
{ 
    public sealed partial class MainForm : Form
    {
        static ImageList _imageList;
        public static ImageList ImageList
        {
            get
            {
                if (_imageList == null)
                {
                    _imageList = new ImageList();
                    _imageList.Images.Add("page", Properties.Resources.page);
                    _imageList.Images.Add("box", Properties.Resources.box);
                    _imageList.Images.Add("folder", Properties.Resources.folder);
                    _imageList.Images.Add("light", Properties.Resources.light);
                    _imageList.Images.Add("bolt", Properties.Resources.bolt);
                }
                return _imageList;
            }
        }

        BREFF? Breff;

        public MainForm()
        {
            InitializeComponent();
            fileTreeView.ImageList = ImageList;
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