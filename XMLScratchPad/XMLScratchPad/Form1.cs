using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XMLScratchPad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
           XElement xml = Codenesium.GenerationLibrary.Database.MSSQL.GetFieldListFromStoredProcedure("prms_insert_call",@"data source=10.150.100.101\mssqlserver2012;initial catalog=PSDATACadMultiRMS;user id=silverblade;password=S1lv3rblade;");


           // XElement xml = XElement.Parse(textBoxInput.Text);

            //var tables = from t in xml.Descendants()
            //                  where t.Attribute("name") != null && t.Attribute("name").Value == "tables"
            //                select t;

            //var fields = from f in xml.Descendants()
            //             where f.Attribute("name") != null && f.Attribute("name").Value == "fields"
            //             select f;

            //var fieldList = (from fi in xml.Elements("field")
            //                 select new
            //                 {
            //                     name = from f in fi.Elements("children").Elements("attribute") 
            //                              where f.Attribute("name").Value == "name"
            //                              select f.Attribute("value").Value.ToString(),
            //                     prettyName = from f in fi.Elements("children").Elements("attribute") 
            //                                  where f.Attribute("name").Value == "prettyName"
            //                                  select f.Attribute("value").Value.ToString(),
            //                     type = from f in fi.Elements("children").Elements("attribute") 
            //                            where f.Attribute("name").Value == "type"
            //                            select f.Attribute("value").Value.ToString(),
            //                     length = from f in fi.Elements("children").Elements("attribute") 
            //                               where f.Attribute("name").Value == "length"
            //                              select f.Attribute("value").Value.ToString()
            //                 }).ToList();

       

            var storedProcFieldList = (from fi in xml.Elements("children").Elements("field")
                             select new
                             {
                                 name = (from f in fi.Elements("children").Elements("attribute")
                                        where f.Attribute("name").Value == "name"
                                        select f.Attribute("value").Value).FirstOrDefault(),
                                 dataType = (from f in fi.Elements("children").Elements("attribute")
                                            where f.Attribute("name").Value == "dataType"
                                             select f.Attribute("value").Value).FirstOrDefault(),
                                 numericPrecision = (from f in fi.Elements("children").Elements("attribute")
                                                    where f.Attribute("name").Value == "numericPrecision"
                                                     select f.Attribute("value").Value).FirstOrDefault(),
                                 mode = (from f in fi.Elements("children").Elements("attribute")
                                        where f.Attribute("name").Value == "mode"
                                         select f.Attribute("value").Value).FirstOrDefault(),
                                 maxLength = (from f in fi.Elements("children").Elements("attribute")
                                             where f.Attribute("name").Value == "maxLength"
                                        select f.Attribute("value").Value).FirstOrDefault(),
                                 mappedDatabaseField = (from f in fi.Elements("children").Elements("attribute")
                                             where f.Attribute("name").Value == "mappedDatabaseField"
                                                        select f.Attribute("value").Value).FirstOrDefault()

                             }).ToList();

            string first = storedProcFieldList[0].name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x1 = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Codenesium.Foundation.Web.Contracts;

namespace FermataFish
{
    public partial class UserRepository :IUserRepository
    {
        FermataFishEntities _objCtx;
        IUserMapper _mapper;
        public UserRepository(FermataFishEntities context, IUserMapper mapper)
        {
            this._objCtx = context;
            this._mapper = mapper;
        }

        public IUser  Create(IUser item)
        {
            user newRecord = new user ();
            this._mapper.MapBOToEF(item, newRecord);
            this._objCtx.user.Add(newRecord);
            this._objCtx.SaveChanges();
            return this._mapper.MapEFToBO(newRecord);
        }

        public void Update(IUser item)
        {
            user  existingRecord = this._objCtx.user.FirstOrDefault(x => x.id == item.Id);
            this._mapper.MapBOToEF(item, existingRecord);
            this._objCtx.SaveChanges();
        }

        public void SoftDelete(int id)
        {
            user  existingRecord = this._objCtx.user.FirstOrDefault(x => x.id == id);
            existingRecord.recordStatus = -1;
            this._objCtx.SaveChanges();
        }

