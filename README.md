# paypalpayment

![paypal](https://www.pngkey.com/png/full/395-3955460_-paypal-chad-hurley-paypal-logo.png)

#### Implementa pagos con paypal en aplicaciones .NET core
___

Este paquete nos permite realizar pagos con la API de Paypal de una manera sencilla.

___

## Configuracion del archivo appsettings.json

Coloca el siguiente objeto con tu informacion en el archivo `appsettings.json`

```json
"Paypal": {
    "clientID": "YOUR PAYPAL CLIENT ID",
    "secret": "YOUR PAYPAL SECRET CODE,
    "returnUrl": "YOUR SUCCESS URL",
    "cancelUrl": "YOUR CANCEL URL",
    "apiURL": "PAYPAL API URL"
  },
  ```
  
  
 ---
 
 ## Configuracion del archivo Startup.cs
 
 ```C#
 using PayPalPayment;
 public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IPayPal, PayPalAPI>();
    }

 } 
 ```
 ---
 
 ## Implementacion
 
 En nuestro controlador utilizar para el pago definimos los metodos Checkout, Success y Cancel previamente referenciados en el `appsettins.json`
 
 ```json
"Paypal": {
    "clientID": "YOUR PAYPAL CLIENT ID",
    "secret": "YOUR PAYPAL SECRET CODE",
    "returnUrl": "YOUR SUCCESS URL", // test/Success
    "cancelUrl": "YOUR CANCEL URL",// test/SuccessCancel
    "apiURL": "PAYPAL API URL"
  },
  ```
 
 ```C#
  using PayPalPayment;
  public class TestController : Controller
  {
      readonly IPayPal payPal;

      public TestController(IPayPal payPal){
        this.payPal = payPal;
      }
      
      [HttpPost]
      public async Task<IActionResult> Checkout(double total)
      {
          //obtiene la url de paypal para el checkout
          string url = await payPal.getRedirectURLToPayPal(total, "USD");
          
          //redireccionamiento hacia paypal.
          return Redirect(url);
      }
      
      public async Task<IActionResult> Success([FromQuery(Name = "PaymentId")] string paymentId, [FromQuery(Name = "PayerID")] string payerID)
        {
            PayPalPaymentExecutedResponse paypalPayment = null;
            try
            {
                paypalPayment = await payPal.ExecutedPayment(paymentId, payerID);
            }
            catch (Exception )
            {
                paypalPayment = null;
            }

            if (paypalPayment != null)
            {
                //aqui puedes procesar la informacion de la transaccion que se obtiene en el objeto  paypalPayment y guardarla en tu base de datos

                    return View(model);
                }
            }

            return RedirectToAction(nameof(Cancel));
        }
        
        public async Task<IActionResult> Cancel(double total)
        {
            return View();
        }
  }
 ```
    


