using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(string userName){

            var transactions= TransactionRepository.GetByDayAndCashierName(userName, DateTime.Now);
            return View(transactions);
        }
    } 
}