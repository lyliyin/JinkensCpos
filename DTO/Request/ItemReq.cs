using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class ItemsReq
    {
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
    }

    public class ItemReq
    {
        public string BrandName { get; set; }
        public string BrandCode { get; set; }
    }

    public class ItemReqs
    {
        public List<myItem> itemList { get; set; }
        public ItemReqs()
        {
            itemList = new List<myItem>();
        }
    }

    public class myItem
    {

        public string Id { get; set; }

        public string ItemName { get; set; }


        public string ItemCode { get; set; }

        public string ItemDescription { get; set; }

        public int? ItemStatus { get; set; }

        public int? SourcesId { get; set; }

        public string BrandId { get; set; }

        public string CategoryId { get; set; }

        public int? IsGift { get; set; }

        public int? IsUseCoupon { get; set; }

        public List<myImages> imagesList { get; set; }

        public List<myPrice> priceList { get; set; }
        public List<SkuInfo> info { get; set; }

        public myItem()
        {
            imagesList = new List<myImages>();
            priceList = new List<myPrice>();
            info = new List<SkuInfo>();
        }
    }

    public class myImages
    {
        public string Id { get; set; }

        public string ItemId { get; set; }

        public string ImagesUrl { get; set; }
    }

    public class myPrice
    {

        public string Id { get; set; }

        public string ItemId { get; set; }

        public decimal? Price { get; set; }

        public int? StoreCount { get; set; }

        public List<mySku> skuList { get; set; }


        public myPrice()
        {
            skuList = new List<mySku>();

        }
    }


    public class SkuInfo
    {
        public string Id { get; set; }
        public string SkuName { get; set; }
        public string SkuCode { get; set; }
        public string pid { get; set; }
    }

    public class mySku
    {
        public string Id { get; set; }

        public string PriceId { get; set; }

        public string SkuId { get; set; }
    }
}
