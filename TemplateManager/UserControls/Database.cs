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
            dataGridViewParameters.Rows.Clear();
            foreach (string key in ProjectContainer.GetInstance().ConnectionStrings.Keys)
            {
                dataGridViewParameters.Rows.Add(key, ProjectContainer.GetInstance().ConnectionStrings[key]);
            }        
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ProjectContainer.GetInstance().ConnectionStrings.Clear();
            ProjectContainer.GetInstance().ConnectionStrings = ConvertGridToDictionary();
            ProjectContainer.GetInstance().SaveConnectionStrings();
            Classes.Mediation.FormMediator.GetInstance().SendMessage("Database Settings Updated");
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
