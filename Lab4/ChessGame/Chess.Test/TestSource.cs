using Chess.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chess.Test
{
    public static class TestSource
    {
        private const string MovementsFile = @"TestData\movements.json";
        public static IEnumerable<Movement> GetMovements()
        {
            var data = File.ReadAllText(MovementsFile);
            return JsonConvert.DeserializeObject<IEnumerable<Movement>>(data);
        }

        public static Movement GetMovement(string key)
        {
            var data = File.ReadAllText(MovementsFile);
            var json = JObject.Parse(data);
            var @object = json.Value<JObject>(key);
            return JsonConvert.DeserializeObject<Movement>(@object.ToString());
        }
    }
}
