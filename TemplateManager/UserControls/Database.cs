using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codenesium.TemplateGenerator.Classes.Generation;
namespace Codenesium.TemplateGenerator.UserControls
{
    public partial class Database : UserControl
    {
        public Database()
        {
            InitializeComponent();
            LoadForm();
            ProjectContainer.GetInstance().Reload += ProjectChanged;
        }

        private void ProjectChanged(object sender,EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            comboBoxProjects.DataSource = new BindingList<Project>(ProjectContainer.GetInstance().ProjectList);
            comboBoxProjects.DisplayMember = "Name";
            comboBoxProjects.ValueMember = "ID";
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewParameters.Rows.Clear();
            if (comboBoxProjects.SelectedIndex > -1)
            {
                Project project = (Project)comboBoxProjects.SelectedItem;
                foreach (string key in project.ConnectionStrings.Keys)
                {
                    dataGridViewParameters.Rows.Add(key, project.ConnectionStrings[key]);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedIndex > -1)
            {
                Project project = (Project)comboBoxProjects.SelectedItem;
                project.ConnectionStrings = ConvertGridToDictionary();
                ProjectContainer.GetInstance().Save(ProjectContainer.GetInstance().FileLocation);
            }
        }

        public Dictionary<string, string> ConvertGridToDictionary()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dataGridViewParameters.Rows)
            {

                string key = (row.Cells["key"].Value ?? String.Empty).ToString();
                string value = (row.Cells["value"].Value ?? String.Empty).ToString();
                if (key != String.Empty)
                {
                    parameters.Add(key, value);
                }
            }

            return parameters;
        }
    }
}
