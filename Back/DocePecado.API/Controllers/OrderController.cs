using DocePecado.Application.Contracts;
using DocePecado.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocePecado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orders = await this.orderService.GetAllOrdersAsync(true);
                if (orders == null) return NotFound("Nenhum pedido encontrado.");

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var order = await this.orderService.GetOrderByIdAsync(id, true);
                if (order == null) return NotFound("Nenhum pedido encontrado com Id informado.");

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
                var orders = await this.orderService.GetAllOrdersByNameAsync(name, true);
                if (orders == null) return NotFound("Nenhum pedido encontrado com nome informado.");

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order model)
        {
            try
            {
                var order = await this.orderService.AddOrder(model);
                if (order == null) return BadRequest("Erro ao tentar adicionar pedido.");

                return Ok(order);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Order model)
        {
            try
            {
                var order = await this.orderService.UpdateOrder(id, model);
                if (order == null) return BadRequest("Erro ao tentar atualizar pedido.");

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
                return await this.orderService.DeleteOrder(id) ? Ok("Deletado") :BadRequest("Pedido nao deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar pedidos. Erro: {ex.Message}");
            }
        }
    }
}
