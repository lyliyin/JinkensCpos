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
using System.IO;

namespace DataCommTools
{
    /// <summary>
    /// 依赖注入工厂
    /// </summary>
    public class IOCFactory
    {
        private static object _SyncHelper = new object();
        private static Dictionary<string, IUnityContainer> _UnityContainerDictionary = new Dictionary<string, IUnityContainer>();

        /// <summary>
        /// 根据containerName获取指定的container
        /// </summary>
        /// <param name="containerName">配置的containerName，默认为defaultContainer</param>
        /// <returns></returns>
        public static IUnityContainer GetContainer(string containerName = "ruanmouContainer")
        {
            if (!_UnityContainerDictionary.ContainsKey(containerName))
            {
                lock (_SyncHelper)
                {
                    if (!_UnityContainerDictionary.ContainsKey(containerName))
                    {
                        //配置UnityContainer
                        IUnityContainer container = new UnityContainer();
                        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");
                        Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                            ConfigurationUserLevel.None);
                        UnityConfigurationSection configSection = (UnityConfigurationSection)configuration
                            .GetSection(UnityConfigurationSection.SectionName);
                        configSection.Configure(container, containerName);

                        _UnityContainerDictionary.Add(containerName, container);
                    }
                }
            }
            return _UnityContainerDictionary[containerName];
        }

        public class UnityFactoryController : DefaultControllerFactory
        {
            private IUnityContainer UnityContainer
            {
                get
                {
                    return GetContainer();
                }
            }

            public IUnityContainer test()
            {
                IUnityContainer container = new UnityContainer();
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = string.Empty;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                //读取section
                UnityConfigurationSection section=(UnityConfigurationSection)config.GetSection(UnityConfigurationSection.SectionName);
                section.Configure(container);
                return container;
            }

            /// <summary>
            /// 获取实例
            /// </summary>
            /// <param name="requestContext"></param>
            /// <param name="controllerType"></param>
            /// <returns></returns>
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                if (null == controllerType)
                {
                    return null;
                }
                
                IController controller = (IController)this.UnityContainer.Resolve(controllerType);
                return controller;

            }

            /// <summary>
            /// 释放资源
            /// </summary>
            /// <param name="controller"></param>
            public override void ReleaseController(IController controller)
            {
                this.UnityContainer.Teardown(controller);//释放对象 
            }
        }
    }
}
