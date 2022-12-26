using System.Data.SQLite;
using WebApplication02.Models;

namespace WebApplication02.Services.Implementation
{
    public class ConsultationRepository : IConsultationRepository
    {

        private const string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        public int Create(Consultation item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Consultations(PetId, ClientId, ConsultationDate, Description) VALUES(@PetId, @ClientId, @ConsultationDate, @Description)";
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Prepare();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public int Delete(int item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM Consultations WHERE ConsultationId = @ConsultationId";
            command.Parameters.AddWithValue("@ConsultationId", item);
            command.Prepare();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public IList<Consultation> GetAll()
        {
            List<Consultation> list = new List<Consultation>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Consultations";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Consultation consultation = new Consultation();
                consultation.ConsultationId = reader.GetInt32(0);
                consultation.PetId = reader.GetInt32(1);
                consultation.ClientId = reader.GetInt32(2);
                consultation.ConsultationDate = new DateTime(reader.GetInt64(3));
                consultation.Description = reader.GetString(4);

                list.Add(consultation);
            }

            connection.Close();
            return list;
        }

        public Consultation GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Consultations WHERE ConsultationId = @ConsultationId";
            command.Parameters.AddWithValue("@ConsultationId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Consultation consultation = new Consultation();
                consultation.ConsultationId = reader.GetInt32(0);
                consultation.PetId = reader.GetInt32(1);
                consultation.ClientId = reader.GetInt32(2);
                consultation.ConsultationDate = new DateTime(reader.GetInt64(3));
                consultation.Description = reader.GetString(4);

                connection.Close();
                return consultation;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        public int Update(Consultation item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE Consultations SET PetId = @PetId, ClientId = @ClientId, ConsultationDate = @ConsultationDate, Description = @Description) WHERE ConsultationId = @ConsultationId";
            command.Parameters.AddWithValue("@ConsultationId", item.ConsultationId);
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate.Ticks);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Prepare();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
