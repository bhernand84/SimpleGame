using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Entities;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using System.Xml;
using SimpleGame.Data.Serializers;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using SimpleGame.Data.DataAccessLayers.Models;

namespace SimpleGame.Data.DataAccessLayers
{
    public class GameDAL : DAL
    {
        public IEnumerable<Game> Get()
        {
            throw new NotImplementedException();
        }

        public Game Get(Guid gameId)
        {
            Game game = null;
            try
            {
                var table = GetGameTable();
                TableOperation retrieveOperation = TableOperation.Retrieve<SimpleEntity>("SimpleGame",gameId.ToString());

                TableResult query = table.Execute(retrieveOperation);

                if (query.Result != null)
                {
                    var row = ((SimpleEntity)query.Result);
                    game = SerializationHelper.Deserialize<Game>(row.gamedata);

                }
                else
                {
                    Console.WriteLine("The Product was not found.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return game;
        }

        public void Save(Game game)
        {
            string serializedGame = SerializationHelper.Serialize(game);

            CloudTable table = GetGameTable();

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();
            SimpleEntity entity = new SimpleEntity("SimpleGame", game.ID.ToString())
            {
                gamedata = serializedGame
            };
            // Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.InsertOrReplace(entity);

            // Execute the insert operation.
            table.Execute(insertOperation);
        }
        
        protected CloudTable GetGameTable()
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("games");
            return table;
        }
    }
}
