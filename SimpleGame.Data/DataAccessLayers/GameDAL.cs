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
using SimpleGame.Common.Enum;
using SimpleGame.Domain.Models;

namespace SimpleGame.Data.DataAccessLayers
{
    public class GameDAL : DAL
    {
        protected string partitionKey;

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
                TableOperation retrieveOperation = TableOperation.Retrieve<SimpleEntity>(partitionKey,gameId.ToString());

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

        public IEnumerable<Game> Get(GameStatus status)
        {
            List<Game> games = new List<Game>();
            try
            {
                var table = GetGameTable();
               TableQuery<SimpleEntity> query = new TableQuery<SimpleEntity>()
                                                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey))
                                                .Where(TableQuery.GenerateFilterCondition("gameStatus", QueryComparisons.Equal, status.ToString()));

                IEnumerable<SimpleEntity> results = table.ExecuteQuery(query);

                if (results != null)
                {
                    foreach (var result in results)
                    {
                        var game = SerializationHelper.Deserialize<Game>(result.gamedata);
                        games.Add(game);
                    }
                }
                else
                {
                    Console.WriteLine("The Gane was not found.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return games;
        }

        public void Save(Game game)
        {
            string serializedGame = SerializationHelper.Serialize(game);

            CloudTable table = GetGameTable();

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();
            SimpleEntity entity = new SimpleEntity(partitionKey, game.ID.ToString())
            {
                players = game.Players.Players.Count(),
                gameStatus = game.GameStatus.ToString(),
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

        public GameDAL(string partitionKey)
        {
            this.partitionKey = partitionKey;
        }
    }
}
