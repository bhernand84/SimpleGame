using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Data.DataAccessLayers.Models
{
    public class SimpleEntity : TableEntity
    {
        public Guid id
        { get; set; }

        public string gamedata
        { get; set; }

        public SimpleEntity() { }
        public SimpleEntity(string partitionkey, string rowkey) : base(partitionkey, rowkey) { }
    }
}
