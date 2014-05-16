using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.ServiceModel.Configuration;

namespace Client
{
    public sealed class CustomSection:ConfigurationSection
    {
        [ConfigurationProperty("endpoint", IsRequired = true)]
        public CustomSectionElement Endpoint
        {
            get
            {
                return (CustomSectionElement)this["endpoint"];
            }
        }
    }

    public class CustomSectionElement : ConfigurationElement
    {
        [ConfigurationProperty("address", IsRequired = true)]
        public string Address
        {
            get
            {
                return this["address"].ToString();
            }
            set
            {
                this["address"] = value;
            }
        }

        [ConfigurationProperty("binding", IsRequired = true)]
        public string Binding
        {
            get
            {
                return this["binding"].ToString();
            }
            set
            {
                this["binding"] = value;
            }
        }
    }
}
