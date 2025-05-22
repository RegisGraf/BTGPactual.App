using BTGPactual.App.LocalDataBase;
using BTGPactual.App.Model;
using BTGPactual.App.ViewModel.Base;

namespace BTGPactual.App.ViewModel
{
    public class CriarOuALterarClienteViewModel : BaseViewModel
    {
        LocalDbService _clienteService;

        private Cliente novoCliente;
        public Cliente NovoCliente
        {
            get { return novoCliente; }
            set
            {
                novoCliente = value;
                OnPropertyChanged("NovoCliente");
            }
        }

        private bool todosCamposPreenchidos = false;
        public bool TodosCamposPreenchidos
        {
            get { return todosCamposPreenchidos; }
            set
            {
                todosCamposPreenchidos = value;
                OnPropertyChanged("TodosCamposPreenchidos");
            }
        }

        public void ValidaCamposPreenchidos()
        {
            try
            {
                TodosCamposPreenchidos = !string.IsNullOrEmpty(novoCliente?.Name)
                                         && !string.IsNullOrEmpty(novoCliente?.LastName)
                                         && novoCliente?.Age > 0
                                         && !string.IsNullOrEmpty(novoCliente?.Address);
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
            }
        }

        public CriarOuALterarClienteViewModel(LocalDbService clienteService)
        {
            _clienteService = clienteService;

            if (clienteService is null)
                NovoCliente = new Cliente();
        }

        public async Task<bool> InserirOuAlterarCliente(Cliente cliente)
        {
            try
            {
                bool result;
                if (NovoCliente.Id > 0)
                    result = await _clienteService.UpdateClienteAsync(NovoCliente);
                else
                    result = await _clienteService.InsertClienteAsync(NovoCliente);

                return result;
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
                return false;
            }
        }

        public async void AdicionarNovoCliente(Window addNovoClienteWindow)
        {
            try
            {
                if (NovoCliente is not null)
                {
                    if (await InserirOuAlterarCliente(NovoCliente))
                        App.Current?.CloseWindow(addNovoClienteWindow);
                }
            }
            catch (Exception)
            {
                //aqui viria um pacote de captura de erros. Ex: SentryIo,Serilog,firebase analistcs
            }
        }
    }
}
