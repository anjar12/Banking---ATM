using Infra.Data.Context;
using Infra.Data.Models;
using Infra.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class TransactionalRepository : ITransactional
    {
        private readonly IConfiguration _configuration;
        private readonly BankingDB _context;
        public TransactionalRepository(BankingDB bankingDB, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = bankingDB;
        }

        async Task<Tuple<bool, Result>> ITransactional.Insert_Customer(PostData<Insert_Customer> postData)
        {
            Result result= new Result();
            try 
            {
                if (postData.Value != null) 
                {
                    Customers customers = new Customers();
                    customers.FirstName = postData.Value.FirstName;
                    customers.LastName = postData.Value.LastName;
                    customers.RekeningNumber = postData.Value.RekeningNumber;
                    customers.NIK = postData.Value.NIK;
                    customers.PIN = postData.Value.PIN;
                    customers.Address = postData.Value.Address;
                    customers.PhoneNumber = postData.Value.PhoneNumber;
                    customers.ApproveBy = postData.Value.ApproveBy;
                    customers.ID_Users = int.Parse(postData.Value.ID_Users);
                    customers.CreatedTime = DateTime.Now;
                    _context.Add(customers);
                    await _context.SaveChangesAsync();
                    if (customers.ID_Customers > 0)
                    {
                        result = new ResultError().result(0, false, "Berhasil Disimpan");
                        return new Tuple<bool, Result>(true, result);
                    }
                    else 
                    {
                        result = new ResultError().result(2001001, true, "Gagal Disimpan");
                        return new Tuple<bool, Result>(false, result);
                    }
                }
                else 
                {
                    result = new ResultError().result(2001001, true, "");
                    return new Tuple<bool, Result>(false, result);
                }
            }
            catch (Exception ex) 
            {
                result = new ResultError().result(2001001, true, ex.Message);
                return new Tuple<bool, Result>(false, result);
            }
        }
        async Task<Tuple<bool, Result>> ITransactional.Update_Customer(PostData<Update_Customer> postData)
        {
            Result result = new Result();
            try 
            {
                if (postData.Value != null)
                {
                    var chek = (from a in _context.Customers
                                where a.ID_Customers == postData.Value.ID_Customer
                                select a).FirstOrDefault() ?? new Customers() ;
                    if (chek.ID_Customers > 0)
                    {

                        if (postData.Value.PIN > 0)
                        {
                            chek.PIN = postData.Value.PIN;
                        }
                        if (!string.IsNullOrEmpty(postData.Value.Address))
                        {
                            chek.Address = postData.Value.Address;
                        }
                        if (!string.IsNullOrEmpty(postData.Value.PhoneNumber))
                        {
                            chek.PhoneNumber = postData.Value.PhoneNumber;
                        }
                        if (postData.Value.ID_Users > 0)
                        {
                            chek.ID_Users = postData.Value.ID_Users;
                        }
                        _context.Update(chek);
                        await _context.SaveChangesAsync();

                        result = new ResultError().result(0, false, "Berhasil");
                        return new Tuple<bool, Result>(true, result);

                    }
                    else 
                    {
                        result = new ResultError().result(2001002, true, "Users Tidak Ditemukan");
                        return new Tuple<bool, Result>(false, result);
                    }
                }
                else
                {
                    result = new ResultError().result(2001002, true, "");
                    return new Tuple<bool, Result>(false, result);
                }
            }
            catch (Exception ex) 
            {
                result = new ResultError().result(2001001, true, ex.Message);
                return new Tuple<bool, Result>(false, result);

            }
        }
        async Task<Tuple<bool, Result>> ITransactional.Delete_Customer(PostData<Delete_Customer> postData)
        {
            Result result = new Result();
            try
            {
                if (postData.Value != null)
                {
                    var chek = (from a in _context.Customers
                                where a.ID_Customers == postData.Value.ID_Customer
                                select a).FirstOrDefault() ?? new Customers();
                    if (chek.ID_Customers > 0)
                    {                        
                        _context.Remove(chek);
                        await _context.SaveChangesAsync();

                        result = new ResultError().result(0, false, "Berhasil dihapus");
                        return new Tuple<bool, Result>(true, result);

                    }
                    else
                    {
                        result = new ResultError().result(2001002, true, "Users Tidak Ditemukan");
                        return new Tuple<bool, Result>(false, result);
                    }
                }
                else
                {
                    result = new ResultError().result(2001002, true, "");
                    return new Tuple<bool, Result>(false, result);
                }
            }
            catch (Exception ex)
            {
                result = new ResultError().result(2001001, true, ex.Message);
                return new Tuple<bool, Result>(false, result);

            }
        }

    }
}
