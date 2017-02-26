using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Data.Serializers
{
    public class SerializationHelper
    {
        public static string Serialize(object value)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;

            return JsonConvert.SerializeObject(value, settings);
        }

        public static T Deserialize<T>(string text)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            return JsonConvert.DeserializeObject<T>(text, settings);

        }
    }
}
