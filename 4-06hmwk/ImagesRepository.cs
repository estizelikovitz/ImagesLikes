using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_06hmwk
{
    public class ImagesRepository
    {
        private string _connectionString;

        public ImagesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Image> GetAll()
        {
            using var context = new DataContext(_connectionString);
            return context.Images.ToList();
        }

        public void Add(Image image)
        {
            using var context = new DataContext(_connectionString);
            context.Images.Add(image);
            context.SaveChanges();
        }

        public Image GetById(int id)
        {
            using var context = new DataContext(_connectionString);
            return context.Images.FirstOrDefault(i => i.Id == id);
        }

        //public void Update(Person person)
        //{
        //    using var context = new PeopleDataContext(_connectionString);
        //    context.People.Attach(person);
        //    context.Entry(person).State = EntityState.Modified;
        //    context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    using var context = new PeopleDataContext(_connectionString);
        //    //var person = context.People.FirstOrDefault(p => p.Id == id);
        //    //context.People.Remove(person);
        //    //context.SaveChanges();
        //    context.Database.ExecuteSqlInterpolated($"DELETE FROM People WHERE Id = {id}");
        //}
    }
}
