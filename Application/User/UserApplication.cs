using AutoMapper;
using DataModel.GeneralModel;
using DTO;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UserApplication
    {
        public IUserResponsity _UserService = null;
        public IRoleResponsity _RoleService = null;
        public IMenuResponsity _MenuService = null;
        public IUserRoleResponsity _UserRoleService = null;
        public IRoleMenuResponsity _RoleMenuService = null;

        public UserApplication(IUserResponsity UserService, IRoleResponsity RoleService, IMenuResponsity MenuService,
                               IUserRoleResponsity UserRoleService, IRoleMenuResponsity RoleMenuService)
        {
            _UserService = UserService;
            _RoleService = RoleService;
            _UserRoleService = UserRoleService;
            _MenuService = MenuService;
            _RoleMenuService = RoleMenuService;
        }

        #region 角色信息
        public List<Role> FindRoleList(BaseRequest<UserRoleReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<Role, bool>> predicate = t => (t.RoleName == Parameter.Paramter.RoleName || t.RoleCode == Parameter.Paramter.RoleName) && t.RoleStatus == 1;
            return _RoleService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public List<Role> FindRoleList()
        {
            Expression<Func<Role, bool>> predicate = t => t.Id.Length > 0;
            return _RoleService.FindList(predicate);
        }


        public void AddRole(BaseRequest<UserRoleReq> Parameter)
        {
            Role entity = Mapper.Map<Role>(Parameter.Paramter);
            _RoleService.Add(entity);
        }
        #endregion

        #region 用户信息
        public List<User> FindUserList(BaseRequest<UserRoleReq> Parameter,out int RecordCount)
        {
            Expression<Func<User, bool>> predicate = t => t.Id.Length > 0;
            Parameter.Paramter = new UserRoleReq();
            return _UserService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize,"UserName","DESC", out RecordCount).ToList();
        }

        public void AddUser(BaseRequest<UserRoleReq> Parameter)
        {
            User entity = Mapper.Map<User>(Parameter.Paramter);
            _UserService.Add(entity);
        }
        #endregion

        #region 角色 用户信息
        public List<UserRole> FindUserRoleList(BaseRequest<UserRoleReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<UserRole, bool>> predicate = t => (t.UserId == Parameter.Paramter.UserId ||
            t.RoleId == Parameter.Paramter.RoleId);
            return _UserRoleService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddUserRole(BaseRequest<UserRoleReq> Parameter)
        {
            UserRole entity = Mapper.Map<UserRole>(Parameter.Paramter);
            _UserRoleService.Add(entity);
        }
        #endregion

        #region 菜单信息
        public List<Menu> FindList(BaseRequest<UserRoleReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<Menu, bool>> predicate = t => (t.MenuName == Parameter.Paramter.UserName ||
            t.MenuCode == Parameter.Paramter.MenuCode);
            return _MenuService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddMenu(BaseRequest<UserRoleReq> Parameter)
        {
            Menu entity = Mapper.Map<Menu>(Parameter.Paramter);
            _MenuService.Add(entity);
        }
        #endregion

        #region 菜单信息
        public List<RoleMenu> FindRoleMenuList(BaseRequest<UserRoleReq> Parameter)
        {
            int recordCount = 0;
            Expression<Func<RoleMenu, bool>> predicate = t => (t.RoleId == Parameter.Paramter.RoleId ||
            t.MenuId == Parameter.Paramter.MenuId);
            return _RoleMenuService.FindList(predicate, Parameter.pageNumber, Parameter.pageSize, Parameter.sortName, Parameter.sortOrder, out recordCount);
        }

        public void AddRoleMenu(BaseRequest<UserRoleReq> Parameter)
        {
            RoleMenu entity = Mapper.Map<RoleMenu>(Parameter.Paramter);
            _RoleMenuService.Add(entity);
        }
        #endregion
    }
}
