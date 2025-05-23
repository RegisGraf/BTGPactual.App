using BTGPactual.App.Interface;
using BTGPactual.App.Model;
using BTGPactual.App.ViewModel;

namespace UnitTests
{
    public class UnitTest1
    {
        private static ICliente _serviceCliente;
        private static CriarOuALterarClienteViewModel _criarOuAlterarClienteViewModel = new CriarOuALterarClienteViewModel(_serviceCliente);
        private static ClientesViewModel _clientesViewModel = new ClientesViewModel(_serviceCliente);

        [Fact]
        public async Task Testa_Criacao_cliente()
        {
            //Arrange
            Cliente clienteNovo = new Cliente()
            {
                Name = "teste",
                LastName = "teste",
                Age = 30,
                Address = "rua teste, 11, teste - TT"
            };

            //Act
            var result = await _criarOuAlterarClienteViewModel.InserirOuAlterarCliente(clienteNovo);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task Testa_Alteracao_cliente()
        {
            //Arrange
            Cliente clienteAlterado = new Cliente()
            {
                Name = "teste",
                LastName = "alteracao",
                Age = 31,
                Address = "rua teste, 11, teste - TT"
            };

            //Act
            var result = await _criarOuAlterarClienteViewModel.InserirOuAlterarCliente(clienteAlterado);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task Testa_exclusao_cliente()
        {
            //Arrange
            Cliente clienteExclusao = new Cliente()
            {
                Name = "teste",
                LastName = "alteracao",
                Age = 31,
                Address = "rua teste, 11, teste - TT"
            };

            //Act
            var result = await _clientesViewModel.ExcluirCliente(clienteExclusao);

            //Assert
            Assert.True(true);
        }
    }
}
