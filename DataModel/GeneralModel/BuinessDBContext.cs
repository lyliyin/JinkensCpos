namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GeneralModel;

    public partial class BuinessDBContext : DbContext
    {
        public BuinessDBContext()
            : base("name=BuinessDBContext")
        {
        }

        public virtual DbSet<AmountDetail> AmountDetail { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<CardUseUnit> CardUseUnit { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<CouponCategory> CouponCategory { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemImages> ItemImages { get; set; }
        public virtual DbSet<ItemPrice> ItemPrice { get; set; }
        public virtual DbSet<Logistics> Logistics { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<OrderReport> OrderReport { get; set; }
        public virtual DbSet<OrderRewardRule> OrderRewardRule { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetail { get; set; }
        public virtual DbSet<PointsDetail> PointsDetail { get; set; }
        public virtual DbSet<PriceSku> PriceSku { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<Sku> Sku { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SysCardType> SysCardType { get; set; }
        public virtual DbSet<SysCardTypeGift> SysCardTypeGift { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Vip> Vip { get; set; }
        public virtual DbSet<VipAddress> VipAddress { get; set; }
        public virtual DbSet<VipCouponMap> VipCouponMap { get; set; }
        public virtual DbSet<SysDate> SysDate { get; set; }
        public virtual DbSet<SysSources> SysSources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmountDetail>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AmountDetail>()
                .Property(e => e.AmountSourceId)
                .IsUnicode(false);

            modelBuilder.Entity<AmountDetail>()
                .Property(e => e.ObjectId)
                .IsUnicode(false);

            modelBuilder.Entity<AmountDetail>()
                .Property(e => e.VipCurrentLevelId)
                .IsUnicode(false);

            modelBuilder.Entity<AmountDetail>()
                .Property(e => e.VipAfterLevelId)
                .IsUnicode(false);

            modelBuilder.Entity<AmountDetail>()
                .Property(e => e.UnitId)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.BrandCode)
                .IsUnicode(false);

            modelBuilder.Entity<CardUseUnit>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<CardUseUnit>()
                .Property(e => e.CardTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<CardUseUnit>()
                .Property(e => e.UnitId)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryCode)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Pid)
                .IsUnicode(false);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.CouponCategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.CouponCode)
                .IsUnicode(false);

            modelBuilder.Entity<CouponCategory>()
                .Property(e => e.CouponCategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<CouponCategory>()
                .Property(e => e.CouponCodeFirst)
                .IsUnicode(false);

            modelBuilder.Entity<CouponCategory>()
                .Property(e => e.CouponCodeLast)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.BrandId)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.CategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<ItemImages>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<ItemImages>()
                .Property(e => e.ItemId)
                .IsUnicode(false);

            modelBuilder.Entity<ItemPrice>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<ItemPrice>()
                .Property(e => e.ItemId)
                .IsUnicode(false);

            modelBuilder.Entity<Logistics>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Logistics>()
                .Property(e => e.LogisticsCode)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuCode)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Pid)
                .IsUnicode(false);

            modelBuilder.Entity<OrderReport>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<OrderReport>()
                .Property(e => e.UnitId)
                .IsUnicode(false);

            modelBuilder.Entity<OrderReport>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<OrderReport>()
                .Property(e => e.CategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<OrderReport>()
                .Property(e => e.BrandId)
                .IsUnicode(false);

            modelBuilder.Entity<OrderReport>()
                .Property(e => e.PayMethod)
                .IsUnicode(false);

            modelBuilder.Entity<OrderRewardRule>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<OrderRewardRule>()
                .Property(e => e.RewardValue)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.VIpId)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.SysCardTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.SysCardTypeLevelBef)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.SysCardTypeLevelAfe)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Discount)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.AddressId)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.OrderStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.UnitId)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.SourcesId)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.CouponId)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.PayMethod)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersDetail>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersDetail>()
                .Property(e => e.OrderId)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersDetail>()
                .Property(e => e.ItemId)
                .IsUnicode(false);

            modelBuilder.Entity<OrdersDetail>()
                .Property(e => e.PriceId)
                .IsUnicode(false);

            modelBuilder.Entity<PointsDetail>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<PointsDetail>()
                .Property(e => e.PointsSourceId)
                .IsUnicode(false);

            modelBuilder.Entity<PointsDetail>()
                .Property(e => e.ObjectId)
                .IsUnicode(false);

            modelBuilder.Entity<PointsDetail>()
                .Property(e => e.VipCurrentLevelId)
                .IsUnicode(false);

            modelBuilder.Entity<PointsDetail>()
                .Property(e => e.VipAfterLevelId)
                .IsUnicode(false);

            modelBuilder.Entity<PointsDetail>()
                .Property(e => e.UnitId)
                .IsUnicode(false);

            modelBuilder.Entity<PriceSku>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<PriceSku>()
                .Property(e => e.PriceId)
                .IsUnicode(false);

            modelBuilder.Entity<PriceSku>()
                .Property(e => e.SkuId)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleCode)
                .IsUnicode(false);

            modelBuilder.Entity<RoleMenu>()
                .Property(e => e.RoleId)
                .IsUnicode(false);

            modelBuilder.Entity<RoleMenu>()
                .Property(e => e.MenuId)
                .IsUnicode(false);

            modelBuilder.Entity<Sku>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Sku>()
                .Property(e => e.SkuCode)
                .IsUnicode(false);

            modelBuilder.Entity<Sku>()
                .Property(e => e.pid)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierCode)
                .IsUnicode(false);

            modelBuilder.Entity<SysCardType>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<SysCardTypeGift>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<SysCardTypeGift>()
                .Property(e => e.SysCardTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<SysCardTypeGift>()
                .Property(e => e.CouponCategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.UnitCode)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Pid)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPhone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.RoleId)
                .IsUnicode(false);

            modelBuilder.Entity<Vip>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Vip>()
                .Property(e => e.VipPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Vip>()
                .Property(e => e.VipEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Vip>()
                .Property(e => e.VipOnLineId)
                .IsUnicode(false);

            modelBuilder.Entity<Vip>()
                .Property(e => e.VipCardLevel)
                .IsUnicode(false);

            modelBuilder.Entity<VipAddress>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<VipAddress>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<VipAddress>()
                .Property(e => e.PostCode)
                .IsUnicode(false);

            modelBuilder.Entity<VipAddress>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<VipCouponMap>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<VipCouponMap>()
                .Property(e => e.VipId)
                .IsUnicode(false);

            modelBuilder.Entity<VipCouponMap>()
                .Property(e => e.CouponId)
                .IsUnicode(false);

            modelBuilder.Entity<VipCouponMap>()
                .Property(e => e.OrderId)
                .IsUnicode(false);

            modelBuilder.Entity<SysSources>()
                .Property(e => e.Code)
                .IsUnicode(false);
        }
    }
}