        public void HardDelete(int id)
        {
            user  existingRecord = this._objCtx.user.FirstOrDefault(x => x.id == id);
            if (existingRecord == null)
            {
                return;
            }
            else
            {
                this._objCtx.user .Remove(existingRecord);
                this._objCtx.SaveChanges();
            }
        }

        private List<user > SelectLinqEF(Expression<Func<user , bool>> predicate)
        {
            List<user > list = this._objCtx.Set<user >().Where(predicate).ToList<user >();
            return list;
        }

        private List<ICNUser> SelectLinqBO(Expression<Func<user , bool>> predicate)
        {
            List<user > list = SelectLinqEF(predicate);
            List<ICNUser> response = new List<ICNUser>();
            list.ForEach(x => response.Add(this._mapper.MapEFToBO(x)));
            return response;    
        }

        public ICNUser SelectByID(int id)
        {
            user  item = SelectLinqEF(x => x.id == id && x.recordStatus == Constants.RecordCreated).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            else
            {
                return this._mapper.MapEFToBO(item);
            }
        }

        public ICNUser SelectByIDIncludeDeleted(int id)
        {
            user  item = SelectLinqEF(x => x.id == id && (x.recordStatus == Constants.RecordCreated || x.recordStatus == Constants.RecordDeleted)).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            else
            {
                return this._mapper.MapEFToBO(item);
            }
        }
    }
}";
            string x2 = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Codenesium.Foundation.Web.Contracts;

namespace FermataFish
{
         public partial class UserRepository :IUserRepository
    {
        FermataFishEntities _objCtx;
        IUserMapper _mapper;
        public UserRepository(FermataFishEntities context, IUserMapper mapper)
        {
            this._objCtx = context;
            this._mapper = mapper;
        }

        public IUser  Create(IUser item)
        {
            user newRecord = new user ();
            this._mapper.MapBOToEF(item, newRecord);
            this._objCtx.user.Add(newRecord);
            this._objCtx.SaveChanges();
            return this._mapper.MapEFToBO(newRecord);
        }

        public void Update(IUser item)
        {
            user  existingRecord = this._objCtx.user.FirstOrDefault(x => x.id == item.Id);
            this._mapper.MapBOToEF(item, existingRecord);
            this._objCtx.SaveChanges();
        }

        public void SoftDelete(int id)
        {
            user  existingRecord = this._objCtx.user.FirstOrDefault(x => x.id == id);
            existingRecord.recordStatus = -1;
            this._objCtx.SaveChanges();
        }

        public void HardDelete(int id)
        {
            user  existingRecord = this._objCtx.user.FirstOrDefault(x => x.id == id);
            if (existingRecord == null)
            {
                return;
            }
            else
            {
                this._objCtx.user .Remove(existingRecord);
                this._objCtx.SaveChanges();
            }
        }

        private List<user > SelectLinqEF(Expression<Func<user , bool>> predicate)
        {
            List<user > list = this._objCtx.Set<user >().Where(predicate).ToList<user >();
            return list;
        }

        private List<ICNUser> SelectLinqBO(Expression<Func<user , bool>> predicate)
        {
            List<user > list = SelectLinqEF(predicate);
            List<ICNUser> response = new List<ICNUser>();
            list.ForEach(x => response.Add(this._mapper.MapEFToBO(x)));
            return response;    
        }

        public ICNUser SelectByID(int id)
        {
            user  item = SelectLinqEF(x => x.id == id && x.recordStatus == Constants.RecordCreated).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            else
            {
                return this._mapper.MapEFToBO(item);
            }
        }

        public ICNUser SelectByIDIncludeDeleted(int id)
        {
            user  item = SelectLinqEF(x => x.id == id && (x.recordStatus == Constants.RecordCreated || x.recordStatus == Constants.RecordDeleted)).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            else
            {
                retuurn this._mapper.MapEFToBO(item);
            }
        }
    }
}";

            string xd1 = AppendHash(x1);
            string xd2 = AppendHash(x2);
        }

        private string AppendHash(string input)
        {
            string data = input.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
            return input + Environment.NewLine + "//GeneratorFileHash:" + GenerateHash(data);
        }

        /// <summary>
        /// Generate an MD5 hash of a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GenerateHash(string input)
        {
            System.Security.Cryptography.MD5Cng crypt = new System.Security.Cryptography.MD5Cng();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }
    }
}
