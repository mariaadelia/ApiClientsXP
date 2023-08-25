using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using XPTesteTecnico.Entities;
using XPTesteTecnico.Infra;

namespace XPTesteTecnico.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ClienteRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            try
            {
                var clientes = await _dbContext.Clientes.ToListAsync();                    
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente?> CreateCliente(Cliente cliente)
        {
            try
            {
                var clienteExistente = await GetClienteById(cliente.Id);
                var emailValido = CheckEmail(cliente.Email);
                var foneValido = CheckTelefone(cliente.Telefone);

                if (clienteExistente == null && emailValido == true && foneValido == true)
                {
                    await _dbContext.Clientes.AddAsync(cliente);
                    await _dbContext.SaveChangesAsync();
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Cliente?> GetClienteById(long id_cliente)
        {
            try
            {
                var cliente = await _dbContext.Clientes.FindAsync(id_cliente);
                if (cliente != null)
                {
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); ;
            }
        }

        private bool CheckEmail(string email)
        {
            bool emailCorreto = Regex.IsMatch(email, @"^([\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z)");
            return emailCorreto;
        }

        private bool CheckTelefone(string fone)
        {
            bool phoneCorreto = Regex.IsMatch(fone, @"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$");
            return phoneCorreto;
        }

    }
}
