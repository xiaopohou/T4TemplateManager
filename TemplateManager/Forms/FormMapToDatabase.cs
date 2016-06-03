using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml.Linq;
namespace Codenesium.TemplateGenerator.Forms
{
    public partial class FormMapToDatabase : MetroFramework.Forms.MetroForm
    {
        public string SqlType{get;set;}
        public string MaxLength{get;set;}
        public string ColumnName { get; set; }
        XElement _fields;
        public FormMapToDatabase(string table,string connectionString)
        {
            InitializeComponent();
            LoadForm(table,connectionString);
           
        }

        public void LoadForm(string table,string connectionString)
        {
           this._fields = Codenesium.GenerationLibrary.Database.MSSQL.GetFieldListForTable(table, connectionString);
           List<string> fieldNames = (from f in this._fields.Descendants("field")
                                          select f.Element("COLUMN_NAME").Value).ToList();
           comboBoxFields.DataSource = fieldNames;
        }

        private void comboBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void comboBoxFields_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ColumnName = (from f in this._fields.Elements("field")
                         where f.Element("COLUMN_NAME").Value == comboBoxFields.Text
                         select f.Element("COLUMN_NAME").Value).FirstOrDefault();
            this.SqlType = (from f in this._fields.Elements("field")
                            where f.Element("COLUMN_NAME").Value == comboBoxFields.Text
                            select f.Element("DATA_TYPE").Value).FirstOrDefault();
            this.MaxLength = (from f in this._fields.Elements("field")
                              where f.Element("COLUMN_NAME").Value == comboBoxFields.Text
                              select f.Element("MAX_LENGTH").Value).FirstOrDefault();
            this.Close();
        }

        private void FormMapToDatabase_Activated(object sender, EventArgs e)
        {
            comboBoxFields.DroppedDown = true;
        }
    }
}
