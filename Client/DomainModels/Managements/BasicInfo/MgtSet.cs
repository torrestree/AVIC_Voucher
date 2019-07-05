using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.Indept;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client.DomainModels.Managements.BasicInfo
{
    public class MgtSet : MgtData<SqlConn>
    {
        public MgtSet(string filepath)
        {
            Serializer = new XmlSerializer(typeof(List<SqlConn>));
            FilePath = filepath;
        }

        public string FilePath { get; set; }
        /// <summary>
        /// Serializer
        /// </summary>
        public XmlSerializer Serializer { get; set; }

        public bool ReadContents()
        {
            if (File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.Open);
                try
                {
                    Contents = Serializer.Deserialize(fs) as List<SqlConn>;
                    ListView = Contents.AsICV();
                    return true;
                }
                catch (Exception ex) { return ReadFailed(ex); }
                finally { fs.Close(); }
            }
            else
            {
                Contents = new List<SqlConn>();
                return true;
            }
        }
        public bool Add()
        {
            try
            {
                Entity = new SqlConn();
                IsNew = true;
                return true;
            }
            catch(Exception ex) { return AddFailed(ex); }
        }
        public bool Delete()
        {
            if (Entity == null) return false;
            FileStream fs = new FileStream(FilePath, FileMode.Create);
            try
            {
                Contents.Remove(Entity);
                Serializer.Serialize(fs, Contents);
                IsNew = false;
                return true;
            }
            catch(Exception ex) { return DeleteFailed(ex); }
            finally { fs.Close(); }
        }
        public bool Save(string password)
        {
            if (Entity == null) return false;
            FileStream fs = new FileStream(FilePath, FileMode.Create);
            try
            {
                Entity.Password = password;
                if (IsNew)
                    Contents.Add(Entity);
                Serializer.Serialize(fs, Contents);
                IsNew = false;
                Msg = MsgSaveOK;
                return true;
            }
            catch(Exception ex) { return SaveFailed(ex); }
            finally { fs.Close(); }
        }

        protected override bool SetSearchRule(SqlConn obj)
        {
            return obj.ID.NoCaseContains(SearchValue) || obj.Name.NoCaseContains(SearchValue);
        }
    }
}
