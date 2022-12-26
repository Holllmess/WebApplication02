using System.Data.SQLite;
using WebApplication02.Services;
using WebApplication02.Services.Implementation;

namespace WebApplication02
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //ConfigareSQLiteConnection();

            var builder = WebApplication.CreateBuilder(args);

            // Singleton - одиночка 
            // Scoped - создаються заново при каждом запросе от клиента 
            builder.Services.AddScoped<ICleintRepository, ClientRepository>();
            builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
            builder.Services.AddScoped<IPetRepository, PetRepository>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void ConfigareSQLiteConnection()
        {
            string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareShema(connection);
        }

        private static void PrepareShema(SQLiteConnection connection) 
        {
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = "DROP TABLE IF EXISTS Consultations";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Pets";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Clients";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE Clients(
                ClientsId INTEGER PRIMARY KEY,
                Document TEXT,
                SurName TEXT,
                FirstName TEXT,
                Patronymic TEXT,
                Birthday INTEGER)";
            command.ExecuteNonQuery();
            command.CommandText =
                @"CREATE TABLE Pets(
                PetId INTEGER PRIMARY KEY,
                ClientId INTEGER,
                Name TEXT, 
                Birthday INTEGER)";
            command.ExecuteNonQuery();
            command.CommandText =
                @"CREATE TABLE Consultations(
                ConsultationId INTEGER PRIMARY KEY,
                PetId INTEGER,
                ClientId INTEGER,
                ConsultationDate INTEGER,
                Description TEXT)";
            command.ExecuteNonQuery();
        }
    }


}