using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPortafolioRichard.Models;
using System.Diagnostics.Contracts;
using System.Net.Mail;

namespace ProyectoPortafolioRichard.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;

        // Constructor único que recibe IConfiguration
        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        // Acción para mostrar el formulario
        public IActionResult Index()
        {
            return View();
        }

        // Acción para procesar el envío del formulario
        [HttpPost]
        public IActionResult Enviar(Contact contacto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var smtpSettings = _config.GetSection("SmtpSettings");
                    var smtpClient = new SmtpClient(smtpSettings["Host"])
                    {
                        Port = int.Parse(smtpSettings["Port"]),
                        Credentials = new System.Net.NetworkCredential(smtpSettings["Email"], smtpSettings["Password"]),
                        EnableSsl = bool.Parse(smtpSettings["UseSSL"]),
                    };

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(smtpSettings["Email"]),
                        Subject = $"Mensaje de {contacto.Nombre}",
                        Body = $"De: {contacto.Nombre} ({contacto.Email})\n\n{contacto.Mensaje}",
                        IsBodyHtml = false,
                    };

                    mailMessage.To.Add("richard.valdesrosales@outlook.cl");

                    smtpClient.Send(mailMessage);

                    TempData["Mensaje"] = "¡Mensaje enviado con éxito!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al enviar el mensaje: {ex.Message}");
                }
            }

            return View("Index", contacto);
        }

    }
}
