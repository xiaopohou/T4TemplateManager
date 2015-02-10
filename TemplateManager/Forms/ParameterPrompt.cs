using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codenesium.TemplateGenerator.Forms
{
    public partial class ParameterPrompt : MetroFramework.Forms.MetroForm
    {
        public string Value { get; set; }
        public ParameterPrompt(string key)
        {
            InitializeComponent();
            this.labelKey.Text = key;
            this.Value = string.Empty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Value = textBoxValue.Text;
            this.Close();
        }

        private void textBoxValue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.Value = textBoxValue.Text;
                this.Close();
            }
        }
    }
}
