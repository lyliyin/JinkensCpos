using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace DataCommTools
{

    public static class IOCFactorys
    {
        private static Dictionary<string, IUnityContainer> dicContainer = new Dictionary<string, IUnityContainer>();
        public static IUnityContainer getContrainer(string sectionName = "liyin")
        {
            if (!dicContainer.Keys.Contains(sectionName))
            {
                IUnityContainer container = new UnityContainer();
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = string.Empty;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)config.GetSection(UnityConfigurationSection.SectionName);
                section.Configure(container);
                dicContainer.Add(sectionName, container);
            }

            return dicContainer[sectionName];
        }

        public static string toJson(this Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToEntity<T>(this string strs)
        {
            return JsonConvert.DeserializeObject<T>(strs);
        }

        public static string GetSourceNameById(this int? SourceId)
        {
            string SourceName = "未定义";
            switch (SourceId)
            {
                case 1:
                    SourceName = "商学院数据导入";
                    break;
                case 2:
                    SourceName = "曙光数据导入";
                    break;
                case 3:
                    SourceName = "京东商品爬虫";
                    break;
                case 4:
                    SourceName = "订单奖励";
                    break;
                case 5:
                    SourceName = "活动赠送";
                    break;
                case 6:
                    SourceName = "后台员工添加";
                    break;
                case 7:
                    SourceName = "后台员工Excel导入";
                    break;
            }
            return SourceName;
        }
    }
}
