using Infra.Data.Context;
using Infra.Data.Models;
using Infra.Interfaces;
using Infra.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Repositories
{
    public class MastersRepository : IMaster
    {
        private readonly IConfiguration _configuration;
        private readonly BankingDB _context;
        public MastersRepository(BankingDB bankingDB, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = bankingDB;
        }
        async Task<Tuple<bool, Result, ResultValue<List<View_Customers>>>> IMaster.Get_Customer(PostData<Abstract> postData)
        {
            ResultValue<List<View_Customers>> resultValue = new ResultValue<List<View_Customers>>();
            Result result = new Result();
            try
            {
                var tempResult = (from a in _context.Customers
                                  select new View_Customers
                                  {
                                      ID_Customers = a.ID_Customers.ToString(),
                                      FirstName = a.FirstName,
                                      LastName = a.LastName,
                                      Address = a.Address,
                                      NIK = a.NIK,
                                      PhoneNumber = a.PhoneNumber,
                                      PIN = a.PIN,
                                  }).ToList() ?? new List<View_Customers>();
                if (tempResult.Count > 0)
                {
                    resultValue.Value = tempResult;
                    result = new ResultError().result(0, false, "");
                    return new Tuple<bool, Result, ResultValue<List<View_Customers>>>(true, result, resultValue);
                }
                else
                {
                    result = new ResultError().result(1001001, true, "Data tidak ditemukan");
                    return new Tuple<bool, Result, ResultValue<List<View_Customers>>>(false, result, resultValue);
                }
            }
            catch (Exception ex)
            {
                result = new ResultError().result(1001001, true, ex.Message);
                return new Tuple<bool, Result, ResultValue<List<View_Customers>>>(false, result, resultValue);
            }
        }

        async Task<Tuple<bool, Result,ResultValue<View_Credentials>>> IMaster.Login(PostData<Login> postData)
        {
            ResultValue<View_Credentials> resultValue= new ResultValue<View_Credentials>();
            Result result = new Result();
            try 
            {
                TripleDES.EncryptTripleDES encrypt = new TripleDES.EncryptTripleDES();
                if (postData.Value != null)
                {
                    bool validate = true;
                    string message = string.Empty;
                    if (string.IsNullOrEmpty(postData.Value.Username))
                    {
                        validate = false;
                        message += "Username Tidak Boleh Kosong";
                    }

                    if (string.IsNullOrEmpty(postData.Value.Password))
                    {
                        validate = false;
                        message += "Password Tidak Boleh Kosong";
                    }
                    if (validate)
                    {
                        var users = (from a in _context.Users
                                           where a.UserName == postData.Value.Username
                                           where a.Password == postData.Value.Password
                                           select new View_Credentials
                                           {
                                               ID_Customers = encrypt.EncryptString(a.ID_Users.ToString(),Settings.keyDES)
                                           }).FirstOrDefault() ?? new View_Credentials();
                        if (!string.IsNullOrEmpty(users.ID_Customers))
                        {
                            resultValue.Value = users;
                            result = new ResultError().result(0, false, "");
                            return new Tuple<bool, Result, ResultValue<View_Credentials>>(true, result, resultValue);

                        }
                        else 
                        {
                            result = new ResultError().result(1001002, true, "Kombinasi Username dan Password tidak sesuai");
                            return new Tuple<bool, Result, ResultValue<View_Credentials>>(false, result, resultValue);

                        }
                    }
                    else 
                    {
                        result = new ResultError().result(1001002, true, message);
                        return new Tuple<bool, Result, ResultValue<View_Credentials>>(false, result, resultValue);
                    }
                }
                else 
                {
                    result = new ResultError().result(1001002, true, "");
                    return new Tuple<bool, Result, ResultValue<View_Credentials>>(false, result, resultValue);
                }
            }
            catch (Exception ex) 
            {
                result = new ResultError().result(1001002, true, ex.Message);
                return new Tuple<bool, Result, ResultValue<View_Credentials>>(false, result, resultValue);
            }
        }
    }

}
