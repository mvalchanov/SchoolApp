namespace SchoolApp.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;
    using System.Linq;


    public class GroupRepository : IGroupRepository
    {
        public GroupRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }
        private ApplicationDbContext context { get; set; }


        public void Add(Group group)
        {
            this.context.Groups.Add(group);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntity = this.context.Groups.FirstOrDefault(u => u.GroupId == id);
            this.context.Groups.Remove(dbEntity);
            this.context.SaveChanges();

        }

        public void Edit(Group group)
        {
            var dbEntity = this.context.Groups.FirstOrDefault(e => e.GroupId == group.GroupId);
            if (dbEntity != null)
            {
                dbEntity.Name = group.Name;
                dbEntity.Users = group.Users;
            }
        }

        public IQueryable<Group> GetAll(bool includeUsers)
        {
            var allGroups = this.context.Groups;
            if (includeUsers)
            {
                allGroups.Include(u => u.Users).ToList();
            }
            return allGroups.AsQueryable();
        }

        public Group GetById(int id)
        {
            var dbEntity = this.context.Groups.FirstOrDefault(e => e.GroupId == id);

            return dbEntity;
        }
    }
}
