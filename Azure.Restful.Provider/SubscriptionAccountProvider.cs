using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Azure.Restful.Model;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class SubscriptionAccountProvider : BaseProvider<SubscriptionAccount>
    {
        private readonly string configPath;

        private static readonly object _locker = new object();

        private SubscriptionAccountProvider()
            : base(null)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            configPath = Path.Combine(appData, "EasyWACloudConfig");
            if (!Directory.Exists(configPath))
            {
                Directory.CreateDirectory(configPath);
            }
            configPath = Path.Combine(configPath, "config.xml");
        }

        private static SubscriptionAccountProvider _accountProvider;

        public static SubscriptionAccountProvider UniqueInstance
        {
            get
            {
                if (_accountProvider == null)
                {
                    lock (_locker)
                    {
                        _accountProvider = new SubscriptionAccountProvider();
                    }
                }
                return _accountProvider;
            }
        }

        public override IEnumerable<SubscriptionAccount> GetList()
        {
            if (File.Exists(configPath))
            {
                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(configPath);
                    List<SubscriptionAccount> result = EwacSeriazlizer.ToObject<List<SubscriptionAccount>>(document.OuterXml);
                    return result;
                }
                catch (Exception)
                { }
            }
            return new List<SubscriptionAccount>();
        }

        public override bool Create(SubscriptionAccount entity)
        {
            IList<SubscriptionAccount> list = GetList().ToList();
            if (list.Any(v => v.SubscriptionId == entity.SubscriptionId))
            {
                var value = list.Single(v => v.SubscriptionId == entity.SubscriptionId);
                list.Remove(value);
            }
            list.Add(entity);
            return Save(list);
        }

        public override bool Delete(SubscriptionAccount entity)
        {
            IList<SubscriptionAccount> list = GetList().ToList();
            if (list.Any(v => v.SubscriptionId == entity.SubscriptionId))
            {
                var value = list.Single(v => v.SubscriptionId == entity.SubscriptionId);
                list.Remove(value);
            }
            return Save(list);
        }

        public override bool Update(SubscriptionAccount entity)
        {
            return Create(entity);
        }

        public SubscriptionAccount GetSingle(Guid id)
        {
            IList<SubscriptionAccount> list = GetList().ToList();
            if (list.Any(v => v.SubscriptionId == id))
            {
                return list.Single(v => v.SubscriptionId == id);
            }
            return null;
        }

        private bool Save(IList<SubscriptionAccount> list)
        {
            string xml = EwacSeriazlizer.ToXml(list as List<SubscriptionAccount>);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(configPath);
            return true;
        }
    }
}
