using CrudContactXml.DAL;
using CrudContactXml.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudContactXml.Services
{
    public class NotatnikService
    {
        private readonly Notatnik _notatnik;

        public NotatnikService(Notatnik notatnik)
        {
            _notatnik = notatnik;
        }

        public List<Category> Contacts()
        {
            return _notatnik.Category;
        }

        public IEnumerable<Category> Search(IEnumerable<Category> qrt, string SearchString)
        {
            var qrySearch = qrt;
            if (!String.IsNullOrEmpty(SearchString))
            {
                qrySearch = qrySearch.Where(s => s.Titlle.Contains(SearchString) || s.Description.Contains(SearchString));
            }

            return qrySearch;
        }

        public IEnumerable<Category> Filter(IEnumerable<Category> qrt, string filter)
        {
            var qrySearch = qrt;

            switch (filter)
            {
                case "Group":
                    qrySearch = qrySearch.OrderByDescending(s => s.Group);
                    break;
                case "Titlle":
                    qrySearch = qrySearch.OrderByDescending(s => s.Titlle);
                    break;
                case "Description":
                    qrySearch = qrySearch.OrderByDescending(s => s.Description);
                    break;
                case "Id":
                    qrySearch = qrySearch.OrderByDescending(s => s.Id);
                    break;
                case "Checked":
                    qrySearch = qrySearch.OrderByDescending(s => s.Checked);
                    break;
            }

            return qrySearch;
        }

        public Category GetCategory(int id)
        {
            return _notatnik.Category.Single(s => s.Id == id);
        }

        public Category Save(Category category)
        {
            category.Id = (this._notatnik.Category.Count == 0) ? 0 : this._notatnik.Category.Count + 1;
            _notatnik.Category.Add(category);
            _notatnik.Write();

            return category;
        }

        public void Delete(int id)
        {
            _notatnik.Category.Remove(this.GetCategory(id));
            _notatnik.Write();
        }

        public Category Update(int id, Category category)
        {
            _notatnik.Category.Single(b => b.Id == id).Update(category);          
            _notatnik.Write();

            return category;
        }
    }
}
