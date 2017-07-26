using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ReportExporter
{
    public class StyleSection : ConfigurationSection
    {
        [ConfigurationProperty("Widths", IsRequired = false)]
        //[ConfigurationCollection(typeof(Widths), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public Widths Widths
        {
            get
            {
                return (Widths)base["Widths"];
            }
            set
            {
                base["Widths"] = value;
            }
        }
    }

    [ConfigurationCollection(typeof(WidthSection), AddItemName = "Width", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class Widths : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WidthSection();
            //throw new NotImplementedException();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WidthSection)element).index;
            //throw new NotImplementedException();
        }

        public WidthSection this[int i]
        {
            get
            {
                return (WidthSection)base.BaseGet(i);
            }
        }

        public WidthSection this[string key]
        {
            get
            {
                return (WidthSection)base.BaseGet(key);
            }
        }

        //[ConfigurationProperty("Width")]
        //[ConfigurationCollection(typeof(WidthSection), AddItemName = "Width")]
        //public WidthSection Width
        //{
        //    get
        //    {
        //        return this["index"];
        //    }
        //}
    }

    //自定义列宽配置类
    public class WidthSection : ConfigurationElement
    {
        [ConfigurationProperty("index", IsRequired = true, IsKey = true)]
        public string index
        {
            get
            {
                return (string)base["index"];
            }
        }

        [ConfigurationProperty("width", IsRequired = true, DefaultValue = 10)]
        public int width
        {
            get
            {
                return (int)base["width"];
            }
        }
    }
}