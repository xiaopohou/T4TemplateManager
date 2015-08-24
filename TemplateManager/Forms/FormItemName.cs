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
    public partial class FormItemName : MetroFramework.Forms.MetroForm
    {
        public string Value { get; set; }
        public bool Saved { get; set; }
        public FormItemName(string formName)
        {
            InitializeComponent();
            this.Text = formName;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxValue.Text))
            {
                this.Saved = true;
                this.Value = textBoxValue.Text;
                this.Close();
            }
        }
    }
}
