using DocePecado.Application.Contracts;
using DocePecado.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DocePecado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync(true);
                if (orders == null) return NotFound();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id, true);
                if (order == null) return NotFound();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedido. Erro: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var orders = await _orderService.GetAllOrdersByNameAsync(name, true);
                if (orders == null) return NotFound();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDto model)
        {
            try
            {
                var order = await _orderService.AddOrder(model);
                if (order == null) return BadRequest();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrderDto model)
        {
            try
            {
                var order = await _orderService.UpdateOrder(id, model);
                if (order == null) return BadRequest();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id, true);
                if (order == null) return NotFound();

                return await _orderService.DeleteOrder(id) ? Ok("Deletado") : throw new Exception("Ocorreu um problema ao tentar deletar pedido");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar pedidos. Erro: {ex.Message}");
            }
        }
    }
}
