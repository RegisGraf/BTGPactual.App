using BTGPactual.App.Model;
using BTGPactual.App.Services;
using BTGPactual.App.ViewModel;

namespace BTGPactual.App.View;

public partial class ClientesView : ContentPage
{
    ClientesViewModel _viewModel;

    public ClientesView(ClientesViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		_viewModel.GetListaClientes();
		BindingContext = _viewModel;
	}

    private void AddClienteClicked(object sender, EventArgs e)
    {
		try
		{
			_viewModel.NavegarAddNovoCliente();
		}
		catch (Exception ex)
		{
			DialogService.DisplayConfirm("Erro inesperado", "Ocorreu um erro inesperado", "Ok");
		}
    }

    private void ExcluirClienteClicked(object sender, EventArgs e)
    {
		try
		{
			ImageButton btnExcluir = (ImageButton)sender;

			if(btnExcluir is not null)
			{
				Cliente clienteASerExcluido = btnExcluir.BindingContext as Cliente;
                _viewModel.ConfirmarExclusaoCliente(clienteASerExcluido);
            }
		}
		catch (Exception)
		{
            DialogService.DisplayConfirm("Erro inesperado", "Ocorreu um erro inesperado", "Ok");
        }
    }

    private void AlterarClienteClicked(object sender, EventArgs e)
    {
		try
		{
            ImageButton btnAlterarCliente = (ImageButton)sender;

            if (btnAlterarCliente is not null)
            {
                Cliente clienteASerExcluido = btnAlterarCliente.BindingContext as Cliente;
                _viewModel.AlterarCliente(clienteASerExcluido);
            }
        }
		catch (Exception)
		{
            DialogService.DisplayConfirm("Erro inesperado", "Ocorreu um erro inesperado", "Ok");
        }
    }
}