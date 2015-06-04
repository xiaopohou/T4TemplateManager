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
    public partial class FormTextViewer : MetroFramework.Forms.MetroForm
    {
        private string _text;
        public bool Saved { get; set; }
        public FormTextViewer(string text)
        {
            this._text = text;
            InitializeComponent();
        }

        public string Text
        {
            get
            {
                return this._text;
            }
        }

        private void FormTextViewer_Load(object sender, EventArgs e)
        {
            richTextBoxViewer.Text = this._text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Saved = true;
            this.Close();
        }
    }
}
