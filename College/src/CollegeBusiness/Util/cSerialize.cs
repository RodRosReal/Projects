using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollegeBusiness.Util
{
    public class cSerialize
    {
        public static string XmlSerialize(object objectToSerialize)
        {
            System.Xml.Serialization.XmlSerializer serialize = new System.Xml.Serialization.XmlSerializer(objectToSerialize.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serialize.Serialize(sw, objectToSerialize);

            string ret = sw.ToString();
            sw.Close();
            sw.Dispose();

            return ret;
        }

        public static object XmlDeserialize(Type type, string objectToDeserialize)
        {
            System.IO.StringReader s = new System.IO.StringReader(objectToDeserialize);

            System.Xml.Serialization.XmlSerializer deserialize = new System.Xml.Serialization.XmlSerializer(type);
            object ret = deserialize.Deserialize(s);

            s.Close();
            s.Dispose();

            return ret;
        }
    }
}

