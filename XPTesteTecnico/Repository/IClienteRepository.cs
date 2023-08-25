using XPTesteTecnico.Entities;

namespace XPTesteTecnico.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente?> CreateCliente(Cliente cliente);
        Task<Cliente?> GetClienteById(long id_cliente);        

    }
}
