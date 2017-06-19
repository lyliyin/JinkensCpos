using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GetOrderStatistiscDataRes
    {
        public string UnitName { get; set; }
        public string UnitNames { get; set; }
        public decimal JanCount { get; set; }
        public decimal FebCount { get; set; }
        public decimal MarCount { get; set; }
        public decimal AprCount { get; set; }
        public decimal MayCount { get; set; }
        public decimal JunCount { get; set; }
        public decimal JulCount { get; set; }
        public decimal AguCount { get; set; }
        public decimal SepCount { get; set; }
        public decimal OctCount { get; set; }
        public decimal NovCount { get; set; }
        public decimal DecCount { get; set; }


        public static List<GetOrderStatistiscDataRes> Initialize()
        {
            List<GetOrderStatistiscDataRes> lst = new List<GetOrderStatistiscDataRes>();
            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 80,
                AprCount = 6.3M,
                DecCount = 90,
                FebCount = 45,
                JanCount = 63,
                JulCount = 77,
                JunCount = 88,
                MarCount = 15,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "精华一店",
                UnitNames = "销售门店"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "浦江店",
                UnitNames = "销售门店"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "黄埔店",
                UnitNames = "销售门店"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "正大广场",
                UnitNames = "销售门店"
            });


            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "微信",
                UnitNames = "支付方式"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "支付宝",
                UnitNames = "支付方式"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "白条",
                UnitNames = "支付方式"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "信用卡",
                UnitNames = "支付方式"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "分期付款",
                UnitNames = "支付方式"
            });


            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "服装",
                UnitNames = "商品类别"
            });


            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "电器",
                UnitNames = "商品类别"
            });


            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "手机",
                UnitNames = "商品类别"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "阿迪达斯",
                UnitNames = "品牌"
            });

            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 8,
                AprCount = 6.3M,
                DecCount = 31,
                FebCount = 59,
                JanCount = 63,
                JulCount = 77,
                JunCount = 57,
                MarCount = 211,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "杰克琼斯 ",
                UnitNames = "品牌"
            });
            lst.Add(new GetOrderStatistiscDataRes()
            {
                AguCount = 80,
                AprCount = 6.3m,
                DecCount = 90,
                FebCount = 45,
                JanCount = 63,
                JulCount = 77,
                JunCount = 88,
                MarCount = 15,
                MayCount = 236.5M,
                NovCount = 99.6M,
                OctCount = 86.2M,
                SepCount = 59.6M,
                UnitName = "总计："
            });
            return lst;
        }
    }
}
