﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Logica;
using System.Text.RegularExpressions;

namespace api.FacturaCliente.Controllers
{
    //[ApiController]
    //[Route("/Api/v1/")]
    public class ClienteController : Controller
    {
        private ClienteService clienteService;
        public ClienteController(IConfiguration configuracion)
        {
            clienteService = new ClienteService(configuracion.GetConnectionString("postgres"));
        }

        // GET: ClienteController/Create
        [HttpPost("AddCliente")]
        public ActionResult Add(Repository.Datos.ClienteModel cliente)
        {
            var validacion = clienteService.validacionCliente(cliente);

            if (Mensaje(validacion) == "Ok")
            {
                clienteService.add(cliente);
                return Ok(new { message = $"El cliente con nombre {cliente.Nombre} fue insertado correctamente" });
            }
            else
            {
                return Ok(new { message = mensajeError });
            }
        }

        // GET: ClienteController/Edit/5
        [HttpPost("UpdateCliente")]
        public ActionResult Update(Repository.Datos.ClienteModel cliente, int id_cli)
        {
            var validacion = clienteService.validacionCliente(cliente);
            if (Mensaje(validacion) == "Ok")
            {
                clienteService.update(cliente, id_cli);
                return Ok(new { message = $"El cliente con nombre {cliente.Nombre} fue actualizado correctamente" });
            }
            else
            {
                return Ok(new { message = mensajeError });
            }
        }

        // GET: ClienteController/Delete/5
        [HttpDelete("DeleteCliente")]
        public ActionResult Delete(int id_cli)
        {
            clienteService.delete(id_cli);
            return Ok(new { message = $"El cliente fue eliminado correctamente" });
        }

        string? mensajeError;

        private string Mensaje(int valor)
        {
            if (valor == 1)
            {
                mensajeError = "Complete los campos";
                return mensajeError;
            }
            else if (valor == 2)
            {
                mensajeError = "Ingrese el nombre";
                return mensajeError;
            }
            else if (valor == 3)
            {
                mensajeError = "Ingrese el apellido";
                return mensajeError;
            }
            else if (valor == 4)
            {
                mensajeError = "Ingrese el Nº de documento";
                return mensajeError;
            }
            else if (valor == 5)
            {
                mensajeError = "El nombre debe contener mínimo 3 caracteres";
                return mensajeError;
            }
            else if (valor == 6)
            {
                mensajeError = "El celular debe contener máximo 10 dígitos";
                return mensajeError;
            }
            else if (valor == 8)
            {
                mensajeError = "El celular debe ser numerico";
                return mensajeError;
            }
            mensajeError = "Ok";
            return mensajeError;
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
