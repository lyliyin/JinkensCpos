using DataModel.GeneralModel;
using System.Collections.Generic;
using System.Linq;
using DTO;
using IResponsity;
using System.Linq.Expressions;
using System;
using AutoMapper;
using AutoMapper.Mappers;
using DataCommTools;
namespace Application
{
    public class ItemApplication
    {
        private ICategoryResponsity _CategoryService = null;
        private IBrandResponsity _BrandService = null;
        private ISkuResponsity _SkuService = null;
        private IPriceSkuResponsity _PriceSkuService = null;
        private ISupplierResponsity _SupplierService = null;
        private ILogisticsResponsity _LogisticsService = null;
        private IItemImagesResponsity _ItemImagesService = null;
        private IItemResponsity _ItemService = null;
        private IItemPriceResponsity _ItemPriceService = null;
        public ItemApplication(ICategoryResponsity CategoryService, IBrandResponsity BrandService, ISkuResponsity SkuService,
            IPriceSkuResponsity PriceSkuService, ISupplierResponsity SupplierService, ILogisticsResponsity LogisticsService,
            IItemImagesResponsity ItemImagesService, IItemResponsity ItemService, IItemPriceResponsity ItemPriceService)
        {
            this._CategoryService = CategoryService;
            _BrandService = BrandService;
            _SkuService = SkuService;
            _PriceSkuService = PriceSkuService;
            _SupplierService = SupplierService;
            _ItemImagesService = ItemImagesService;
            _LogisticsService = LogisticsService;
            _ItemService = ItemService;
            _ItemPriceService = ItemPriceService;
        }

        #region 商品分类逻辑 处理
        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="total"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<Category> FindList(out int total, BaseRequest<CategoryReq> request = null)
        {
            total = 25;
            if (request == null)
            {
                return _CategoryService.FindList();
            }
            return _CategoryService.FindList(request.Paramter.nodeName, request.sortName, request.sortOrder).Skip((request.pageNumber - 1) * request.pageSize).Take(request.pageSize).ToList();
        }

        /// <summary>
        /// 递归节点信息
        /// </summary>
        /// <param name="lst">数据源</param>
        /// <param name="nodes">节点</param>
        /// <param name="ParentId">父节点编号</param>
        public void Resever(List<Category> lst, TreeViewNodesRes nodes, string ParentId)
        {
            var test = _CategoryService.FindList();
            foreach (var item in lst.Where(m => m.Pid == ParentId))
            {
                var childrens = lst.Where(m => m.Pid == item.Id).ToList();
                if (childrens.Count() > 0)
                {
                    TreeViewNodesRes node = new TreeViewNodesRes();
                    node.text = item.CategoryName;
                    node.nodeId = item.Id;
                    if (nodes.nodes == null)
                    {
                        nodes.nodes = new List<TreeViewNodesRes>() { };
                    }
                    nodes.nodes.Add(node);
                    Resever(lst, node, item.Id);
                }
                else
                {
                    TreeViewNodesRes node = new TreeViewNodesRes();
                    node.text = item.CategoryName;
                    if (nodes.nodes == null)
                    {
                        nodes.nodes = new List<TreeViewNodesRes>() { };
                    }
                    node.nodeId = item.Id;
                    nodes.nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(string Id)
        {
            Expression<Func<Category, bool>> predicate = t => t.Id == Id && t.CategoryName.Contains("小银子");
            var entity = _CategoryService.Get(predicate);
            _CategoryService.Delete(entity);
        }
        #endregion

        #region 品牌列表
        public List<Brand> FindBrandList(BaseRequest<ItemReq> Parameter, out int recordCount)
        {
            Expression<Func<Brand, bool>> predicate = t => t.BrandCode.Length > 0;
            return _BrandService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }


        public Brand GetBrand(string Id)
        {
            Expression<Func<Brand, bool>> predicate = t => t.Id == Id;
            return _BrandService.Get(predicate);
        }

        public void SaveBrand()
        {
            _BrandService.Save();
        }

        public void AddBrand(BrandReq Parameter)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BrandReq, Brand>());
            Brand entity = Mapper.Map<Brand>(Parameter);
            _BrandService.Add(entity);
        }
        #endregion

        #region 供应商列表
        public List<Supplier> FindSupplierList(BaseRequest<ItemReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<Supplier, bool>> predicate = t => String.IsNullOrEmpty(t.SupplierCode) == true;
            return _SupplierService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddSupplier(BaseRequest<ItemReq> Parameter)
        {
            Supplier entity = Mapper.Map<Supplier>(Parameter.Paramter);
            _SupplierService.Add(entity);
        }
        #endregion

        #region 物流列表
        public List<Logistics> FindLogisticsList(BaseRequest<ItemReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<Logistics, bool>> predicate = t => String.IsNullOrEmpty(t.LogisticsName) == true;
            return _LogisticsService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddLogistics(BaseRequest<ItemReq> Parameter)
        {
            Logistics entity = Mapper.Map<Logistics>(Parameter.Paramter);
            _LogisticsService.Add(entity);
        }
        #endregion

        #region 商品图片
        public List<ItemImages> FindItemImagesList(BaseRequest<ItemReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<ItemImages, bool>> predicate = t => String.IsNullOrEmpty(t.Id) == true;
            return _ItemImagesService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddItemImages(BaseRequest<ItemReq> Parameter)
        {
            ItemImages entity = Mapper.Map<ItemImages>(Parameter.Paramter);
            _ItemImagesService.Add(entity);
        }
        #endregion

        #region 商品价格
        public List<ItemPrice> FindIItemPriceList(BaseRequest<ItemReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<ItemPrice, bool>> predicate = t => String.IsNullOrEmpty(t.Id) == true;
            return _ItemPriceService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddItemPrice(BaseRequest<ItemReq> Parameter)
        {
            ItemPrice entity = Mapper.Map<ItemPrice>(Parameter.Paramter);
            _ItemPriceService.Add(entity);
        }
        #endregion

        #region 规格价格
        public List<PriceSku> FindPriceSkuList(BaseRequest<ItemReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<PriceSku, bool>> predicate = t => String.IsNullOrEmpty(t.Id) == true;
            return _PriceSkuService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddPriceSku(BaseRequest<ItemReq> Parameter)
        {
            PriceSku entity = Mapper.Map<PriceSku>(Parameter.Paramter);
            _PriceSkuService.Add(entity);
        }
        #endregion

        #region 商品列表
        public List<ItemRes> FindItem(BaseRequest<ItemsReq> request,out int RecordCount)
        {
            return _ItemService.FindList<ItemRes>("","","","",request.pageNumber,request.pageSize,"","",out RecordCount);
        }
        #endregion

        public void SetItems(BaseRequest<myItem> Parameter)
        {
            Item entity = Mapper.Map<Item>(Parameter.Paramter);
            List<ItemImages> entitys = Mapper.Map<List<ItemImages>>(Parameter.Paramter.imagesList);
            List<ItemPrice> ItemPrices = Mapper.Map<List<ItemPrice>>(Parameter.Paramter.priceList);
            _ItemService.Add(entity);
            foreach (var item in entitys)
            {
                _ItemImagesService.Add(item);
            }

            foreach (var item in Parameter.Paramter.priceList)
            {
                //
                ItemPrice ItemPriceEntity = Mapper.Map<ItemPrice>(item);
                _ItemPriceService.Add(ItemPriceEntity);
                //foreach (var nodeitem in item.skuList)
                //{
                //    Item entity = Mapper.Map<Sku>(nodeitem.);
                //}

            }
        }
    }
}
