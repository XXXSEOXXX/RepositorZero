using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel.Configuration;

namespace Client.BaseClass
{
    public sealed class ConfigSectionGroupWrite : ConfigurationSectionGroup
    {

        // 摘要:
        //     获取包含行为元素子项的配置节。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.BehaviorsSection。
        public BehaviorsSection Behaviors { get; set; }
        //
        // 摘要:
        //     获取包含所有绑定的配置节。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.BindingsSection。
        public BindingsSection Bindings { get; set; }
        /// <summary>
        /// 获取或设置一个配置节，该配置节包含客户端用来连接到服务的终结点的列表
        /// </summary>
        public ConfigSectionWrite Client {
            get { 
                return this.Client; 
            }
            set
            { 
            }
                                    }
        //
        // 摘要:
        //     获取一个配置节，该配置节定义 COM+ 互操作性中所用服务协定的命名空间与协定名称。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.ComContractsSection。
        public ComContractsSection ComContracts { get; set; }
        //
        // 摘要:
        //     获取一个配置节，该配置节包含一个行为列表，其中所含的行为在 behaviors 节中的行为应用之前应用到计算机上的所有 WCF 服务。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.CommonBehaviorsSection。
        public CommonBehaviorsSection CommonBehaviors { get; set; }
        //
        // 摘要:
        //     获取 WCF 的诊断功能的配置节。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.DiagnosticSection。
        public DiagnosticSection Diagnostic { get; set; }
        //
        // 摘要:
        //     获取定义所有扩展的配置节。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.ExtensionsSection。
        public ExtensionsSection Extensions { get; set; }
        //
        // 摘要:
        //     获取一个配置节，该配置节定义服务宿主环境要为特定传输实例化哪个类型。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.ServiceHostingEnvironmentSection。
        public ServiceHostingEnvironmentSection ServiceHostingEnvironment { get; set; }
        //
        // 摘要:
        //     获取定义服务集合的配置节。
        //
        // 返回结果:
        //     一个 System.ServiceModel.Configuration.ServicesSection。
        public ServicesSection Services { get; set; }
    }
}
