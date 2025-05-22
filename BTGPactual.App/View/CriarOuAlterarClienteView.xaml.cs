using BTGPactual.App.Services;
using BTGPactual.App.ViewModel;

namespace BTGPactual.App.View;

public partial class CriarOuAlterarClienteView : ContentPage
{
	CriarOuALterarClienteViewModel _viewModel;

	public CriarOuAlterarClienteView(CriarOuALterarClienteViewModel viewModel, string title)
	{
		InitializeComponent();
		lblTitle.Text = title;
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

    private void SalvarClicked(object sender, EventArgs e)
    {
		try
		{
			_viewModel.AdicionarNovoCliente(GetParentWindow());
		}
		catch (Exception)
		{
            DialogService.DisplayConfirm("Erro inesperado", "Ocorreu um erro inesperado", "Ok");
        }
    }

    private void entryTexChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
            _viewModel.ValidaCamposPreenchidos();
        }
		catch (Exception)
		{
            DialogService.DisplayConfirm("Erro inesperado", "Ocorreu um erro inesperado", "Ok");
        }
    }
}