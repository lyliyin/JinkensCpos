using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataModel.GeneralModel;
using DTO;
using AutoMapper;
using Redis;
using DataCommTools;

namespace Application
{
    public class VipApplication
    {
        private ISysCardTypeResponsity _SysCardTypeService = null;
        private ISysCardTypeGiftResponsity _SysCardTypeGiftService = null;
        private ICardUseUnitResponsity _CardUseUnitService = null;
        private IVipCouponMapResponsity _VipCouponMapService = null;
        private ICouponCategoryResponsity _CouponCategoryService = null;
        private RedisSetService _RedisSetService = null;
        private IVipResponsity _VipService = null;
        private IPriceSkuResponsity _PriceSkuService = null;
        private IUnitResponsity _UnitService = null;
        private IAmountDetailResponsity _AmountDetailService = null;
        private IPointsDetailResponsity _PointsDetailService = null;
        public VipApplication(ISysCardTypeResponsity SysCardTypeService, ISysCardTypeGiftResponsity SysCardTypeGiftService,
            ICardUseUnitResponsity CardUseUnitService, IVipCouponMapResponsity VipCouponMapService,
            ICouponCategoryResponsity CouponCategoryService, RedisSetService RedisSetService, IVipResponsity VipService, IPriceSkuResponsity PriceSkuService,
            IUnitResponsity UnitService, IAmountDetailResponsity AmountDetailService, IPointsDetailResponsity PointsDetailService)
        {
            _SysCardTypeService = SysCardTypeService;
            _SysCardTypeGiftService = SysCardTypeGiftService;
            _CardUseUnitService = CardUseUnitService;
            _VipCouponMapService = VipCouponMapService;
            _CouponCategoryService = CouponCategoryService;
            _RedisSetService = RedisSetService;
            _VipService = VipService;
            _PriceSkuService = PriceSkuService;
            _UnitService = UnitService;
            _AmountDetailService = AmountDetailService;
            _PointsDetailService = PointsDetailService;
        }

        /// <summary>
        /// 获取会员卡列表
        /// </summary>
        /// <returns></returns>
        public List<CardTypeReq> GetCardTypeList()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SysCardType, CardTypeReq>());
            Expression<Func<SysCardType, bool>> prediect = t => t.SysCardLevel > 0;
            var lst = _SysCardTypeService.FindList(prediect);
            List<CardTypeReq> lists = Mapper.Map<List<CardTypeReq>>(lst);
            if (lists != null && lists.Count() > 0)
            {
                foreach (var item in lists)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<Unit, UnitInfo>());
                    var units = _CardUseUnitService.FindByCardTypeId(item.Id);
                    item.units = Mapper.Map<List<UnitInfo>>(units);

