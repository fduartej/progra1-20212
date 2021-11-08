using Microsoft.AspNetCore.Mvc;
using demomvc.Models;


namespace demomvc.Controllers
{
    public class CalculadoraController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(Calculadora objcaluladora)
        {
            decimal operacion=0;
            ViewData["Message"] = "Sin resultado";
            if(objcaluladora.Operador.Equals("+")){
                operacion = objcaluladora.Operando1 + objcaluladora.Operando2;
                ViewData["Message"] = "El resultado de la operacion es "+ operacion;
            }else if(objcaluladora.Operador.Equals("/")){
                if(objcaluladora.Operando2 == 0){
                    ViewData["Message"] = "No se puede dividir entre 0";
                }else{
                    operacion = objcaluladora.Operando1 / objcaluladora.Operando2;
                    ViewData["Message"] = "El resultado de la operacion es "+ operacion;
                }
            }
            return View("Index");
        }

    }
}