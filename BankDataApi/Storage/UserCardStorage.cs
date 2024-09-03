using Dapper;
using Entities.Models;
using Npgsql;

namespace BankDataApi.Storage
{
    public class UserCardStorage
    {
        private readonly string _connectionString;

        public UserCardStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<User>?> GetUsers()
        {
            string sql = $"SELECT " +
                $"iduser as {nameof(User.Id)}, " +
                $"birthdate as {nameof(User.BirthDate)}, " +
                $"workplace as {nameof(User.WorkPlace)}, " +
                $"first_name as {nameof(User.FirstName)}, " +
                $"middle_name as {nameof(User.MiddleName)}, " +
                $"last_name as {nameof(User.LastName)} " +
                $"FROM users; ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                IEnumerable<User> users = await connection.QueryAsync<User>(sql);

                if (users != null && users.Count() > 0)
                {
                    foreach (User user in users)
                    {
                        user.Cards = (await GetCards(user.Id))?.ToList() ?? new List<CreditCard>();
                    }
                }

                return users;
            }
        }

        public async Task<User?> GetUser(string iduser)
        {
            User model = new User() { Id = iduser };

            string sql = $"SELECT " +
                $"iduser as {nameof(User.Id)}, " +
                $"birthdate as {nameof(User.BirthDate)}, " +
                $"workplace as {nameof(User.WorkPlace)}, " +
                $"first_name as {nameof(User.FirstName)}, " +
                $"middle_name as {nameof(User.MiddleName)}, " +
                $"last_name as {nameof(User.LastName)} " +
                $"FROM users " +
                $"WHERE iduser = @{nameof(User.Id)}; ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                User? user = await connection.QueryFirstOrDefaultAsync<User>(sql, model);

                if (user != null)
                {
                    user.Cards = (await GetCards(user.Id))?.ToList() ?? new List<CreditCard>();
                }

                return user;
            }
        }

        public async Task<int> InsertUser(User model)
        {
            string sql = $"INSERT INTO users " +
                $"(iduser, birthdate, workplace, first_name, middle_name, last_name) " +
                $"VALUES ( " +
                $"@{nameof(model.Id)}, " +
                $"@{nameof(model.BirthDate)}, " +
                $"@{nameof(model.WorkPlace)}, " +
                $"@{nameof(model.FirstName)}, " +
                $"@{nameof(model.MiddleName)}, " +
                $"@{nameof(model.LastName)} " +
                $"); ";

            int result = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync(sql, model);
            }

            if (model.Cards != null && model.Cards.Count() > 0)
            {
                foreach (var card in model.Cards)
                {
                    card.Id = Guid.NewGuid().ToString();
                    result += await InsertCard(card);
                }
            }

            return result;
        }

        public async Task<int> UpdateUser(User model)
        {
            string sql = $"UPDATE users " +
                $"SET " +
                $"birthdate = @{nameof(model.BirthDate)}, " +
                $"workplace = @{nameof(model.WorkPlace)}, " +
                $"first_name = @{nameof(model.FirstName)}, " +
                $"middle_name = @{nameof(model.MiddleName)}, " +
                $"last_name = @{nameof(model.LastName)} " +
                $"WHERE " +
                $"iduser = @{nameof(model.Id)}; ";

            int result = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync(sql, model);

                if (model.Cards != null && model.Cards.Count() > 0)
                {
                    foreach (var card in model.Cards)
                    {
                        result += await UpdateCard(card);
                    }
                }

                return result;
            }
        }

        public async Task<int> DeleteUser(string iduser)
        {
            User model = new User() { Id = iduser };

            return await DeleteUser(model);
        }

        public async Task<int> DeleteUser(User model)
        {
            string sql = $"DELETE FROM users " +
                $"WHERE iduser = @{nameof(model.Id)}; ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, model);
            }
        }

        public async Task<IEnumerable<CreditCard>?> GetCards(string userid)
        {
            string sql = $"SELECT " +
                $"idcard as {nameof(CreditCard.Id)}, " +
                $"account as {nameof(CreditCard.Account)}, " +
                $"expiration_date as {nameof(CreditCard.Expiration)}, " +
                $"cvc as {nameof(CreditCard.Cvc)}, " +
                $"iduser as {nameof(CreditCard.IdUser)} " +
                $"FROM creditcards " +
                $"WHERE iduser = @UserId; ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<CreditCard>(sql, new { UserId = userid });
            }
        }

        public async Task<int> InsertCard(CreditCard model)
        {
            string sql = $"INSERT INTO creditcards " +
                $"(idcard, account, expiration_date, cvc, iduser) " +
                $"VALUES( " +
                $"@{nameof(model.Id)}, " +
                $"@{nameof(model.Account)}, " +
                $"@{nameof(model.Expiration)}, " +
                $"@{nameof(model.Cvc)}, " +
                $"@{nameof(model.IdUser)} " +
                $"); ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, model);
            }
        }

        public async Task<int> UpdateCard(CreditCard model)
        {
            string sql = $"UPDATE creditcards " +
                $"SET " +
                $"account = @{nameof(model.Account)}, " +
                $"expiration_date = @{nameof(model.Expiration)}, " +
                $"cvc = @{nameof(model.Cvc)}, " +
                $"iduser = @{nameof(model.IdUser)} " +
                $"WHERE " +
                $"idcard = @{nameof(model.Id)}; ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, model);
            }
        }

        public async Task<int> DeleteCard(string idcard)
        {
            CreditCard model = new CreditCard() { Id = idcard };

            return await DeleteCard(model);
        }

        public async Task<int> DeleteCard(CreditCard model)
        {
            string sql = $"DELETE FROM creditcards " +
                $"WHERE idcard = @{nameof(model.Id)}; ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, model);
            }
        }
    }
}