                    Mapper.Initialize(cfg => cfg.CreateMap<CouponCategory, CouponCategorys>());
                    var images = _SysCardTypeGiftService.FindImagesList(item.Id);
                    item.couponcategorys = Mapper.Map<List<CouponCategorys>>(images);

                }
            }
            return lists;
        }

        /// <summary>
        /// 获取会员基本信息
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public List<VipInfoRes> GetVipList(BaseRequest<VipInfoReq> Parameter, out int RecordCount)
        {
            Expression<Func<Vip, bool>> predicate = t => t.Id.Length > 0;

            if (Parameter.Paramter != null)
            {
                if (!String.IsNullOrEmpty(Parameter.Paramter.Email))
                {
                    predicate.And(t => t.VipEmail == Parameter.Paramter.Email);
                }

                if (!String.IsNullOrEmpty(Parameter.Paramter.Phone))
                {
                    predicate.And(t => t.VipPhone == Parameter.Paramter.Phone);
                }
            }

            Mapper.Initialize(cfg => cfg.CreateMap<Vip, VipInfoRes>());


            if (String.IsNullOrEmpty(Parameter.sortName))
            {
                Parameter.sortName = "VipName";
            }

            var lst = _VipService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out RecordCount);

            List<VipInfoRes> result = Mapper.Map<List<VipInfoRes>>(lst);
            return result;
        }


        /// <summary>
        /// 获取会员基本信息
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public VipInfoRes GetVip(string VipId)
        {
            Expression<Func<Vip, bool>> predicate = t => t.Id == VipId;
            Mapper.Initialize(cfg => cfg.CreateMap<Vip, VipInfoRes>());
            var entity = _VipService.Get(predicate);
            VipInfoRes result = Mapper.Map<VipInfoRes>(entity);
            return result;
        }


        /// <summary>
        /// 获取会员基本信息
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public List<PointsDetailRes> GetVipPoints(string VipId)
        {
            var list = _PointsDetailService.FindListByVipId<PointsDetailRes>(VipId);
            return list;
        }

        /// <summary>
        /// 获取会员基本信息
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public List<AmountDetailRes> GetVipAmount(string VipId)
        {
            var list = _AmountDetailService.FindListByVipId<AmountDetailRes>(VipId);
            return list;
        }


        /// <summary>
        /// 获取会员 优惠券信息
        /// </summary>
        /// <param name="Parameter"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public List<VipCouponMappingRes> GetCouoponByVipId(string VipId)
        {
            var list = _VipCouponMapService.FindByVipId<VipCouponMappingRes>(VipId);
            return list;
        }

        public List<CouponInfoRes> FindCoupons(string CouponCode)
        {
            Expression<Func<CouponCategory, bool>> predicate = null;

            if (String.IsNullOrEmpty(CouponCode))
            {
                predicate = t => t.CouponCategoryId.Length > 0;
            }
            else
            {
                predicate = t => t.CouponCodeFirst.Contains(CouponCode) || t.CouponCodeLast.Contains(CouponCode);
            }
            Mapper.Initialize(cfg => cfg.CreateMap<CouponCategory, CouponInfoRes>());
            var lst = _CouponCategoryService.FindList(predicate);
            List<CouponInfoRes> result = Mapper.Map<List<CouponInfoRes>>(lst);
            return result;
        }

        public void SaveCouponCategory(CouponCategory entity)
        {
            _CouponCategoryService.Add(entity);
        }

        public void AddPoints(string PointsSourceId, int Points, string VipId)
        {
            PointsDetail detail = new PointsDetail()
            {
                Id = Guid.NewGuid().ToString(),
                ObjectId = "",
                Points = Points,
                PointsDate = DateTime.Now,
                PointsSourceId = PointsSourceId,
                UnitId = "",
                VipId = VipId
            };

            if (Points > 0)
            {
                _VipService.Excutes(string.Format("UPDATE VIP SET VipPoints = VipPoints+{0} WHERE Id='{1}'", Points, VipId));
            }
            else
            {
                _VipService.Excutes(string.Format("UPDATE VIP SET VipPoints = VipPoints-{0} WHERE Id='{1}'", Math.Abs(Points), VipId));
            }

            _PointsDetailService.Add(detail);
        }


        public void AddAmounts(string AmountSourceId, decimal Amount, string VipId)
        {
            AmountDetail detail = new AmountDetail()
            {
                Id = Guid.NewGuid().ToString(),
                ObjectId = "",
                 Amount = Amount,
                 AmountDate = DateTime.Now,
                 AmountSourceId = AmountSourceId,
                UnitId = "",
                VipId = VipId
            };

            if (Amount > 0)
            {
                _VipService.Excutes(string.Format("UPDATE VIP SET VipAmount = VipAmount+{0} WHERE Id='{1}'", Amount, VipId));
            }
            else
            {
                _VipService.Excutes(string.Format("UPDATE VIP SET VipAmount = VipAmount-{0} WHERE Id='{1}'", Math.Abs(Amount), VipId));
            }
            _AmountDetailService.Add(detail);
        }

        /// <summary>
        /// 产生优惠券 放入 缓存 等待会员的领取
        /// </summary>
        /// <param name="CouponCategoryId"></param>
        public void CreateCoupons(string CouponCategoryId)
        {
            Expression<Func<CouponCategory, bool>> predicate = t => t.CouponCategoryId == CouponCategoryId;
            var entity = _CouponCategoryService.Get(predicate);
            int TaskCount = 15;
            int PageSize = Convert.ToInt32(entity.CouponCount % TaskCount == 0 ? entity.CouponCount / TaskCount : (entity.CouponCount / TaskCount) + 1);

            for (int i = 0; i < entity.CouponCount; i++)
            {
                _RedisSetService.Add("CouponCategory" + CouponCategoryId, entity.CouponCodeFirst + i);
            }

            //是否产生优惠券
            entity.HasSend = 1;
        }

        /// <summary>
        /// 将会员信息加入到缓存里面去
        /// </summary>
        public void SetVipToRedis()
        {
            Expression<Func<Vip, bool>> predicate = t => t.Id.Length > 0;
            var entitys = _VipService.FindList(predicate);
            foreach (var item in entitys)
            {
                _RedisSetService.Add("Vip", item.Id);
            }
        }

        /// <summary>
        /// 将价格信息加入到缓存里面去
        /// </summary>
        public void SetSkuToRedis()
        {
            Expression<Func<PriceSku, bool>> predicate = t => t.Id.Length > 0;
            var entitys = _PriceSkuService.FindList(predicate).Take(6000);
            foreach (var item in entitys)
            {
                _RedisSetService.Add("PriceSku", item.Id);
            }
        }



        /// <summary>
        /// 将价格信息加入到缓存里面去
        /// </summary>
        public void SetUnitToRedis()
        {
            Expression<Func<Unit, bool>> predicate = t => t.Id.Length > 0;
            var entitys = _UnitService.FindList(predicate).Take(6000);
            foreach (var item in entitys)
            {
                _RedisSetService.Add("Unit", item.Id);
            }
        }
    }
}
