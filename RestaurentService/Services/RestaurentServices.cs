using Microsoft.EntityFrameworkCore;
using RestaurentService.DTOS;
using RestaurentService.Models;
using System.Reflection.Metadata.Ecma335;

namespace RestaurentService.Services
{
    public class RestaurentServices : IRestaurentServices
    {
        private readonly RestaurentContext _context;
        public RestaurentServices(RestaurentContext customerContext)
        {
            _context = customerContext;
        }



        public bool CreateRestaurent(Restaurent restaurent)
        {
            try
            {
                bool val = _context.Restaurents.Any(r => r.Email == restaurent.Email);

                if(val) { return false; }
                
                _context.Restaurents.Add(restaurent);
                _context.SaveChanges();

               
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Restaurent> GetAllRestaurents()
        {

            try
            {
                var res = _context.Restaurents.Where(r => r.IsApproved == "true").ToList();
                return res;
            }
            catch
            {
                return null;
            }

        }

        public List<Restaurent> GetAllDisapproveRestaurents()
        {

            try
            {
                var res = _context.Restaurents.Where(r => r.IsApproved == "false").ToList();
                return res;
            }
            catch
            {
                return null;
            }

        }


        public bool ValidateRestaurent(RestaurentLoginDTO customer)
        {
            var result = _context.Restaurents
                  .Where(c => c.Email == customer.Email && c.Name == customer.Name)
                  .FirstOrDefault(); //
            if (result != null)
                return true;
            return false;
        }



        //public async Task<String> Approval(string id,)
        public bool ApproveRestaurent(string Id)
        {
            try
            {
              
                var val = _context.Restaurents.FirstOrDefault(r=>r.Email == Id);
                if(val != null)
                {
                    if(val.IsApproved == "false")
                    {
                        val.IsApproved = "true";
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }


        }



        public bool DisableRestaurent(string Id)
        {
            try
            {
                var val = _context.Restaurents.FirstOrDefault(r => r.Email == Id);
                if (val != null)
                {
                    if (val.IsApproved == "true")
                    {
                        val.IsApproved = "false";
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public async Task<Restaurent> FetchByLocation(string filter)
        {
            try
            {
                var val = _context.Restaurents.Where(r => r.Location == filter && r.IsApproved == "true").FirstOrDefault();
                return val;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Restaurent> FetchByName(string filter)
        {
            try
            {
                var val = _context.Restaurents.Where(r => r.Name == filter && r.IsApproved == "true").FirstOrDefault();
                if(val != null)
                {

                return val;
                }return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Restaurent> GetRestaurentById(string Id)
        {
            try
            {
                var restaurent = await _context.Restaurents.FirstOrDefaultAsync(s => s.Email == Id && s.IsApproved == "true");
                if (restaurent != null)
                {
                   

                    return restaurent;

                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Restaurent> GetRestaurentByhygine()
        {
            try
            {
                var res = _context.Restaurents.Where(r => r.IsApproved == "true").ToList();
                return res;
            }
            catch
            {
                return null;
            }
        }





    }
}
