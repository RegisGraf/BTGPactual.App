using BTGPactual.App.Interface;
using BTGPactual.App.Model;
using BTGPactual.App.Services;
using BTGPactual.App.View;
using BTGPactual.App.ViewModel.Base;
using System.Collections.ObjectModel;

namespace BTGPactual.App.ViewModel
{
    public class ClientesViewModel : BaseViewModel
    {
        private ICliente _clientService;

        private ObservableCollection<Cliente> listaClientes;
        public ObservableCollection<Cliente> ListaClientes
        {
            get { return listaClientes; }
            set
            {
                listaClientes = value;
                OnPropertyChanged("ListaClientes");
            }
        }

        public ClientesViewModel(ICliente clienteService)
        {
            _clientService = clienteService;
        }

        public async void GetListaClientes()
        {
            try
            {
                ListaClientes = await _clientService.GetClientesAsync();
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
            }
        }

        public void NavegarAddNovoCliente()
        {
            try
            {
                WindowCriarOuAlterarCliente(new Cliente());
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
            }
        }

        public async void ConfirmarExclusaoCliente(Cliente cliente)
        {
            try
            {
                if (cliente is not null)
                {
                    if (await DialogService.DisplayConfirm("Excluir cliente", "Deseja realmente excluir este cliente?", "Sim", "Não"))
                    {
                        if (await ExcluirCliente(cliente))
                            GetListaClientes();
                    }
                }
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
            }
        }

        public void AlterarCliente(Cliente cliente)
        {
            try
            {
                if (cliente is not null)
                    WindowCriarOuAlterarCliente(cliente, "Alterar dados do cliente");
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
            }
        }

        private void WindowCriarOuAlterarCliente(Cliente cliente, string title = "Adicionar novo cliente")
        {
            try
            {
                CriarOuALterarClienteViewModel addNovoClienteViewModel = new CriarOuALterarClienteViewModel(_clientService) { NovoCliente = cliente };
                if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    var addCliente = new CriarOuAlterarClienteView(addNovoClienteViewModel, title);
                    var addWindow = new Window(addCliente);

                    addWindow.Destroying += (s, e) =>
                    {
                        GetListaClientes();
                    };

                    App.OpenCenteredWindow(addWindow);
                }
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
            }
        }

        public async Task<bool> ExcluirCliente(Cliente cliente)
        {
            try
            {
                return await _clientService.DeleteClienteAsync(cliente);
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
                return false;
            }
        }
    }
}
