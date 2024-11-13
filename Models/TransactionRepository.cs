namespace WebApp.Models
{
    public class TransactionRepository
    {
        private static List<Transaction> transactions = new List<Transaction>();

        public static IEnumerable<Transaction> GetByDayAndCashierName(string casheir, DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(casheir))
                return transactions.Where(x => x.TimeStamp.Date == dateTime);
            else
                return transactions.Where(x => x.CashierName.ToLower().Contains(casheir.ToLower()) &&
                x.TimeStamp.Date == dateTime);
        }

        public static IEnumerable<Transaction> Search(string casheir, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(casheir))
            {
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.AddDays(1).Date);
            }
            else
                return transactions.Where(x => x.CashierName.ToLower().Contains(casheir.ToLower()) && x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.AddDays(1).Date);
        }

        public static void Add(string casheir, int selectProdId, string prodName, double prodPrice, int prodQty, int qtyToSell)
        {
            var transaction = new Transaction
            {
                ProductId = selectProdId,
                ProductName = prodName,
                TimeStamp = DateTime.Now,
                Price = prodPrice,
                BeforeQty = prodQty,
                SoltQty = qtyToSell,
                CashierName = casheir
            };
        }
    }
}