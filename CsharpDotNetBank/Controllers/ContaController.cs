using Microsoft.AspNetCore.Mvc;
using CsharpDotNetBank.Services;

namespace CsharpDotNetBank.Controllers;

public class ContaController : Controller
{
    private readonly ContaService _service;

    public ContaController()
    {
        _service = new ContaService();
    }

    public IActionResult Index()
    {
        return RedirectToAction("Saldo");
    }

    public IActionResult Saldo()
    {
        var conta = _service.ObterConta();
        return View(conta);
    }

    [HttpGet]
    public IActionResult Depositar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Depositar(decimal valor)
    {
        _service.Depositar(valor);
        return RedirectToAction("Saldo");
    }

    [HttpGet]
    public IActionResult Sacar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Sacar(decimal valor)
    {
        bool ok = _service.Sacar(valor);

        if (!ok)
        {
            ViewBag.Erro = "Saldo insuficiente!";
            return View();
        }

        return RedirectToAction("Saldo");
    }
}
