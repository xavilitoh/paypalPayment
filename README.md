# paypalpayment

#### Implementa pagos con paypal en aplicaciones .NET core
___

Este paquete nos permite realizar pagos con la API de Paypal de una manera sencilla.

___

## Configuracion del archivo appsettings.json

Coloca el siguiente objeto con tu informacion en el archivo `appsettings.json`

```json
"Paypal": {
    "clientID": "YOUR PAYPAL CLIENT ID",
    "secret": "YOUR PAYPAL SECRET CODE",
    "urlAPI": "https://api.paypal.com",
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
    


