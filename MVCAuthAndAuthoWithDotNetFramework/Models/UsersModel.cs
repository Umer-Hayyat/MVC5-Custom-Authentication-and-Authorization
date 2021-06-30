using MVCAuthAndAuthoWithDotNetFramework.DbContext;
using MVCAuthAndAuthoWithDotNetFramework.DbContext.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAuthAndAuthoWithDotNetFramework.Models
{
    public class UsersModel
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Name field is required")]
        [MinLength(4, ErrorMessage = "Name should contain atleast 4 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot contain more than 50 characters")]
        public string Name { get; set; }

        private List<UsersModel> _users = new List<UsersModel>();

        public UsersModel()
        {
        }

        public List<UsersModel> GetAllUsers()
        {
            using (var _context = new TestUserContext())
            {
                return MapDBModelToModel(_context.Users.ToList());
            }
        }

        public UsersModel GetUserByID(int userID)
        {
            using (var _context = new TestUserContext())
            {
                return MapDBModelToModel(_context.Users.First(x => x.ID == userID));
            }
        }

        public void AddUser()
        {
            using (var _context = new TestUserContext())
            {
                UserDBModel user = MapModelToDBModel(this);

                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUser()
        {
            using (var _context = new TestUserContext())
            {
                UsersModel model = this.GetUserByID(this.ID);
                UserDBModel userdbModel = MapModelToDBModel(new UsersModel() { ID = model.ID, Name = this.Name });

                _context.Users.Attach(userdbModel);
                _context.Entry(userdbModel).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public void DeleteUser()
        {
            using (var _context = new TestUserContext())
            {
                UserDBModel userdbModel = MapModelToDBModel(this.GetUserByID(this.ID));

                _context.Users.Attach(userdbModel);
                _context.Entry(userdbModel).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        #region Helper Methods

        private UsersModel MapDBModelToModel(UserDBModel dbModel)
        {
            return new UsersModel()
            {
                ID = dbModel.ID,
                Name = dbModel.Name
            };
        }


        private List<UsersModel> MapDBModelToModel(List<UserDBModel> dbModel)
        {
            List<UsersModel> users = new List<UsersModel>();
            dbModel?.ForEach(x =>
            {
                users.Add(MapDBModelToModel(x));
            });

            return users;
        }


        private UserDBModel MapModelToDBModel(UsersModel dbModel)
        {
            return new UserDBModel()
            {
                ID = dbModel.ID,
                Name = dbModel.Name
            };
        }

        #endregion Helper Methods

    }
}