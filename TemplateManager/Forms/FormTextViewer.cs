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
    public partial class FormTextViewer : Form
    {
        private string _text;
        public FormTextViewer(string text)
        {
            this._text = text;
            InitializeComponent();
        }

        private void FormTextViewer_Load(object sender, EventArgs e)
        {
            richTextBoxViewer.Text = this._text;
        }
    }
}
