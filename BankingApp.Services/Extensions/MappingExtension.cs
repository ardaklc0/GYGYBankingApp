using AutoMapper;
using BankingApp.DataTransferObject.Responses.Transaction;
using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services.Extensions
{
    public static class MappingExtension
    {
        public static T ConvertToDto<T>(this IEnumerable<Transaction> transactions, IMapper mapper)
        {
            return mapper.Map<T>(transactions);
        }

    }
}
