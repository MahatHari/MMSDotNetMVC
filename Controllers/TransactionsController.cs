using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TransactionsController:Controller
    {
        public IActionResult Index(){
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionsViewModel transactionsViewModel){
            
            var transaction= TransactionRepository.Search(
                transactionsViewModel.CashierName??string.Empty,
            transactionsViewModel.StartDate,
            transactionsViewModel.EndDate
            );
            transactionsViewModel.Transactions=transaction;
            return View("Index", transactionsViewModel);
        }   
    }


}