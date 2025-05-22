using BTGPactual.App.Interface;
using BTGPactual.App.Model;
using SQLite;
using System.Collections.ObjectModel;
using System.Reflection;

namespace BTGPactual.App.LocalDataBase
{
    public class LocalDbService : ICliente
    {
        private const string DB_Name = "db_local.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codeBasePath);
            _connection = new SQLiteAsyncConnection(Path.Combine(dirPath, DB_Name));
            _connection.CreateTableAsync<Cliente>();
        }

        public async Task<ObservableCollection<Cliente>> GetClientesAsync()
        {
            try
            {
                return new ObservableCollection<Cliente>(await _connection.Table<Cliente>().ToListAsync());
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
                throw;
            }
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            try
            {
                return await _connection.Table<Cliente>().FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
                throw;
            }
        }

        public async Task<bool> InsertClienteAsync(Cliente cliente)
        {
            try
            {
                int result = await _connection.InsertAsync(cliente);
                return result > 0;
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
                throw;
            }
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            try
            {
                int result = await _connection.UpdateAsync(cliente);
                return result > 0;
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
                throw;
            }
        }

        public async Task<bool> DeleteClienteAsync(Cliente cliente)
        {
            try
            {
                int result = await _connection.DeleteAsync(cliente);
                return result > 0;
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
                throw;
            }
        }
    }
}
