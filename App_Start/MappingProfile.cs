using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Libly.Dtos;
using Libly.Models;

namespace Libly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<BookDto, Book>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Membership, MembershipDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}