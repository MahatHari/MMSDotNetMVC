namespace WebApp.Models
{
    public class TransactionRepository
    {
        private static List<Transaction> transactions = new List<Transaction>();

        public static IEnumerable<Transaction> GetByDayAndCashierName(string casheir, DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(casheir))
                return transactions.Where(x => x.TimeStamp.Date == dateTime.Date);
            else
                return transactions.Where(x => x.CashierName.ToLower().Contains(casheir.ToLower()) &&
                x.TimeStamp.Date == dateTime.Date);
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

        public static void Add(string cashierName, int selectProdId, string prodName, double prodPrice, int prodQty, int qtyToSell)
        {
            var transaction = new Transaction
            {
                ProductId = selectProdId,
                ProductName = prodName,
                TimeStamp = DateTime.Now,
                Price = prodPrice,
                BeforeQty = prodQty,
                SoldQty = qtyToSell,
                CashierName = cashierName
            };
            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId + 1;

            }
            else
            {
                transaction.TransactionId = 1;
            }
            transactions?.Add(transaction);
        }
    }
}