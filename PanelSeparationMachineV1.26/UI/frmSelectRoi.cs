using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Sunny.UI;

namespace PanelSeparationMachineV1._26.UI
{
    public partial class frmSelectRoi : UIForm
    {
        public frmSelectRoi()
        {
            InitializeComponent();
        }

        private void frmSelectRoi_Load(object sender, EventArgs e)
        {

        }

        private void lblRoiSelect_Click(object sender, EventArgs e)
        {
            UILabel uILabel = sender as UILabel;

            switch (uILabel.Name)
            {
                case "lblRect1": AppData.RoiSelect = RoiSelect.Rectangle1; break;
                case "lblRect2": AppData.RoiSelect = RoiSelect.Rectangle2; break;
                case "lblCircle": AppData.RoiSelect = RoiSelect.Circle; break;
                case "lblRegion": AppData.RoiSelect = RoiSelect.Region; break;
            }

            this.Close();

        }
    }
}
