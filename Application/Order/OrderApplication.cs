using DTO;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class OrderApplication
    {
        private IOrderReportResponsity _OrderReportService = null;
        private IOrderResponsity _OrderService = null;
        private IOrderDetailResponsity _OrderDetailService = null;
        public OrderApplication(IOrderReportResponsity OrderReportService, IOrderResponsity OrderService, IOrderDetailResponsity OrderDetailService)
        {
            _OrderReportService = OrderReportService;
            _OrderService = OrderService;
            _OrderDetailService = OrderDetailService;
        }

        public List<GetOrderStatistiscDataRes> GetList()
        {
            return _OrderReportService.GetReportByDate<GetOrderStatistiscDataRes>();
        }

        public List<GetOrderByVipIdRes> GetOrderByVipId(string VipId)
        {
            var lst = _OrderService.FindByVipId<GetOrderByVipIdRes>(VipId);
            return lst;
        }

        public List<GetOrderByPaged> GetOrders(BaseRequest<GetOrderReq> Parameter, out int RecordCount)
        {
            if (Parameter.Paramter == null)
            {
                Parameter.Paramter = new GetOrderReq();
            }
            var lst = _OrderService.FindAll<GetOrderByPaged>(Parameter.pageNumber, Parameter.pageSize, Parameter.Paramter.OrderNo, out RecordCount);
            return lst;
        }
    }
}
