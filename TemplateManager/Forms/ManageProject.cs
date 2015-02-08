using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codenesium.TemplateGenerator.Classes.Generation;
namespace Codenesium.TemplateGenerator.Forms
{
    public partial class ManageProject : Form
    {
        public ManageProject()
        {
            InitializeComponent();
        }
        public void Refresh()
        {
            comboBoxProject.Items.Clear();
            comboBoxProject.DataSource = ProjectContainer.GetInstance().ProjectList;
            comboBoxProject.DisplayMember = "Name";
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxProject.SelectedIndex > -1)
            {
                Project project = (Project)comboBoxProject.SelectedItem;
                textBoxName.Text = project.Name;
            }
        }
    }
}
