using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ServiceModel.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace Client.BaseClass
{
    public sealed class ConfigSectionWrite : ConfigurationSection
    {

        /// <summary>
        /// 获取或设置客户端可以连接的终结点的列表。
        /// </summary>

        [ConfigurationProperty("192.168.4.3:8100", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public ChannelEndpointElementCollection Endpoint8100
        {
            get { return this["address"] as ChannelEndpointElementCollection; }
            set { this["address"] = value; }
        }

        [ConfigurationProperty("192.168.4.3:9150", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public ChannelEndpointElementCollection Endpoint9150
        {
            get;
            set;
        }
    }
}
