using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using XPTesteTecnico.DTOs;
using XPTesteTecnico.Entities;
using XPTesteTecnico.Repository;

namespace XPTesteTecnico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
       
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _clienteRepository;
        

        public ClienteController(
            ILogger<ClienteController> logger,
            IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult> GetClientes()
        {
            List<Cliente> clientes = await _clienteRepository.GetAllClientes();
            List<GetAllClienteDTO> clientesDto = new() { };

            foreach (var item in clientes)
            {
                var clienteUnico = new GetAllClienteDTO();

                clienteUnico.Nome = item.Nome;
                clienteUnico.Telefone = item.Telefone;

                clientesDto.Add(clienteUnico);

            }
            return StatusCode((int)HttpStatusCode.OK, clientesDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult> GetDetalhesCliente(long id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);


            if (cliente == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "O Cliente não foi encontrado para esse ID");
            }

            return StatusCode((int)HttpStatusCode.OK, cliente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [AllowAnonymous]
        public async Task<ActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            var novoCliente = await _clienteRepository.CreateCliente(cliente);


            if (novoCliente == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "O Cliente já tem cadastro / Erro no preenchimento");
            }

            return StatusCode((int)HttpStatusCode.Created, novoCliente);
        }

    }
}
