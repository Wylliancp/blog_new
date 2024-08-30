using Blog.Signal.Models;
using Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Signal.Services
{
    public class StockData : IStockData
    {
        private string _connectionString;// = "Server=localhost;Database=PostDb;User Id=sa;Password=SwN12345678;Encrypt=False;TrustServerCertificate=True";
        private IEnumerable<PostModel> models = new List<PostModel>();

        public StockData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
            SqlDependency.Start(_connectionString);
        }

        public async Task<PostModel> GetPostsCount()
        {
            try
            {
                string consulta = "SELECT * FROM Post";

                using (SqlConnection connection = new(_connectionString))
                {
                    using (SqlCommand command = new(consulta, connection))
                    {
                        connection.Open();

                        // Configurando o SqlCommand para notificação
                        command.Notification = null;
                        SqlDependency dependency = new SqlDependency(command);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        using (var reader = command.ExecuteReader())
                            models = reader.Cast<IDataRecord>()
                                .Select(x => new PostModel()
                                {
                                    Title = x.GetString(3),
                                }).ToList();
                        //command.ExecuteReader();
                    }
                    connection.Close();
                }
                //var posts = _repository.GetAll();
                //Aqui esta propositalmente, tive um problema com a geracao da migrate! e como estou usando um banco InMemory... N pega a mesma instacia da API
                Random rnd = new Random();
    
                var number = rnd.Next(1, 50);
                return new PostModel(title: "Soma de Post", sum: models.Count()); //number);//
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
