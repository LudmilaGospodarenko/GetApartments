using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner
{
    public class Location
    {
        public string address { get; set; }
        public string user_address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public override string ToString()
        {
            return address + "\r\n";
        }
    }

    public class BYN
    {
        public string amount { get; set; }
        public string currency { get; set; }

        public override string ToString()
        {
            return $"{currency}: {amount}\r\n";
        }
    }

    public class USD
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public override string ToString()
        {
            return $"{currency}: {amount}\r\n";
        }
    }

    public class Converted
    {
        public BYN BYN { get; set; }
        public USD USD { get; set; }
    }

    public class Price
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public Converted converted { get; set; }
        public override string ToString()
        {
            return $"{currency}: {amount}\r\n";
        }
    }

    public class Area
    {
        public double total { get; set; }
        public double living { get; set; }
        public double kitchen { get; set; }
        public override string ToString()
        {
            return $"Общая площадь {total}, жилая площадь {living}, кухня {kitchen}\r\n";
        }
    }

    public class Seller
    {
        public string type { get; set; }
        public override string ToString()
        {
            return $"Продавец: {type}\r\n";
        }
    }

    public class AuctionBid
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class Apartment
    {
        public int id { get; set; }
        public int author_id { get; set; }
        public Location location { get; set; }
        public Price price { get; set; }
        public bool resale { get; set; }
        public int number_of_rooms { get; set; }
        public int floor { get; set; }
        public int number_of_floors { get; set; }
        public Area area { get; set; }
        public string photo { get; set; }
        public Seller seller { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_time_up { get; set; }
        public int up_available_in { get; set; }
        public string url { get; set; }
        public AuctionBid auction_bid { get; set; }
        public override string ToString()
        {
            return $"Расположен: {location.ToString()}" +
                $"Цена: {price.ToString()}" +
                $"Перепродажа: {resale.ToString()}\r\n" +
                $"Всего комнат: {number_of_rooms.ToString()}\r\n" +
                $"Этаж: {floor.ToString()}\r\n" +
                $"Всего этажей: {number_of_floors.ToString()}\r\n" +
                $"Площадь: {area.ToString()}" +
                $"{seller.ToString()}" +
                $"Объявление подано: {created_at.ToString()}\r\n" +
                $"Последний раз поднято: {last_time_up.ToString()}\r\n" +
                $"Ссылка: {url}\r\n" +
                $"\r\n";

        }
    }

    public class Page
    {
        public int limit { get; set; }
        public int items { get; set; }
        public int current { get; set; }
        public int last { get; set; }
    }

    public class RootObject
    {
        public List<Apartment> apartments { get; set; }
        public int total { get; set; }
        public Page page { get; set; }

        public override string ToString()
        {
            var str = $"Квартиры, страница {page.current}: \r\n";
            foreach (var a in apartments)
                str += a.ToString();
            return str;
        }
    }
}
