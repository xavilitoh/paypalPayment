using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaypalPayment
{
    interface IPayPal
    {
        Task<PayPalPaymentExecutedResponse> ExecutedPayment(string paymentId, string payerId);
        Task<string> getRedirectURLToPayPal(double total, string currency);
    }
}
