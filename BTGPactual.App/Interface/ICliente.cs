using BTGPactual.App.Model;
using System.Collections.ObjectModel;

namespace BTGPactual.App.Interface
{
    public interface ICliente
    {
        public Task<ObservableCollection<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<bool> InsertClienteAsync(Cliente cliente);
        Task<bool> UpdateClienteAsync(Cliente cliente);
        Task<bool> DeleteClienteAsync(Cliente cliente);
    }
}
