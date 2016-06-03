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
        private string _textValue;
        public bool Saved { get; set; }
        public FormTextViewer(string text)
        {
            this._textValue = text;
            InitializeComponent();
        }

        public string TextValue
        {
            get
            {
                return this._textValue;
            }
        }

        private void FormTextViewer_Load(object sender, EventArgs e)
        {
            richTextBoxViewer.Text = this._textValue;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Saved = true;
            this.Close();
        }
    }
}
