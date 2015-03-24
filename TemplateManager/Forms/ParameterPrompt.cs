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
        public bool Saved { get; set; }
        public ParameterPrompt(string key)
        {
            InitializeComponent();
            this.labelKey.Text = key;
            this.Value = string.Empty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Value = textBoxValue.Text;
            this.Saved = true;
            this.Close();
        }

        private void ParameterPrompt_Load(object sender, EventArgs e)
        {
            textBoxValue.Select();       
        }
    }
}
