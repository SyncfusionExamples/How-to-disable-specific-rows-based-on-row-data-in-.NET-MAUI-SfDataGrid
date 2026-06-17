using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SfDataGridSample
{
    public class OrderInfoRepository
    {
        private ObservableCollection<OrderInfo> orderInfo;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        public void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo("1001", "Maria Anders", "Germany", "ALFKI", "Berlin", false));
            orderInfo.Add(new OrderInfo("1002", "Ana Trujillo", "Mexico", "ANATR", "Mexico D.F.", true));
            orderInfo.Add(new OrderInfo("1003", "Ant Fuller", "Mexico", "ANTON", "Mexico D.F.", false));
            orderInfo.Add(new OrderInfo("1004", "Thomas Hardy", "UK", "AROUT", "London", true));
            orderInfo.Add(new OrderInfo("1005", "Tim Adams", "Sweden", "BERGS", "London", false));
            orderInfo.Add(new OrderInfo("1006", "Hanna Moos", "Germany", "BLAUS", "Mannheim", false));
            orderInfo.Add(new OrderInfo("1007", "Andrew Fuller", "France", "BLONP", "Strasbourg", true));
            orderInfo.Add(new OrderInfo("1008", "Martin King", "Spain", "BOLID", "Madrid", false));
            orderInfo.Add(new OrderInfo("1009", "Lenny Lin", "France", "BONAP", "Marsiella", false));
            orderInfo.Add(new OrderInfo("1010", "John Carter", "Canada", "BOTTM", "Lenny Lin", true));
            orderInfo.Add(new OrderInfo("1011", "Laura King", "UK", "AROUT", "London", false));
            orderInfo.Add(new OrderInfo("1012", "Anne Wilson", "Germany", "BLAUS", "Mannheim", false));
            orderInfo.Add(new OrderInfo("1013", "Martin King", "France", "BLONP", "Strasbourg", true));
            orderInfo.Add(new OrderInfo("1014", "Gina Irene", "UK", "AROUT", "London", false));
            orderInfo.Add(new OrderInfo("1015", "Maria Anders", "Germany", "ALFKI", "Berlin", false));
            orderInfo.Add(new OrderInfo("1016", "Anabella", "Mexico", "ANATR", "Mexico D.F.", true));
            orderInfo.Add(new OrderInfo("1017", "Ant louis", "Mexico", "ANTON", "Mexico D.F.", false));
            orderInfo.Add(new OrderInfo("1018", "Michael Scofield", "UK", "AROUT", "London", false));
            orderInfo.Add(new OrderInfo("1019", "Tom cook", "Sweden", "BERGS", "London", true));
            orderInfo.Add(new OrderInfo("1020", "Jack Wilson", "Germany", "BLAUS", "Mannheim", false));      
        }
    }
}
